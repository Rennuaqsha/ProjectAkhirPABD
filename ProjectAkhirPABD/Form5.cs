using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAkhirPABD
{
    public partial class StatusKaryawan : Form
    {
        private string stringConnection = "Data Source=DESKTOP-6I7FGSP\\NEMBOO;Initial Catalog=NanangFutsal;Persist Security Info=True;User ID=sa;Password=123";
        private SqlConnection koneksi;

        public StatusKaryawan()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            LoadKaryawan();
            dataGridView();

        }

        private void refreshform()
        {
            txtStatId.Text = "";
            txtStatId.Enabled = false;
            cbxJenis.Text = "";
            cbxJenis.Enabled = false;
            cbxKarId.Text = "";
            cbxKarId.Enabled = false;
            Add.Enabled = false;
            Save.Enabled = false;
          
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
                    cbxKarId.Items.Add(reader["karyawan_id"].ToString());
                }

                reader.Close();
                koneksi.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void StatusKaryawan_Load(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            txtStatId.Enabled = true;
            cbxJenis.Enabled = true;
            cbxKarId.Enabled = true;
            Add.Enabled = true; 
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string Statusid = txtStatId.Text.Trim();
            string JenisKaryawan = cbxJenis.Text.Trim();
            string KaryawanId = cbxKarId.Text.Trim();

            if (Statusid == "")
            {
                MessageBox.Show("Masukkan status Id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (JenisKaryawan == "")
            {
                MessageBox.Show("Masukkan Jenis Karyawan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (KaryawanId == "")
            {
                MessageBox.Show("Masukkan karyawan Id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                koneksi.Open();
                string str = "INSERT INTO StatusKaryawan (status_id, jenis_karyawan, karyawan_id) VALUES (@status_id, @jenis_karyawan, @karyawan_id)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("status_id", Statusid));
                cmd.Parameters.Add(new SqlParameter("jenis_karyawan", JenisKaryawan));
                cmd.Parameters.Add(new SqlParameter("karyawan_id", KaryawanId));
                cmd.ExecuteNonQuery();
                koneksi.Close();

                MessageBox.Show("Data Berhasil Disimpan", "succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshform();
            }

        }

        private void dataGridView()
        {
            koneksi.Open();
            string str = "select status_id, jenis_karyawan, karyawan_id from dbo.StatusKaryawan";
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
                txtStatId.Text = row.Cells["status_id"].Value.ToString();
                cbxJenis.Text = row.Cells["jenis_karyawan"].Value.ToString();
                cbxKarId.Text = row.Cells["karyawan_id"].Value.ToString();

               txtStatId.Enabled = false;
                cbxJenis.Enabled = false;
                cbxKarId.Enabled = false;
               
                Add.Enabled = false;
                Save.Enabled = false;
                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Next_Click(object sender, EventArgs e)
        {
            Pembayaran pembayaran = new Pembayaran();
            pembayaran.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Karyawan karyawan = new Karyawan();
            karyawan.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string StatusId = dataGridView1.SelectedRows[0].Cells["status_id"].Value.ToString();

                    try
                    {
                        using (SqlConnection koneksi = new SqlConnection(stringConnection))
                        {
                            koneksi.Open();

                            // Hapus baris dari tabel "StatusKaryawan"
                            string deleteQuery = "DELETE FROM StatusKaryawan WHERE status_id = @status_id";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, koneksi))
                            {
                                deleteCmd.Parameters.AddWithValue("@status_id", StatusId);
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
    }
}

