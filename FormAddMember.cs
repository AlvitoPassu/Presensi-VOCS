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
        private string alamat, query;

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
                // Cek apakah semua data sudah diisi
                if (txtFullName.Text != "" && txtRegistrationNumber.Text != "")
                {
                    // Query insert data
                    query = string.Format(
                        "INSERT INTO tbl_anggota (full_name, registration_number) VALUES ('{0}', '{1}')",
                        txtFullName.Text, txtRegistrationNumber.Text
                    );

                    // Eksekusi query
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();

                    // Cek hasil eksekusi
                    if (res == 1)
                    {
                        MessageBox.Show("Data anggota berhasil disimpan!",
                            "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Bersihkan input setelah berhasil
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
            }
        }
    }
}
