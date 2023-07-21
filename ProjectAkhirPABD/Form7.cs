using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAkhirPABD
{
    public partial class Pembayaran : Form
    {
        private string stringConnection = "Data Source=DESKTOP-6I7FGSP\\NEMBOO;Initial Catalog=NanangFutsal;Persist Security Info=True;User ID=sa;Password=123";
        private SqlConnection koneksi;
        public Pembayaran()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
            LoadKaryawan();
            LoadCustomers();
            dataGridView();
        }

        private void Pembayaran_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadKaryawan()
        {

            try
            {
                koneksi.Open();
                string query = "SELECT karyawan_id FROM Karyawan";
                SqlCommand command = new SqlCommand(query, koneksi);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox3.Items.Add(reader["karyawan_id"].ToString());
                }

                reader.Close();
                koneksi.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadCustomers()
        {
            try
            {
                koneksi.Open();
                string query = "SELECT customer_id FROM Customer";
                SqlCommand command = new SqlCommand(query, koneksi);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["customer_id"].ToString());
                }

                reader.Close();
                koneksi.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




        private void refreshform()
        {
            textBox1.Text = "";
            textBox1.Enabled = false;
            comboBox1.Text = "";
            comboBox1.Enabled = false;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Enabled = false;
            textBox2.Text = "";
            textBox2.Enabled = false;
            textBox3.Text = "";
            textBox3.Enabled = false;
            comboBox2.Text = "";
            comboBox2.Enabled = false;
            comboBox3.Text = "";
            comboBox3.Enabled = false;
        }

        private void Home_Click(object sender, EventArgs e)
        {
            HomePage fm = new HomePage();
            fm.Show();
            this.Hide();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            comboBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            Save.Enabled = true;
            Clear.Enabled = true;
            Home.Enabled = true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string Idbayar = textBox1.Text.Trim();
            string jnsPembayaran = comboBox1.Text.Trim();
            string TglTransaksi = dateTimePicker1.Value.ToString();
            string JmlahPem = textBox2.Text.Trim();
            string lmSewa = textBox3.Text.Trim();
            string CosId = comboBox2.Text.Trim();
            string KrywnId = comboBox3.Text.Trim();
            if (Idbayar == "")
            {
                MessageBox.Show("Masukkan Id Pembayaran", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (jnsPembayaran == "")
            {
                MessageBox.Show("Masukkan Jenis Pembayaran", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (TglTransaksi == "")
            {
                MessageBox.Show("Masukkan Tanggal Transaksi", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (JmlahPem == "")
            {
                MessageBox.Show("Masukkan Jumlah Pembayaran", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (lmSewa == "")
            {
                MessageBox.Show("Masukkan Lama Sewa", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CosId == "")
            {
                MessageBox.Show("Masukkan Costumer Id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (KrywnId == "")
            {
                MessageBox.Show("Masukkan Karyawan Id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    koneksi.Open();

                    string cekQuery = "SELECT COUNT(*) FROM Pembayaran WHERE id_pembayaran = @id_pembayaran";
                    using (SqlCommand cekCmd = new SqlCommand(cekQuery, koneksi))
                    {
                        cekCmd.Parameters.AddWithValue("@id_pembayaran", Idbayar);
                        int existingCount = (int)cekCmd.ExecuteScalar();

                        if (existingCount > 0)
                        {
                            MessageBox.Show("ID Pembayaran sudah ada dalam database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string str = "INSERT INTO Pembayaran (id_pembayaran, jenis_pembayaran, tanggal_pembayaran, jumlah_pembayaran, lama_sewa, customer_id, karyawan_id) VALUES (@id_pembayaran, @jenis_pembayaran, @tanggal_pembayaran, @jumlah_pembayaran, @lama_sewa, @customer_id, @karyawan_id)";
                    using (SqlCommand cmd = new SqlCommand(str, koneksi))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@id_pembayaran", Idbayar));
                        cmd.Parameters.Add(new SqlParameter("@jenis_pembayaran", jnsPembayaran));
                        cmd.Parameters.Add(new SqlParameter("@tanggal_pembayaran", TglTransaksi));
                        cmd.Parameters.Add(new SqlParameter("@jumlah_pembayaran", JmlahPem));
                        cmd.Parameters.Add(new SqlParameter("@lama_sewa", lmSewa));
                        cmd.Parameters.Add(new SqlParameter("@customer_id", CosId));
                        cmd.Parameters.Add(new SqlParameter("@karyawan_id", KrywnId));
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data Berhasil Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshform();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    koneksi.Close();
                }
                dataGridView();
            }

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            refreshform();

        }

        private void dataGridView()
        {
            koneksi.Open();
            string str = "select id_pembayaran, jenis_pembayaran, tanggal_pembayaran, jumlah_pembayaran, lama_sewa, customer_id, karyawan_id FROM dbo.Pembayaran";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["id_pembayaran"].Value.ToString();
                comboBox1.Text = row.Cells["jenis_pembayaran"].Value.ToString();
                dateTimePicker1.Text = row.Cells["tanggal_pembayaran"].Value.ToString();
                textBox2.Text = row.Cells["jumlah_pembayaran"].Value.ToString();
                textBox3.Text = row.Cells["lama_sewa"].Value.ToString();
                comboBox2.Text = row.Cells["=customer_id"].Value.ToString();
                comboBox3.Text = row.Cells["=karyawan_id"].Value.ToString();

                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                Add.Enabled = false;
                Save.Enabled = false;
                Clear.Enabled = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string IdPembayaran = dataGridView1.SelectedRows[0].Cells["id_pembayaran"].Value.ToString();

                    try
                    {
                        using (SqlConnection koneksi = new SqlConnection(stringConnection))
                        {
                            koneksi.Open();

                            // Hapus baris dari tabel "Pembayaran"
                            string deleteQuery = "DELETE FROM Pembayaran WHERE id_pembayaran = @id_pembayaran";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, koneksi))
                            {
                                deleteCmd.Parameters.AddWithValue("@id_pembayaran", IdPembayaran);
                                deleteCmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView();
                        refreshform();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan saat menghapus data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang akan dihapus", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StatusKaryawan statkaryawan = new StatusKaryawan();
            statkaryawan.Show();
            this.Hide();
        }
    }
}


