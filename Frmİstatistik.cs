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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db=new DbEntityUrunEntities();
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.TblKategori.Count().ToString();
            label3.Text=db.TblUrun.Count().ToString();
            label13.Text=db.TblUrun.Count().ToString();
            label5.Text=db.TblMusteri.Count( x =>x.Durum==true).ToString();
            label7.Text=db.TblMusteri.Count( x =>x.Durum==false).ToString();
            label13.Text=db.TblUrun.Sum(x=>x.Stok).ToString();
            label21.Text=db.TblSatis.Sum(x=>x.Fiyat).ToString()+   " TL";
            label11.Text=(from  x in db.TblUrun orderby x.Fiyat descending select x.UrunAd).FirstOrDefault();
            label9.Text=(from  x in db.TblUrun orderby x.Fiyat ascending select x.UrunAd).FirstOrDefault();
            label15.Text=db.TblUrun.Count(x=>x.KategoriId==1).ToString();
            label17.Text=db.TblUrun.Count(x=>x.UrunAd=="Buzdolabi").ToString();
            label23.Text=(from x in db.TblMusteri select x.Sehir).Distinct().Count().ToString();
            label19.Text=db.Markagetir().FirstOrDefault().ToString().ToUpper();
        }
    }
}
