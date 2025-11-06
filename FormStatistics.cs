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
    public partial class FormStatistics : Form
    {
        public FormStatistics()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Tampilkan kembali form utama (yang jadi owner)
            if (this.Owner != null)
            {
                this.Owner.Show();
            }

            // Tutup form attendance
            this.Close();
        }
    }
}
