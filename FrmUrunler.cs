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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities ds=new DbEntityUrunEntities();
        TblKategori tkg = new TblKategori();


        #region FORM LOAD TASK
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ( from x in ds.TblUrun 
                                        select new
                                        {
                                            x.UrunId,
                                            x.UrunAd,
                                            x.Marka,
                                            x.Stok,
                                            x.Fiyat,
                                            x.Durum,
                                            x.TblKategori.AD,
                                        } ).ToList();


            cmbkategori.DisplayMember = "AD";
            cmbkategori.ValueMember = "ID";
            cmbkategori.DataSource = ds.TblKategori.ToList();
        }
        #endregion

        #region DATAGRİD CELL DOUBLE CLİCK TASK
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtmarka.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtstokadet.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtfiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            cmbkategori.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }
        #endregion

        private void cmbkategori_SelectedIndexChanged(object sender, EventArgs e)
        {    

        }

        #region INSERT BUTTON TASK
        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                TblUrun tk = new TblUrun();
                tk.UrunAd = txtad.Text;
                tk.Marka = txtmarka.Text;
                tk.Fiyat = decimal.Parse(txtfiyat.Text);
                tk.Stok = int.Parse(txtstokadet.Text);
                tk.Fiyat = decimal.Parse(txtfiyat.Text);
                tk.Durum = true;
                tk.KategoriId = int.Parse(cmbkategori.SelectedValue.ToString());
                ds.TblUrun.Add(tk);
                ds.SaveChanges();
                MessageBox.Show("Ürün Kaydedildi!!!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch 
            {
                MessageBox.Show("Hatalı yada Eksik Veri Girişi yaptınız.ütfen Kontrol Ediniz","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }
        #endregion

        #region LİST BUTTON TASK
        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in ds.TblUrun
                                        select new
                                        {
                                            x.UrunId,
                                            x.UrunAd,
                                            x.Marka,
                                            x.Stok,
                                            x.Fiyat,
                                            x.Durum,
                                            x.TblKategori.AD,
                                        }).ToList();
        }
        #endregion

        #region REMOVE BUTTON TASK

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(txtid.Text);
                var krt = ds.TblUrun.Find(x);
                ds.TblUrun.Remove(krt);
                ds.SaveChanges();
                MessageBox.Show("Ürün Silindi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch
            {
                MessageBox.Show("Hatalı yada Eksik Veri Girişi yaptınız.ütfen Kontrol Ediniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        #region UPDATE TASK
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(txtid.Text);
                var kr = ds.TblUrun.Find(x);
                kr.UrunAd = txtad.Text;
                kr.Marka = txtmarka.Text;
                kr.Stok = int.Parse(txtstokadet.Text);
                kr.Fiyat = decimal.Parse(txtfiyat.Text);
                kr.KategoriId = int.Parse(cmbkategori.SelectedValue.ToString());
                ds.SaveChanges();
                MessageBox.Show("Ürün Güncellendi!!!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Hatalı yada Eksik Veri Girişi yaptınız.Lütfen Kontrol Ediniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion



    }
}
