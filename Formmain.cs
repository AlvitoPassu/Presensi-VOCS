using ChoirMemberApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Formmain : Form
    {
        public Formmain()
        {
            InitializeComponent();
        }

        private void btnTakeAttendance_Click(object sender, EventArgs e)
        {
            // Membuat instance dari form FrmTakeAttendance
            FrmTakeAttendance takeAttendanceForm = new FrmTakeAttendance();
            takeAttendanceForm.Owner = this;  // simpan referensi form utama

            // Menampilkan FrmTakeAttendance
            takeAttendanceForm.Show();

            // Sembunyikan form utama sementara
            this.Hide();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            // Membuat instance dari form FormAddMember
            FormAddMember formAddMember = new FormAddMember();

            // Menampilkan FormAddMember
            formAddMember.Show();

            // Opsional: sembunyikan form utama sementara
            this.Hide();

            // Ketika FormAddMember ditutup, tampilkan kembali Formmain
            formAddMember.FormClosed += (s, args) => this.Show();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            // Buat instance dari form statistik
            FormStatistics statisticsForm = new FormStatistics();

            // Simpan referensi ke form utama
            statisticsForm.Owner = this;

            // Tampilkan FormStatistics
            statisticsForm.Show();

            // Sembunyikan form utama sementara
            this.Hide();

            // Saat FormStatistics ditutup, tampilkan kembali form utama
            statisticsForm.FormClosed += (s, args) => this.Show();
        }

        private void btnMemberList_Click(object sender, EventArgs e)
        {

        }

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
