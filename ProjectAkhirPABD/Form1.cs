using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAkhirPABD
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pendaftaranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Costumer costumer = new Costumer();
            costumer.Show();
            this.Hide();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            Costumer costumer = new Costumer();
            costumer.Show();
            this.Hide();
        }

        private void jaminanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Jaminan jaminan = new Jaminan();
            jaminan.Show();
            this.Hide();
        }

        private void karyawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Karyawan karyawan = new Karyawan();
            karyawan.Show();
            this.Hide();
        }

        private void statusKaryawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatusKaryawan statusKaryawan = new StatusKaryawan();
            statusKaryawan.Show();
            this.Hide();
        }

        private void lapanganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lapangan lapangan = new Lapangan();
            lapangan.Show();
            this.Hide();
        }

        private void pembayaranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pembayaran pembayaran = new Pembayaran();
            pembayaran.Show();
            this.Hide();
        }
    }
}
