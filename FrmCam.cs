using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace Final_Project
{
    public partial class FrmCam : Form
    {
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;

        public FrmCam()
        {
            InitializeComponent();
        }

        private void FrmCam_Load(object sender, EventArgs e)
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // Hindari error iterasi Device
            foreach (FilterInfo device in CaptureDevice)
            {
                comboBox1.Items.Add(device.Name);
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            FinalFrame = new VideoCaptureDevice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void FrmCam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame != null && FinalFrame.IsRunning)
                FinalFrame.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BarcodeReader reader = new BarcodeReader();
            if (pictureBox1.Image != null)
            {
                try
                {
                    var result = reader.Decode((Bitmap)pictureBox1.Image);
                    if (result != null)
                    {
                        string decoded = result.Text.Trim();
                        if (!string.IsNullOrEmpty(decoded))
                        {
                            textBox1.Text = decoded;
                        }
                    }
                }
                catch (Exception)
                {
                    // Kosong - biarkan agar tidak crash
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Hentikan kamera jika masih aktif
                if (FinalFrame != null && FinalFrame.IsRunning)
                {
                    FinalFrame.SignalToStop();
                    FinalFrame.WaitForStop();
                }

                // Buka FormStatistics untuk melihat hasil presensi
                FormStatistics statisticsForm = new FormStatistics();
                statisticsForm.Show();

                // Tutup form kamera
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat menyelesaikan absen: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
