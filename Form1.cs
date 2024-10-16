using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.SqlServer;

namespace EntityUrunler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db=new DbEntityUrunEntities();
        TblKategori name = new TblKategori();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TblKategori.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TblKategori.ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();


        }

        private void btnekle_Click(object sender, EventArgs e)
        {            
            name.AD=txtad.Text;
            db.TblKategori.Add(name);
            db.SaveChanges();
            dataGridView1.DataSource = db.TblKategori.ToList();
            MessageBox.Show("Kategori eklendi.","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var bul = db.TblKategori.Find(x);
            db.TblKategori.Remove(bul);
            db.SaveChanges();
            dataGridView1.DataSource = db.TblKategori.ToList();
            MessageBox.Show("Kategori Silindi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int z= Convert.ToInt32(txtid.Text);
            var bak = db.TblKategori.Find(z);
            bak.AD = txtad.Text;
            db.SaveChanges();
            dataGridView1.DataSource = db.TblKategori.ToList();
            MessageBox.Show("Kategori Güncellendi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


    }
}
