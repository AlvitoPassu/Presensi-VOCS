using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ChoirMemberApp
{
    public partial class FormAddMember : Form
    {
        private MySqlConnection koneksi;
        private MySqlCommand perintah;
        private string alamat;

        public FormAddMember()
        {
            alamat = "server=localhost; database=db_choir; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void FormAddMember_Load(object sender, EventArgs e)
        {
            // Bersihkan input saat form pertama kali dibuka
            txtFullName.Clear();
            txtRegistrationNumber.Clear();
            txtFullName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtFullName.Text) &&
                    !string.IsNullOrEmpty(txtRegistrationNumber.Text))
                {
                    string query = "INSERT INTO tbl_anggota (full_name, registration_number) VALUES (@name, @reg)";

                    koneksi.Open();

                    perintah = new MySqlCommand(query, koneksi);
                    perintah.Parameters.AddWithValue("@name", txtFullName.Text);
                    perintah.Parameters.AddWithValue("@reg", txtRegistrationNumber.Text);

                    int res = perintah.ExecuteNonQuery();

                    koneksi.Close();

                    if (res == 1)
                    {
                        MessageBox.Show("Data anggota berhasil disimpan!",
                            "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Bersihkan input
                        FormAddMember_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal menyimpan data.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lengkapi semua data terlebih dahulu.",
                        "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (koneksi.State == ConnectionState.Open)
                    koneksi.Close();
            }
        }
    }
}
