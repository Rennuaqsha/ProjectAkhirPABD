using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ProjectAkhirPABD
{
    public partial class Costumer : Form
    {
        private string stringConnection = "Data Source=DESKTOP-6I7FGSP\\NEMBOO;Initial Catalog=NanangFutsal;Persist Security Info=True;User ID=sa;Password=123";
        private SqlConnection koneksi;

        private void refreshform()
        {
            cosId.Text = "";
            cosId.Enabled = false;
            nmCos.Text = "";
            nmCos.Enabled = false;
            Almt.Text = "";
            Alamat.Enabled = false;
            NoTelp.Text = "";
            Add.Enabled = true;
            Save.Enabled = false;
            Clear.Enabled = false;
  

        }

        public Costumer()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            dataGridView();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Jaminan_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            cosId.Enabled = true;
            nmCos.Enabled = true;
            Almt.Enabled = true;
            NoTelp.Enabled = true;
            Add.Enabled = true;
            Save.Enabled = true;
            Clear.Enabled = true;
            

        }

        private void Save_Click(object sender, EventArgs e)
        {
            string CustomerId = cosId.Text.Trim();
            string NamaCustomer = nmCos.Text.Trim();
            string Alamat = Almt.Text.Trim();
            string NomorTelepon = NoTelp.Text.Trim();
            if (CustomerId == "")
            {
                MessageBox.Show("Masukkan Costumer id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (NamaCustomer == "")
            {
                MessageBox.Show("Masukkan Nama Anda", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Alamat == "")
            {
                MessageBox.Show("Masukkan Alamat Anda", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (NomorTelepon == "")
            {
                MessageBox.Show("Masukkan Nomor Telepon Anda", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO Customer (customer_id, nama_customer, alamat, no_telepon) VALUES (@customer_id, @nama_customer, @alamat, @no_telepon)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("customer_id", CustomerId));
                cmd.Parameters.Add(new SqlParameter("nama_customer", NamaCustomer));
                cmd.Parameters.Add(new SqlParameter("alamat", Alamat));
                cmd.Parameters.Add(new SqlParameter("no_telepon", NomorTelepon));
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
            string str = "select customer_Id, nama_customer, alamat, no_telepon from dbo.Customer";
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
                cosId.Text = row.Cells["customer_id"].Value.ToString();
                nmCos.Text = row.Cells["nama_customer"].Value.ToString();
                Alamat.Text = row.Cells["alamat"].Value.ToString();
                NoTelp.Text = row.Cells["no_telepon"].Value.ToString();

                cosId.Enabled = false;
                nmCos.Enabled = false;
                Alamat.Enabled = false;
                NoTelp.Enabled = false;
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
            Jaminan jaminan = new Jaminan();
            jaminan.Show();
            this.Hide();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string CustomerId = dataGridView1.SelectedRows[0].Cells["customer_id"].Value.ToString();

                    try
                    {
                        using (SqlConnection koneksi = new SqlConnection(stringConnection))
                        {
                            koneksi.Open();

                            // Hapus baris dari tabel "Customer"
                            string deleteQuery = "DELETE FROM Customer WHERE customer_id = @customer_id";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, koneksi))

                            {
                                deleteCmd.Parameters.AddWithValue("@customer_id", CustomerId);
                                deleteCmd.ExecuteNonQuery();
                            }
                                
                            MessageBox.Show("Data berhasil dihapus", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataGridView();
                            refreshform();
                        }
                            
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan saat menghapus data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        koneksi.Close();
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
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }
    }
}
