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
        private string stringConnection = "Data Source=NanangFutsal;Initial Catalog=Jaminan;Persist Security Info=True;User ID=sa;Password=123";
        private SqlConnection koneksi;
        private void refreshform()
        {
            txtjaminan.Text = "";
            txtjaminan.Enabled = false;
            txtjenis.Text = "";
            txtjenis.Enabled = false;
            txtcosId.Text = "";
            txtcosId.Enabled = false; 
            Add.Enabled = false;
            Save.Enabled = false;
            Clear.Enabled = false;
            Next.Enabled = false;
        }

        public Jaminan()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            txtjaminan.Text = "";
            txtjaminan.Enabled = false;
            txtjenis.Text = "";
            txtjenis.Enabled = false;
            txtcosId.Text = "";
            txtcosId.Enabled = false;
            Add.Enabled = false;
            Save.Enabled = false;
            Clear.Enabled = false;
            Next.Enabled = false;
        }

        private void dataGridView()
        {
            koneksi.Open();
            string str = "select jaminan_id, jenis_jaminan, customer_id,  from dbo.Jaminan";
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
                txtcosId.Text = row.Cells["customer_id"].Value.ToString();

                txtjaminan.Enabled = false;
                txtjenis.Enabled = false;
                txtcosId.Enabled = false;
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
            
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            refreshform();
        }
    }
}
