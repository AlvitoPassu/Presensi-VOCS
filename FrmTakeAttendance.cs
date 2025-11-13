using System;
using System.Windows.Forms;

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
            // Kosong dulu - nanti bisa ditambah logika load jadwal dsb
        }

        private void btnStartAttendance_Click(object sender, EventArgs e)
        {
            // Arahkan ke FrmCam
            FrmCam frmCam = new FrmCam();
            frmCam.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Kembali ke form sebelumnya (bisa disesuaikan)
            this.Close();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            // Kosong dulu
        }

        private void cmbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kosong dulu
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            // Kosong dulu
        }
    }
}
