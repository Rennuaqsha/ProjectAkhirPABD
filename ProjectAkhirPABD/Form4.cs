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

        private void LoadLapangan()
        {
            try
            {
                koneksi.Open();
                string query = "SELECT lapangan_id FROM Lapangan";
                SqlCommand command = new SqlCommand(query, koneksi);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cbxLapangan.Items.Add(reader["lapangan_id"].ToString());
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
            txtgaji.Text = "";
            txtgaji.Enabled = false;
            cbxjaminan.Text = "";
            cbxjaminan.Enabled = false;
            cbxLapangan.Text = "";
            cbxLapangan.Enabled = false;
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
            txtgaji.Enabled = true;          
            cbxjaminan.Enabled = true;            
            cbxLapangan.Enabled = true;
            Add.Enabled = true;
            Save.Enabled = true;
            Clear.Enabled = true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string KaryawanId = txtKarId.Text.Trim();
            string NamaKaryawan = txtnama.Text.Trim();
            string Jabatan = txtjabatan.Text.Trim();
            string Gaji = txtgaji.Text.Trim();
            string Jaminan = cbxjaminan.Text.Trim();
            string LapanganId = cbxLapangan.Text.Trim();

            if (KaryawanId == "")
            {
                MessageBox.Show("Masukkan Costumer id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (NamaKaryawan == "")
            {
                MessageBox.Show("Masukkan Nama Anda", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Jabatan == "")
            {
                MessageBox.Show("Masukkan Nama Anda", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Gaji == "")
            {
                MessageBox.Show("Masukkan Nama Anda", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Jaminan == "")
            {
                MessageBox.Show("Masukkan Nama Anda", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (LapanganId == "")
            {
                MessageBox.Show("Masukkan Nama Anda", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                koneksi.Open();
                string str = "INSERT INTO Karyawan (karyawan_id, nama_karyawan, jabatan, gaji, jaminan_id, lapangan_id) VALUES (@karyawan_id, @nama_karyawan, @jabatan, @gaji, @jaminan_id, @lapangan_id)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("karyawan_id", KaryawanId));
                cmd.Parameters.Add(new SqlParameter("nama_karyawan", NamaKaryawan));
                cmd.Parameters.Add(new SqlParameter("jabatan", Jabatan));
                cmd.Parameters.Add(new SqlParameter("gaji", Gaji));
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
            string str = "select karyawan_id, nama_karyawan, jabatan, gaji, jaminan_id, lapangan_id from dbo.Karyawan";
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
                txtjabatan.Text = row.Cells["jabatan"].Value.ToString();
                txtgaji.Text = row.Cells["gaji"].Value.ToString();
                cbxjaminan.Text = row.Cells["jaminan_id"].Value.ToString();
                cbxLapangan.Text = row.Cells["lapangan_id"].Value.ToString();

                txtKarId.Enabled = false;
                txtnama.Enabled = false;
                txtjabatan.Enabled = false;
                txtgaji.Enabled = false;
                cbxjaminan.Enabled = false;
                cbxLapangan.Enabled = false;
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
    }
}
