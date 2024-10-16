using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityUrunler
{
    public partial class FrmGiriş : Form
    {
        public FrmGiriş()
        {
            InitializeComponent();
        }

        private void FrmGiriş_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbEntityUrunEntities ds = new DbEntityUrunEntities();

            var sorgu = from x in ds.Tbl_Admin where x.Kullanici == textBox1.Text && x.Sifre == textBox2.Text select x;

            if (sorgu.Any())
            {
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Yanlış Yada Eksik Bilgi Girişi Lütfen Tekrar Deneyin!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
