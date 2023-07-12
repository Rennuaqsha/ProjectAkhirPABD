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
    public partial class Lapangan : Form
    {
        private string stringConnection = "Data Source=DESKTOP-6I7FGSP\\NEMBOO;Initial Catalog=NanangFutsal;Persist Security Info=True;User ID=sa;Password=123";
        private SqlConnection koneksi;
        public Lapangan()
        {
            InitializeComponent();
        }

        private void Lapangan_Load(object sender, EventArgs e)
        {
            
        }
        private void refreshform()
        {
            txtLapId.Text = "";
            txtLapId.Enabled = false;
            cbxjenis.Text = "";
            cbxjenis.Enabled = false;
            txtNoLap.Text = "";
            txtNoLap.Enabled = false;
            txtharga.Text = "";
            txtharga.Enabled = false;
            Add.Enabled = true;
            Save.Enabled = false;
            Clear.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            txtLapId.Enabled = true;            
            cbxjenis.Enabled = true;            
            txtNoLap.Enabled = true;           
            txtharga.Enabled = true;
            Add.Enabled = true;
            Save.Enabled = true;
            Clear.Enabled = true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string LapanganId = txtLapId.Text.Trim();
            string JenisLapangan = cbxjenis.Text.Trim();
            string NomorLapangan = txtNoLap.Text.Trim();
            string Harga = txtharga.Text.Trim();

            if (LapanganId == "")
            {
                MessageBox.Show("Masukkan Lapangan id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (JenisLapangan == "")
            {
                MessageBox.Show("Masukkan Jenis Lapangan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (NomorLapangan == "")
            {
                MessageBox.Show("Masukkan Nomor Lapangan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Harga == "")
            {
                MessageBox.Show("Masukkan Harga", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                try
                {
                    using (SqlConnection koneksi = new SqlConnection(stringConnection))
                    {
                        koneksi.Open();
                        // Cek apakah data dengan lapangan_id yang sama sudah ada di database
                        string cekQuery = "SELECT COUNT(*) FROM Lapangan WHERE lapangan_id = @lapangan_id";
                        using (SqlCommand cekCmd = new SqlCommand(cekQuery, koneksi))
                        {
                            cekCmd.Parameters.AddWithValue("@lapangan_id", LapanganId);
                            int existingCount = (int)cekCmd.ExecuteScalar();

                            if (existingCount > 0)
                            {
                                MessageBox.Show("Lapangan ID sudah ada dalam database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        string str = "INSERT INTO Lapangan (lapangan_id, jenis_lapangan, no_lapangan, harga_sewa_perjam) VALUES (@lapangan_id, @jenis_lapangan, @no_lapangan, @harga_sewa_perjam)";
                        using (SqlCommand cmd = new SqlCommand(str, koneksi))
                        {
                            cmd.Parameters.Add("@lapangan_id", SqlDbType.Char, 10).Value = LapanganId;
                            cmd.Parameters.Add("@jenis_lapangan", SqlDbType.VarChar, 10).Value = JenisLapangan;
                            cmd.Parameters.Add("@no_lapangan", SqlDbType.Char, 2).Value = NomorLapangan;
                            cmd.Parameters.Add("@harga_sewa_perjam", SqlDbType.Money).Value = decimal.Parse(Harga);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Data Berhasil Disimpan", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView();
                    refreshform();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }


        }

        private void dataGridView()
        {
            try
            {
                using (SqlConnection koneksi = new SqlConnection(stringConnection))
                {
                    koneksi.Open();
                    string str = "SELECT lapangan_id, jenis_lapangan, no_lapangan, harga_sewa_perjam FROM Lapangan";
                    using (SqlDataAdapter da = new SqlDataAdapter(str, koneksi))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtLapId.Text = row.Cells["lapangan_id"].Value.ToString();
                cbxjenis.Text = row.Cells["jenis_lapangan"].Value.ToString();
                txtNoLap.Text = row.Cells["no_lapangan"].Value.ToString();
                txtharga.Text = row.Cells["harga_sewa_perjam"].Value.ToString();

                txtLapId.Enabled = false;
                cbxjenis.Enabled = false;
                txtNoLap.Enabled = false;
                txtharga.Enabled = false;
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
            Karyawan karyawan = new Karyawan();
            karyawan.Show();
            this.Hide();
        }
    }
}
