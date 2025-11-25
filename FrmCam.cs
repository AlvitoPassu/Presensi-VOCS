using AForge.Video;
using AForge.Video.DirectShow;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZXing;

namespace Final_Project
{
    public partial class FrmCam : Form
    {
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;

        private Bitmap latestFrame;
        private readonly object frameLock = new object();

        private BarcodeReader barcodeReader;

        private bool scanProcessed = false; // ❗ Untuk mencegah double processing

        public FrmCam()
        {
            InitializeComponent();
        }

        private void FrmCam_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Load device kamera
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in CaptureDevice)
                comboBox1.Items.Add(device.Name);

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            // ZXing Setup
            barcodeReader = new BarcodeReader
            {
                AutoRotate = true,
                Options = new ZXing.Common.DecodingOptions
                {
                    TryHarder = true,
                    TryInverted = true,
                    PossibleFormats = new List<BarcodeFormat>
                    {
                        BarcodeFormat.QR_CODE,
                        BarcodeFormat.CODE_128,
                        BarcodeFormat.CODE_39,
                        BarcodeFormat.EAN_13,
                        BarcodeFormat.EAN_8,
                        BarcodeFormat.UPC_A,
                        BarcodeFormat.UPC_E,
                        BarcodeFormat.ITF,
                        BarcodeFormat.CODABAR,
                        BarcodeFormat.DATA_MATRIX,
                        BarcodeFormat.PDF_417,
                        BarcodeFormat.AZTEC
                    }
                }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CaptureDevice.Count == 0)
            {
                MessageBox.Show("Tidak ada kamera ditemukan.");
                return;
            }

            FinalFrame = new VideoCaptureDevice(
                CaptureDevice[comboBox1.SelectedIndex].MonikerString);

            var resolutions = FinalFrame.VideoCapabilities;
            var res169 = resolutions.FirstOrDefault(r =>
                Math.Abs((double)r.FrameSize.Width / r.FrameSize.Height - 16.0 / 9.0) < 0.02);

            if (res169 != null)
                FinalFrame.VideoResolution = res169;

            FinalFrame.NewFrame += FinalFrame_NewFrame;
            FinalFrame.Start();
        }

        // ===========================
        //      RECORD ATTENDANCE
        // ===========================
        private void RecordAttendance(string regNumber)
        {
            using (var conn = new MySqlConnection("server=localhost;database=db_choir;uid=root;pwd=;"))
            {
                conn.Open();

                // 1. Cari member
                string qMember = "SELECT id FROM tbl_anggota WHERE registration_number=@reg LIMIT 1";
                var cmd1 = new MySqlCommand(qMember, conn);
                cmd1.Parameters.AddWithValue("@reg", regNumber);
                object result = cmd1.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Anggota tidak ditemukan.");
                    return;
                }

                int memberId = Convert.ToInt32(result);

                // 2. Cari meeting terbaru
                string qMeeting = "SELECT id, meeting_time FROM tbl_attendance ORDER BY id DESC LIMIT 1";
                var cmd2 = new MySqlCommand(qMeeting, conn);
                var rd = cmd2.ExecuteReader();

                int attendanceId = 0;
                TimeSpan meetingTime = TimeSpan.Zero;

                if (rd.Read())
                {
                    attendanceId = rd.GetInt32("id");
                    meetingTime = rd.GetTimeSpan("meeting_time");
                }
                rd.Close();

                // 3. Cek double scan
                string qCheck = "SELECT COUNT(*) FROM tbl_attendance_detail WHERE attendance_id=@aid AND member_id=@mid";
                var cmdCheck = new MySqlCommand(qCheck, conn);
                cmdCheck.Parameters.AddWithValue("@aid", attendanceId);
                cmdCheck.Parameters.AddWithValue("@mid", memberId);

                if (Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0)
                {
                    MessageBox.Show("Anda sudah melakukan scan.");
                    return;
                }

                // 4. Tentukan status
                string status;
                TimeSpan now = DateTime.Now.TimeOfDay;

                if (now <= meetingTime.Add(TimeSpan.FromMinutes(10)))
                    status = "HADIR";
                else
                    status = "TERLAMBAT";

                // 5. Insert detail
                string qDetail = @"INSERT INTO tbl_attendance_detail 
                    (attendance_id, member_id, status, timestamp)
                    VALUES (@aid, @mid, @status, NOW())";

                var cmd3 = new MySqlCommand(qDetail, conn);
                cmd3.Parameters.AddWithValue("@aid", attendanceId);
                cmd3.Parameters.AddWithValue("@mid", memberId);
                cmd3.Parameters.AddWithValue("@status", status);
                cmd3.ExecuteNonQuery();

                // 6. UPDATE COUNTER
                string counterColumn = status == "HADIR" ? "present" : "late";

                string qUpdate = $"UPDATE tbl_attendance SET {counterColumn} = {counterColumn} + 1 WHERE id=@aid";

                var cmd4 = new MySqlCommand(qUpdate, conn);
                cmd4.Parameters.AddWithValue("@aid", attendanceId);
                cmd4.ExecuteNonQuery();


                // 7. Info
                MessageBox.Show($"Scan Berhasil!\nStatus: {status}",
                                "Sukses",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        // ===========================
        //          CAMERA FRAME
        // ===========================
        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                using (Bitmap raw = (Bitmap)eventArgs.Frame.Clone())
                {
                    lock (frameLock)
                    {
                        latestFrame?.Dispose();
                        latestFrame = (Bitmap)raw.Clone();
                    }

                    Bitmap ui = (Bitmap)raw.Clone();
                    pictureBox1.Invoke(new Action(() =>
                    {
                        pictureBox1.Image?.Dispose();
                        pictureBox1.Image = ui;
                    }));
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scanProcessed = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (scanProcessed) return;

            Bitmap frameToDecode = null;

            lock (frameLock)
            {
                if (latestFrame != null)
                    frameToDecode = (Bitmap)latestFrame.Clone();
            }

            if (frameToDecode == null)
                return;

            try
            {
                var result = barcodeReader.Decode(frameToDecode);

                if (result != null)
                {
                    scanProcessed = true;     // ❗ STOP memproses ulang
                    timer1.Stop();           // ❗ STOP timer

                    string decoded = result.Text.Trim();
                    textBox1.Text = decoded;

                    RecordAttendance(decoded);
                }
            }
            catch { }
            finally
            {
                frameToDecode.Dispose();
            }
        }

        private void FrmCam_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (FinalFrame != null && FinalFrame.IsRunning)
                {
                    FinalFrame.SignalToStop();
                    FinalFrame.WaitForStop();
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (FinalFrame != null && FinalFrame.IsRunning)
                {
                    FinalFrame.SignalToStop();
                    FinalFrame.WaitForStop();
                }

                // Temukan Formmain yang sedang terbuka (perhatikan 'm' kecil)
                var frmMain = Application.OpenForms.OfType<Formmain>().FirstOrDefault();

                FormStatistics f = new FormStatistics();

                // Tetapkan Formmain sebagai Owner dari FormStatistics
                if (frmMain != null)
                {
                    f.Owner = frmMain;
                }

                f.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
