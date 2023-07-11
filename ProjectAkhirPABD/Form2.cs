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

namespace ProjectAkhirPABD
{
    public partial class Costumer : Form
    {
        private string stringConnection = "Data Source=NanangFutsal;Initial Catalog=Customer;Persist Security Info=True;User ID=sa;Password=123";
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
            Next.Enabled = false;
        }

        public Costumer()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
            dataGridView1.CellClick += DataGridView1_CellClick;
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
            Next.Enabled = true;

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
                MessageBox.Show("Masukkan Nama Anda", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (NomorTelepon == "")
            {
                MessageBox.Show("Masukkan Nama Anda", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                Alamat.Text = row.Cells["no_telepon"].Value.ToString();

                nmCos.Enabled = false;
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
    }
}
