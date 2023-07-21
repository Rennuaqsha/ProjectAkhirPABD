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
    public partial class Karyawan : Form
    {
        private string stringConnection = "Data Source=DESKTOP-6I7FGSP\\NEMBOO;Initial Catalog=NanangFutsal;Persist Security Info=True;User ID=sa;Password=123";
        private SqlConnection koneksi;
        public Karyawan()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            LoadJaminan();
            dataGridView();

        }

        private void LoadJaminan()
        {
            try
            {
                koneksi.Open();
                string query = "SELECT jaminan_id FROM Jaminan";
                SqlCommand command = new SqlCommand(query, koneksi);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cbxjaminan.Items.Add(reader["jaminan_id"].ToString());
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
            txtKarId.Text = "";
            txtKarId.Enabled = false;
            txtnama.Text = "";
            txtnama.Enabled = false;
            txtjabatan.Text = "";
            txtjabatan.Enabled = false;
            cbxjaminan.Text = "";
            cbxjaminan.Enabled = false;
            cbxlapangan.Text = "";
            cbxlapangan.Enabled = false;
            Add.Enabled = true;
            Save.Enabled = false;
            Clear.Enabled = false;
        }

        private void Karyawan_Load(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            
            txtKarId.Enabled = true;           
            txtnama.Enabled = true;            
            txtjabatan.Enabled = true;                   
            cbxjaminan.Enabled = true;            
            cbxlapangan.Enabled = true;
            Add.Enabled = true;
            Save.Enabled = true;
            Clear.Enabled = true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string KaryawanId = txtKarId.Text.Trim();
            string NamaKaryawan = txtnama.Text.Trim();
            string Jabatan = txtjabatan.Text.Trim();           
            string Jaminan = cbxjaminan.Text.Trim();
            string LapanganId = cbxlapangan.Text.Trim();

            if (KaryawanId == "")
            {
                MessageBox.Show("Masukkan Karyawan id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (NamaKaryawan == "")
            {
                MessageBox.Show("Masukkan Nama Anda", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Jabatan == "")
            {
                MessageBox.Show("Masukkan jabatan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }          
            else if (Jaminan == "")
            {
                MessageBox.Show("Masukkan Jaminan Anda", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (LapanganId == "")
            {
                MessageBox.Show("Masukkan Lapangan Id Anda", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                koneksi.Open();
                string str = "INSERT INTO Karyawan (karyawan_id, nama_karyawan, jabatan, jaminan_id, lapangan_id) VALUES (@karyawan_id, @nama_karyawan, @jabatan, @jaminan_id, @lapangan_id)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("karyawan_id", KaryawanId));
                cmd.Parameters.Add(new SqlParameter("nama_karyawan", NamaKaryawan));
                cmd.Parameters.Add(new SqlParameter("jabatan", Jabatan));
                cmd.Parameters.Add(new SqlParameter("jaminan_id", Jaminan));
                cmd.Parameters.Add(new SqlParameter("lapangan_id", LapanganId));
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
            string str = "select karyawan_id, nama_karyawan, jabatan, jaminan_id, lapangan_id from dbo.Karyawan";
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
                txtKarId.Text = row.Cells["karyawan_id"].Value.ToString();
                txtnama.Text = row.Cells["nama_karyawan"].Value.ToString();
                txtjabatan.Text = row.Cells["jabatan"].Value.ToString();;
                cbxjaminan.Text = row.Cells["jaminan_id"].Value.ToString();
                cbxlapangan.Text = row.Cells["lapangan_id"].Value.ToString();

                txtKarId.Enabled = false;
                txtnama.Enabled = false;
                txtjabatan.Enabled = false;
                cbxjaminan.Enabled = false;
                cbxlapangan.Enabled = false;
                Add.Enabled = false;
                Save.Enabled = false;
                Clear.Enabled = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            StatusKaryawan statusKaryawan = new StatusKaryawan();
            statusKaryawan.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Lapangan lapangan = new Lapangan();
            lapangan.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string KaryawanId = dataGridView1.SelectedRows[0].Cells["karyawan_id"].Value.ToString();

                    try
                    {
                        using (SqlConnection koneksi = new SqlConnection(stringConnection))
                        {
                            koneksi.Open();

                            // Hapus baris dari tabel "Karyawan"
                            string deleteQuery = "DELETE FROM Karyawan WHERE karyawan_id = @karyawan_id";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, koneksi))
                            {
                                deleteCmd.Parameters.AddWithValue("@karyawan_id", KaryawanId);
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
