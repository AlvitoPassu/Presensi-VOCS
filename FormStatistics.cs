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

            // Bind DataGridView columns to DataTable fields
            dgvStatistics.AutoGenerateColumns = false;
            colDate.DataPropertyName = "meeting_date";
            colMeeting.DataPropertyName = "meeting_description";
            colPresent.DataPropertyName = "present";
            colLate.DataPropertyName = "late";
            colAbsent.DataPropertyName = "absent";
            colIzin.DataPropertyName = "izin";

            // Optional formatting
            colDate.DefaultCellStyle.Format = "yyyy-MM-dd";
        }

        private void FormStatistics_Load(object sender, EventArgs e)
        {
            dgvStatistics.AutoGenerateColumns = false;
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            try
            {
                string connStr = "server=localhost;database=db_choir;uid=root;pwd=;";
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Modifikasi query untuk mengambil kolom present, late, absent, dan izin
                    string query = @"
                        SELECT id, meeting_date, meeting_description, present, late, absent, izin
                        FROM tbl_attendance
                        ORDER BY meeting_date DESC";

                    var dt = new DataTable();
                    using (var da = new MySqlDataAdapter(query, conn))
                    {
                        da.Fill(dt);
                    }

                    // Metode EnsureCountColumns tidak lagi diperlukan karena query sudah mengambil data
                    // EnsureCountColumns(dt);

                    dgvStatistics.DataSource = dt;
                    dgvStatistics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (MySqlException mex)
            {
                MessageBox.Show("Kesalahan database: " + mex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // atau aksi lain yang diinginkan
        }

        private void EnsureCountColumns(DataTable dt)
        {
            // Add columns if they do not exist
            string[] columns = { "present", "late", "absent", "izin" };
            foreach (var col in columns)
            {
                if (!dt.Columns.Contains(col))
                {
                    dt.Columns.Add(col, typeof(int));
                }
            }

            // Set default value to 0 for all rows
            foreach (DataRow row in dt.Rows)
            {
                foreach (var col in columns)
                {
                    if (row.IsNull(col))
                    {
                        row[col] = 0;
                    }
                }
            }
        }
    }
}
