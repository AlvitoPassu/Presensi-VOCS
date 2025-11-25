using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;

namespace Final_Project
{
    public partial class ListMember : Form
    {
        public ListMember()
        {
            InitializeComponent();
        }

        private void ListMember_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=localhost; database=db_choir; username=root; password=;";
                using (MySqlConnection koneksi = new MySqlConnection(connectionString))
                {
                    koneksi.Open();
                    string query = "SELECT * FROM tbl_anggota";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, koneksi))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds, "tbl_anggota");

                        CrystalReport1 rpt = new CrystalReport1();
                        rpt.SetDataSource(ds.Tables["tbl_anggota"]);
                        crystalReportViewer1.ReportSource = rpt;
                        crystalReportViewer1.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void crystalReport11_InitReport(object sender, EventArgs e)
        {

        }
    }
}
