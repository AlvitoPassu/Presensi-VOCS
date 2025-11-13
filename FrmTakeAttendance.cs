using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_Project
{
    public partial class FrmTakeAttendance : Form
    {
        public FrmTakeAttendance()
        {
            InitializeComponent();
        }

        private void FrmTakeAttendance_Load(object sender, EventArgs e)
        {
            // Kosong - belum ada logic tambahan
        }

        private void btnStartAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                // Koneksi ke database
                string connString = "server=localhost;database=db_choir;uid=root;pwd=;";
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();

                    // Query untuk menyimpan data meeting baru
                    string query = "INSERT INTO tbl_attendance (meeting_date, meeting_time, meeting_description) " +
                                   "VALUES (@date, @time, @desc)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // Ambil nilai dari form
                    cmd.Parameters.AddWithValue("@date", dtpDate.Value.Date);
                    cmd.Parameters.AddWithValue("@time", cmbTime.Text);
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text);

                    // Eksekusi query
                    cmd.ExecuteNonQuery();
                }

                // Simpan data sesi yang sedang aktif ke variabel global
                AttendanceSession.MeetingDate = dtpDate.Value.Date;
                AttendanceSession.MeetingTime = cmbTime.Text;
                AttendanceSession.MeetingDescription = txtDescription.Text;

                // Buka form kamera
                FrmCam frmCam = new FrmCam();
                frmCam.Show();

                // Sembunyikan form ini
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving attendance: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            // Kosong
        }

        private void cmbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kosong
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            // Kosong
        }
    }

    // === Class statis untuk menyimpan data sesi yang sedang aktif ===
    public static class AttendanceSession
    {
        public static DateTime MeetingDate { get; set; }
        public static string MeetingTime { get; set; }
        public static string MeetingDescription { get; set; }
    }
}
