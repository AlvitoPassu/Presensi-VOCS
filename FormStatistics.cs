using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_Project
{
    public partial class FormStatistics : Form
    {
        public FormStatistics()
        {
            InitializeComponent();
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            try
            {
                string connectionString = "server=localhost;database=db_choir;uid=root;pwd=;";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT id, meeting_date, meeting_time, meeting_description, present, late, absent, izin FROM tbl_attendance ORDER BY meeting_date DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvStatistics.DataSource = dt;

                    // Atur lebar kolom agar lebih rapi
                    dgvStatistics.Columns["id"].HeaderText = "ID";
                    dgvStatistics.Columns["meeting_date"].HeaderText = "Tanggal";
                    dgvStatistics.Columns["meeting_time"].HeaderText = "Waktu";
                    dgvStatistics.Columns["meeting_description"].HeaderText = "Deskripsi";
                    dgvStatistics.Columns["present"].HeaderText = "Hadir";
                    dgvStatistics.Columns["late"].HeaderText = "Terlambat";
                    dgvStatistics.Columns["absent"].HeaderText = "Absen";
                    dgvStatistics.Columns["izin"].HeaderText = "Izin";

                    dgvStatistics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data statistik: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Kembali ke Formmain
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
            this.Close();
        }
    }
}
