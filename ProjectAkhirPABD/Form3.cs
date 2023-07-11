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
    public partial class Jaminan : Form
    {
        private string stringConnection = "Data Source=DESKTOP-6I7FGSP\\NEMBOO;Initial Catalog=NanangFutsal;Persist Security Info=True;User ID=sa;Password=123";
        private SqlConnection koneksi;
        private void refreshform()
        {
            txtjaminan.Text = "";
            txtjaminan.Enabled = false;
            txtjenis.Text = "";
            txtjenis.Enabled = false;
            cbxCosId.Text = "";
            cbxCosId.Enabled = false; 
            Add.Enabled = true;
            Save.Enabled = false;
            Clear.Enabled = false;
        }

        public Jaminan()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            LoadCustomers();
        }


        private void Add_Click(object sender, EventArgs e)
        {
            txtjaminan.Enabled = true;
            txtjenis.Enabled = true;
            cbxCosId.Enabled = true;
            Save.Enabled = true;
            Clear.Enabled = true;
        }

        private void dataGridView()
        {
            koneksi.Open();
            string str = "select jaminan_id, jenis_jaminan, customer_id from dbo.Jaminan";
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
                txtjaminan.Text = row.Cells["jaminan_id"].Value.ToString();
                txtjenis.Text = row.Cells["jenis_jaminan"].Value.ToString();
                cbxCosId.Text = row.Cells["customer_id"].Value.ToString();

                txtjaminan.Enabled = false;
                txtjenis.Enabled = false;
                cbxCosId.Enabled = false;
                Add.Enabled = false;
                Save.Enabled = false;
                Clear.Enabled = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            string JaminanId = txtjaminan.Text.Trim();
            string JenisJaminan = txtjenis.Text.Trim();
            string CustomerId = cbxCosId.Text.Trim();

            if (JaminanId == "")
            {
                MessageBox.Show("Masukkan Costumer id", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (JenisJaminan == "")
            {
                MessageBox.Show("Masukkan Nama Anda", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (CustomerId == "")
            {
                MessageBox.Show("Masukkan Nama Anda", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                koneksi.Open();
                string str = "INSERT INTO Jaminan (jaminan_id, jenis_jaminan, customer_id) VALUES (@jaminan_id, @jenis_jaminan, @customer_id)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("jaminan_id", JaminanId));
                cmd.Parameters.Add(new SqlParameter("jenis_jaminan", JenisJaminan));
                cmd.Parameters.Add(new SqlParameter("customer_id", CustomerId));
                cmd.ExecuteNonQuery();
                koneksi.Close();

                MessageBox.Show("Data Berhasil Disimpan", "succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshform();
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
                    cbxCosId.Items.Add(reader["customer_id"].ToString());
                }

                reader.Close();
                koneksi.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            refreshform();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            Lapangan lapangan = new Lapangan();
            lapangan.Show();
            this.Hide();
        }
    }
}
