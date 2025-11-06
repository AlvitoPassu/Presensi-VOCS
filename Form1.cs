using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_Project
{
    public partial class Form1 : Form
    {
        private MySqlConnection koneksi;
        private string alamat;

        public Form1()
        {
            InitializeComponent();
            alamat = "server=localhost; database=db_choir; username=root; password=;";
            koneksi = new MySqlConnection(alamat);

            // Optional: agar password ditampilkan sebagai bintang
            txtPassword.PasswordChar = '•';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Username dan Password harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                koneksi.Open();
                string query = "SELECT * FROM tbl_admin WHERE username=@user AND password=@pass";
                MySqlCommand cmd = new MySqlCommand(query, koneksi);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();
                    koneksi.Close();

                    MessageBox.Show("Login berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Misalnya setelah login, buka form utama:
                    Formmain dashboard = new Formmain();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username atau password salah!", "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open)
                    koneksi.Close();
            }
        }
    }
}
