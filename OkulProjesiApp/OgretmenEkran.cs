using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OkulApp.Models;
using OkulApp.BLL;
using System.Data.SqlClient;
using System.IO;
using UtilityLib;

namespace OkulProjesiApp
{
    public partial class OgretmenEkran : Form
    {
        public int ogrenciid = 0;
        public int veliid = 0;
        DataTable dt, dt1, dt2, dt3, dt4, dt5, dt6, dt7, dt8 = null;

        public OgretmenEkran()
        {
            InitializeComponent();
            grdOgrenciler.AutoGenerateColumns = false;
            grdOgretmen.AutoGenerateColumns = false;
            dataDersler.AutoGenerateColumns = false;
            grdBilgiOgrenci.AutoGenerateColumns = false;
            grdNotlar.AutoGenerateColumns = false;
            grdDersler.AutoGenerateColumns = false;
            grdBilgiOgrenci.AutoGenerateColumns = false;
            dtOgrSifreler.AutoGenerateColumns = false;
            dtYetkiliSifre.AutoGenerateColumns = false;
        }
        private void BtnDuzenle_Click(object sender, EventArgs e)
        {
            AnaGiris frm = new AnaGiris();
            frm.Show();
            this.Close();
        }
        private void OgretmenEkran_Load(object sender, EventArgs e)
        {
            OgrenciListele();
            SinifYukle();
            ((DataGridViewComboBoxColumn)grdOgrenciler.Columns["clmSinifId"]).DisplayMember = "SinifAdi";
            ((DataGridViewComboBoxColumn)grdOgrenciler.Columns["clmSinifId"]).ValueMember = "SinifId";
            ((DataGridViewComboBoxColumn)grdOgrenciler.Columns["clmSinifId"]).DataSource = SinifBL.SinifGrup();
        }
        private void BtnOgrenciKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Ogrenci o = new Ogrenci();
                o.Ad = txtAdOgrenci.Text.Trim().ToUpper();
                o.Soyad = txtSoyadOgrenci.Text.Trim().ToUpper();
                o.SinifId = (int)cmbSinif.SelectedValue;
                o.OkulNo = txtOkulNo.Text.Trim();
                o.TCKimlikNo = txtTCogrenci.Text.Trim();
                o.Resim = txtResim.Text;
                o.VeliAd = txtVeliAd.Text.Trim().ToUpper();
                o.VeliSoyad = txtVeliSoyad.Text.Trim().ToUpper();
                o.Adres = txtAdresVeli.Text.Trim().ToUpper();
                o.Tel = txtTelVeli.Text.Trim().ToUpper();
                o.Sifre = txtSifre.Text.Trim();

                bool sonuc2 = OgrenciBL.OgrenciEkleme(o);

                if (sonuc2)
                {
                    MessageBox.Show("Öğrenci Kayıt Başarılı");
                    OgrenciListele();
                    Utility.CleanTextBoxes(grpOgrenciBilgileri.Controls);
                    Utility.CleanTextBoxes(grpVeliBilgileri.Controls);
                    pcbOgrenci.Image = Properties.Resources.indir;
                }
                else
                {
                    MessageBox.Show("Öğrenci Kayıt Başarısız!!");
                }


            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        if (ex.Message.Contains("TCKimlikNo"))
                        {
                            MessageBox.Show("Bu TC Kimlik numarası zaten kayıtlı!!" + ex.Number);
                        }
                        else
                        {
                            MessageBox.Show("Bu Öğrenci numarası zaten kayıtlı!!" + ex.Number);
                        }
                        break;
                    default:
                        MessageBox.Show("Veritabanı Hatası!!" + ex.Number);
                        break;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Bilinmeyen Hata!!");
            }
            #region MyRegion
            //try
            //{
            //    Ogrenci o = new Ogrenci();
            //    o.Ad = txtAdOgrenci.Text.Trim().ToUpper();
            //    o.Soyad = txtSoyadOgrenci.Text.Trim().ToUpper();
            //    o.TCKimlikNo = txtTCogrenci.Text.Trim();
            //    o.OkulNo = txtOkulNo.Text.Trim();
            //    o.Resim = txtResim.Text;
            //    o.SinifId = (int)cmbSinif.SelectedValue;


            //    bool sonuc = OgrenciBL.OgrenciEkleme(o);
            //    if (sonuc)
            //    {
            //        MessageBox.Show("Öğrenci Kaydı Başarılı");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Öğrenci Kaydı Başarısız!!");
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    switch (ex.Number)
            //    {
            //        case 2627:
            //            if (ex.Message.Contains("TCKimlikNo"))
            //            {
            //                MessageBox.Show("Bu TC Kimlik numarası zaten kayıtlı!!" + ex.Number, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            }
            //            else
            //            {
            //                MessageBox.Show("Bu Öğrenci numarası zaten kayıtlı!!" + ex.Number, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            }
            //            break;
            //        default:
            //            MessageBox.Show("Veritabanı Hatası!!" + ex.Number);
            //            break;
            //    }
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Bilinmeyen Hata!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //} 
            #endregion
        }
        void OgrenciListele()
        {
            dt = OgrenciBL.OgrenciListele();
            grdOgrenciler.DataSource = dt;


        }
        void OgrencileriGetir()
        {
            dt6 = OgrenciBL.OgrencileriGoster();
            grdBilgiOgrenci.DataSource = dt6;

        }
        void NotlarListele()
        {
            dt1 = NotlarBL.NotlarListesi();
            grdNotlar.DataSource = dt1;
        }
        void DersListele()
        {
            dt2 = DerslerBL.DersListesi();
            dataDersler.DataSource = dt2;

        }
        void Dersler()
        {
            dt5 = DerslerBL.DersleriGoster();
            grdDersler.DataSource = dt5;
            grdBilgiDers.DataSource = dt5;
        }
        void SinifYukle()
        {
            cmbSinif.DisplayMember = "SinifAdi";
            cmbSinif.ValueMember = "SinifId";
            cmbBulSinif.DisplayMember = "SinifAdi";
            cmbBulSinif.ValueMember = "SinifId";
            cmbBulSinif.DataSource = SinifBL.SinifListesi();
            cmbSinif.DataSource = SinifBL.SinifListesi();
        }
        void SinifListele()
        {
            dt3 = SinifBL.SinifListesi();
            grdSinif2.DataSource = dt3;
        }
        void OgretmenListele()
        {
            dt4 = OgretmenBL.OgretmenListele();
            grdOgretmen.DataSource = dt4;

        }
        void SifreleriListele()
        {
            dt7 = SifreOgretmenBL.OgrSfrListele();
            dt8 = SifreOgretmenBL.YetkSfrListele();
            dtOgrSifreler.DataSource = dt7;
            dtYetkiliSifre.DataSource = dt8;
        }
        private void grdOgrenci_SelectedIndexChanged(object sender, EventArgs e)
        {
            DersListele();
            Dersler();
            SinifListele();
            OgretmenListele();
            NotlarListele();
            OgrencileriGetir();
            SifreleriListele();
            Utility.CleanTextBoxes(grpOgrenciBilgileri.Controls);
            Utility.CleanTextBoxes(grpVeliBilgileri.Controls);
        }
        private void BtnEkraniSil_Click(object sender, EventArgs e)
        {
            Utility.CleanTextBoxes(grpOgrenciBilgileri.Controls);
            Utility.CleanTextBoxes(grpVeliBilgileri.Controls);
            Utility.CleanTextBoxes(grpSifre.Controls);
            Utility.CleanTextBoxes(grpSınıfBilg.Controls);
            Utility.CleanTextBoxes(grpOgrenciBilgileri.Controls);
            Utility.CleanTextBoxes(grpNotEkleme.Controls);
            pcbOgrenci.Image = Properties.Resources.indir;
        }
        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Öğrenci ve Veli Bilgilerini Silmek İstediğinizden Emin Misiniz??", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Ogrenci o = new Ogrenci();
                    o.OgrenciId = Convert.ToInt32(txtogrenciIdGelen.Text);
                    bool sonuc = OgrenciBL.OgrenciSil(o.OgrenciId);
                    if (sonuc)
                    {
                        MessageBox.Show("Öğrenci ve Veli Silme İşlemi başarılı");
                        OgrenciListele();
                        Utility.CleanTextBoxes(grpOgrenciBilgileri.Controls);
                        Utility.CleanTextBoxes(grpVeliBilgileri.Controls);
                        pcbOgrenci.Image = Properties.Resources.indir;
                    }

                    else
                    {
                        MessageBox.Show("Öğrenci ve Veli İşlemiş Başarısız!!!");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void grdOgretmen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdOgretmen.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    grdOgretmen.CurrentRow.Selected = true;
                    txtGelenOgrtmenId.Text = grdOgretmen.Rows[e.RowIndex].Cells["clmOgretmenId"].FormattedValue.ToString();
                    txtOgretmenAd2.Text = grdOgretmen.Rows[e.RowIndex].Cells["clmOgretmenAdi"].FormattedValue.ToString();
                    txtOgretSoyad.Text = grdOgretmen.Rows[e.RowIndex].Cells["clmOgretmenSoyad"].FormattedValue.ToString();
                    txGlnYetId.Text = grdOgretmen.Rows[e.RowIndex].Cells["clmOgretmenId"].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Yanlış Yere Tıkladınız!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSilmeOgretmen_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Öğretmeni Silmek İstediğinizden Emin Misiniz ??", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Ogretmen ogr = new Ogretmen();
                    ogr.OgretmenId = Convert.ToInt32(txtGelenOgrtmenId.Text);
                    bool sonuc3 = OgretmenBL.OgretmenSil(ogr.OgretmenId);
                    if (sonuc3)
                    {
                        MessageBox.Show("Öğretmen Silme İşlemi başarılı");
                        OgretmenListele();
                        DersListele();
                        Utility.CleanTextBoxes(grpOgretmen.Controls);
                        Utility.CleanTextBoxes(grpSınıfBilg.Controls);
                        Utility.CleanTextBoxes(grpDersler.Controls);
                    }
                    else
                    {
                        MessageBox.Show("Öğretmen Silme işlemi başarısız!!");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void grdDersler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdDersler.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    grdDersler.CurrentRow.Selected = true;
                    txtGelenDersId2.Text = grdDersler.Rows[e.RowIndex].Cells["clmDersId2"].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Yanlış Yere Tıkladınız!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDersKayit_Click(object sender, EventArgs e)
        {
            try
            {
                Dersler drs = new Dersler();
                drs.DersAdi = txtDersAdi.Text.Trim().ToUpper();
                drs.OgretmenId = Convert.ToInt32(txtGelenOgrtmenId.Text);
                bool sonuc3 = DerslerBL.DersEkleme(drs);
                if (sonuc3)
                {
                    MessageBox.Show("Ders Kaydı Başarılı");
                    DersListele();
                    Dersler();
                    Utility.CleanTextBoxes(grpDersler.Controls);
                }
                else
                {
                    MessageBox.Show("Ders Kaydı Başarısız!!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("İlk Önce Ders Öğretmenini Seçiniz!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSinifSil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Sınıfı Silmek İstediğinizden Emin Misiniz??", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Sinif snf2 = new Sinif();
                    snf2.SinifId = Convert.ToInt32(txtGelenSinifId.Text);
                    bool sonuc4 = SinifBL.SinifSil(snf2.SinifId);
                    if (sonuc4)
                    {
                        MessageBox.Show("Sınıf Silme İşlemi Başarılı");
                        SinifListele();
                        DersListele();
                        Utility.CleanTextBoxes(grpSınıfBilg.Controls);
                        Utility.CleanTextBoxes(grpDersler.Controls);
                        Utility.CleanTextBoxes(grpOgretmen.Controls);
                    }
                    else
                    {
                        MessageBox.Show("Sınıf Silme İşlemi Başarısız!!!");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void grdSinif2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdSinif2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    grdSinif2.CurrentRow.Selected = true;
                    txtGelenSinifId.Text = grdSinif2.Rows[e.RowIndex].Cells["sinifid"].FormattedValue.ToString();
                    txtKapasite2.Text = grdSinif2.Rows[e.RowIndex].Cells["clmKapasite"].FormattedValue.ToString();
                    txtSinifAdi.Text = grdSinif2.Rows[e.RowIndex].Cells["clmSinifAdi"].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Yanlış Yere Tıkladınız!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDersSil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Dersi Silmek İstediğinizden Emin Misiniz??", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Dersler drs2 = new Dersler();
                    drs2.DerslerId = Convert.ToInt32(txtGelenDersId2.Text);
                    bool sonuc5 = DerslerBL.DersSil(drs2.DerslerId);
                    if (sonuc5)
                    {
                        MessageBox.Show("Ders Silme İşlemini Başarılı");
                        Dersler();
                        DersListele();
                        Utility.CleanTextBoxes(grpDersler.Controls);
                        Utility.CleanTextBoxes(grpOgretmen.Controls);
                        Utility.CleanTextBoxes(grpSınıfBilg.Controls);
                    }
                    else
                    {
                        MessageBox.Show("Ders Silme İşlemini Başarısız!!!");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void grdBilgiOgrenci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdBilgiOgrenci.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    grdBilgiOgrenci.CurrentRow.Selected = true;
                    txtOgrenciNo.Text = grdBilgiOgrenci.Rows[e.RowIndex].Cells["OgrenciAd"].FormattedValue.ToString();
                    pcbOgrenciResim.ImageLocation = grdBilgiOgrenci.Rows[e.RowIndex].Cells["resim2"].FormattedValue.ToString();
                    txtGelenOgrId.Text = grdBilgiOgrenci.Rows[e.RowIndex].Cells["ogrenciId2"].FormattedValue.ToString();
                    txGlnOgr.Text = grdBilgiOgrenci.Rows[e.RowIndex].Cells["ogrenciId2"].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Yanlış Yere Tıkladınız!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void grdBilgiDers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdBilgiDers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {

                    grdBilgiDers.CurrentRow.Selected = true;
                    txtGelenDersId.Text = grdBilgiDers.Rows[e.RowIndex].Cells["dersid"].FormattedValue.ToString();
                    txtgelenDersler.Text = grdBilgiDers.Rows[e.RowIndex].Cells["dersler2"].FormattedValue.ToString();

                    DataView dw = dt1.DefaultView;
                    dw.RowFilter = "DersAdi Like '" + txtgelenDersler.Text + "%'";
                    grdNotlar.DataSource = dw;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Yanlış Yere Tıkladınız!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ogrenci sfr1 = new Ogrenci();
            SifreOgretmen sfr2 = new SifreOgretmen();

            if (txtgelenYetId.Text == "")
            {
                sfr1.Sifre = txtYeniSifre.Text.Trim();
                sfr1.OkulNo = txtGuncelKullanici.Text.Trim();
                sfr1.OgrenciId = Convert.ToInt32(txgelenOgrId.Text);

                if (txtYeniSifre.Text.Trim() == txtYeniSifreTekrar.Text.Trim())
                {
                    bool sonuc = OgrenciBL.SifreDuzenleme(sfr1);
                    if (sonuc)
                    {
                        MessageBox.Show("Şifreniz Değiştirildi");
                        Utility.CleanTextBoxes(grpSifre.Controls);
                        SifreleriListele();
                    }
                    else
                    {
                        MessageBox.Show("Şifreniz Değiştirilmedi!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else if (txgelenOgrId.Text =="")
            {
                sfr2.Sifre2Id = Convert.ToInt32(txtgelenYetId.Text);
                sfr2.Password = txtYeniSifre.Text.Trim();
                sfr2.Login = txtGuncelKullanici.Text.Trim();
                if (txtYeniSifre.Text.Trim() == txtYeniSifreTekrar.Text.Trim())
                {
                    bool sonuc2 = SifreOgretmenBL.YetkSifGuncelleme(sfr2);
                    if (sonuc2)
                    {
                        MessageBox.Show("Şifreniz Değiştirildi");
                        Utility.CleanTextBoxes(grpSifre.Controls);
                        SifreleriListele();
                    }
                    else
                    {
                        MessageBox.Show("Şifreniz Değiştirilmedi!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Girilen Değerleri Kontrol Ediniz!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dtOgrSifreler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtOgrSifreler.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dtOgrSifreler.CurrentRow.Selected = true;
                    txgelenOgrId.Text = dtOgrSifreler.Rows[e.RowIndex].Cells["ogrId"].FormattedValue.ToString();
                    txtGuncelKullanici.Text = dtOgrSifreler.Rows[e.RowIndex].Cells["clmOkul"].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Yanlış Yere Tıkladınız!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dtYetkiliSifre_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtYetkiliSifre.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dtYetkiliSifre.CurrentRow.Selected = true;
                    txtgelenYetId.Text = dtYetkiliSifre.Rows[e.RowIndex].Cells["clmSifre2Id"].FormattedValue.ToString();
                    txtGuncelKullanici.Text = dtYetkiliSifre.Rows[e.RowIndex].Cells["clmLogin"].FormattedValue.ToString();
                    txGlnYetId.Text = dtYetkiliSifre.Rows[e.RowIndex].Cells["yetid"].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Yanlış Yere Tıkladınız!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnDuze_Click(object sender, EventArgs e)
        {
            try
            {
                Ogrenci o1 = new Ogrenci();
                o1.Ad = txtAdOgrenci.Text.Trim().ToUpper();
                o1.Soyad = txtSoyadOgrenci.Text.Trim().ToUpper();
                o1.TCKimlikNo = txtTCogrenci.Text.Trim();
                o1.OkulNo = txtOkulNo.Text.Trim();
                o1.SinifId = (int)cmbSinif.SelectedValue;
                o1.Resim = txtResim.Text.Trim();
                o1.VeliAd = txtVeliAd.Text.Trim().ToUpper();
                o1.VeliSoyad = txtVeliSoyad.Text.Trim().ToUpper();
                o1.Tel = txtTelVeli.Text.Trim().ToUpper();
                o1.Adres = txtAdresVeli.Text.Trim().ToUpper();
                o1.OgrenciId = Convert.ToInt32(txtogrenciIdGelen.Text);
                bool sonuc = OgrenciBL.OgrenciDuzenleme(o1);
                if (sonuc)
                {
                    MessageBox.Show("Düzeltme İşlemi başarılı");
                    OgrenciListele();
                    Utility.CleanTextBoxes(grpOgrenciBilgileri.Controls);
                    Utility.CleanTextBoxes(grpVeliBilgileri.Controls);
                    pcbOgrenci.Image = Properties.Resources.indir;
                }
                else
                {
                    MessageBox.Show("Düzeltme Başarısız");
                }
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        if (ex.Message.Contains("TCKimlikNo"))
                        {
                            MessageBox.Show("Bu TC Kimlik numarası zaten kayıtlı!!" + ex.Number);
                        }
                        else
                        {
                            MessageBox.Show("Bu Öğrenci numarası zaten kayıtlı!!" + ex.Number);
                        }
                        break;
                    default:
                        MessageBox.Show("Veritabanı Hatası!!" + ex.Number);
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bilinmeyen Hata!!");
            }
        }
        private void dataDersler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                MessageBox.Show("Yanlış Yere Tıkladınız!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnNotDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                Notlar nt = new Notlar();
                nt.Vize = Convert.ToInt32(txt1Vize.Text);
                nt.Sozlu = Convert.ToInt32(txtSozlu.Text);
                nt.Final = Convert.ToInt32(txtFinal.Text);
                nt.Ortalama = Convert.ToInt32(txtOrtalama.Text);
                nt.OgrenciId = Convert.ToInt32(txtGelenOgrId.Text);
                nt.DerslerId = Convert.ToInt32(txtGelenDersId.Text);
                nt.NotlarId = Convert.ToInt32(txtGelenNotId.Text);
                bool sonuc7 = NotlarBL.NotlarıDuzenleme(nt);
                if (sonuc7)
                {
                    MessageBox.Show("Notlar Güncellendi");
                    NotlarListele();
                    Utility.CleanTextBoxes(grpNotEkleme.Controls);
                }
                else
                {
                    MessageBox.Show("Notlar Güncellenmedi!!");
                }

            }

            catch (Exception)
            {
                throw;
            }
        }
        private void btnNotSil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Öğrencinin Notlarını Silmek Üzeresiniz!!!", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.OK)
                {
                    Notlar nt = new Notlar();
                    nt.NotlarId = Convert.ToInt32(txtGelenNotId.Text);
                    bool sonuc8 = NotlarBL.NotlarıSil(nt.NotlarId);
                    if (sonuc8)
                    {
                        MessageBox.Show("Notlar Silindi");
                        NotlarListele();
                        Utility.CleanTextBoxes(grpNotEkleme.Controls);
                    }
                    else
                    {
                        MessageBox.Show("İşlem Başarısız!!");
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void grdOgrenciler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdOgrenciler.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
                {
                    grdOgrenciler.CurrentRow.Selected = true;
                    txtAdOgrenci.Text = grdOgrenciler.Rows[e.RowIndex].Cells["clmAd"].FormattedValue.ToString();
                    txtSoyadOgrenci.Text = grdOgrenciler.Rows[e.RowIndex].Cells["clmSoyad"].FormattedValue.ToString();
                    txtTCogrenci.Text = grdOgrenciler.Rows[e.RowIndex].Cells["clmTCKimlikNo"].FormattedValue.ToString();
                    txtOkulNo.Text = grdOgrenciler.Rows[e.RowIndex].Cells["clmOkulNo"].FormattedValue.ToString();
                    txtogrenciIdGelen.Text = grdOgrenciler.Rows[e.RowIndex].Cells["clmOgrenciId"].FormattedValue.ToString();
                    pcbOgrenci.ImageLocation = grdOgrenciler.Rows[e.RowIndex].Cells["clmResim2"].FormattedValue.ToString();
                    cmbSinif.Text = grdOgrenciler.Rows[e.RowIndex].Cells["clmSinifId"].FormattedValue.ToString();
                    txtVeliAd.Text = grdOgrenciler.Rows[e.RowIndex].Cells["clmVeliId"].FormattedValue.ToString();
                    txtVeliSoyad.Text = grdOgrenciler.Rows[e.RowIndex].Cells["clmSoyad"].FormattedValue.ToString();
                    txtTelVeli.Text = grdOgrenciler.Rows[e.RowIndex].Cells["clmTel"].FormattedValue.ToString();
                    txtAdresVeli.Text = grdOgrenciler.Rows[e.RowIndex].Cells["clmAdres"].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Yanlış Yere Tıkladınız!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void grdNotlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdNotlar.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    grdNotlar.CurrentRow.Selected = true;
                    txt1Vize.Text = grdNotlar.Rows[e.RowIndex].Cells["clmVize"].FormattedValue.ToString();
                    txtFinal.Text = grdNotlar.Rows[e.RowIndex].Cells["clmFinal"].FormattedValue.ToString();
                    txtSozlu.Text = grdNotlar.Rows[e.RowIndex].Cells["clmSozlu"].FormattedValue.ToString();
                    txtOrtalama.Text = grdNotlar.Rows[e.RowIndex].Cells["clmVize"].FormattedValue.ToString();
                    txtgelenDersler.Text = grdNotlar.Rows[e.RowIndex].Cells["Ders"].FormattedValue.ToString();
                    txtOgrenciNo.Text = grdNotlar.Rows[e.RowIndex].Cells["ogrenciAdi"].FormattedValue.ToString();
                    pcbOgrenciResim.ImageLocation = grdNotlar.Rows[e.RowIndex].Cells["clmResim"].FormattedValue.ToString();
                    txtGelenNotId.Text = grdNotlar.Rows[e.RowIndex].Cells["clmNotlarId"].FormattedValue.ToString();
                    txtGelenOgrId.Text = grdNotlar.Rows[e.RowIndex].Cells["clmOgrId"].FormattedValue.ToString();
                    txtGelenDersId.Text = grdNotlar.Rows[e.RowIndex].Cells["clmSiniffid"].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Yanlış Yere Tıkladınız!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSınavKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Notlar nt = new Notlar();
                nt.Vize = Convert.ToInt32(txt1Vize.Text);
                nt.Sozlu = Convert.ToInt32(txtSozlu.Text);
                nt.Final = Convert.ToInt32(txtFinal.Text);
                nt.Ortalama = Convert.ToInt32(txtOrtalama.Text);
                nt.OgrenciId = Convert.ToInt32(txtGelenOgrId.Text);
                nt.DerslerId = Convert.ToInt32(txtGelenDersId.Text);
                bool sonuc7 = NotlarBL.NotlarıEkle(nt);
                if (sonuc7)
                {
                    MessageBox.Show("Not Kaydedildi");
                    NotlarListele();
                    Utility.CleanTextBoxes(grpNotEkleme.Controls);
                }
                else
                {
                    MessageBox.Show("Not Kaydedilmedi!!");
                }
            }
            catch (Exception)
            {
                throw;
            }
            #region MyRegion
            //Notlar nt = new Notlar();
            //foreach (DataRow item in dt1.Rows)
            //{
            //    switch (item.RowState)
            //    {
            //        case DataRowState.Added:
            //            nt.Vize = Convert.ToInt32(item["Vize"]);
            //            nt.Sozlu = Convert.ToInt32(item["Sozlu"]);
            //            nt.Final = Convert.ToInt32(item["Final"]);
            //            nt.Ortalama = Convert.ToInt32(item["Ortalama"]);
            //            nt.OgrenciId = Convert.ToInt32(txtGelenOgrId.Text);
            //            nt.DerslerId = Convert.ToInt32(txtGelenDersId.Text);
            //            NotlarBL.NotlarıEkle(nt);
            //            break;
            //        case DataRowState.Deleted:
            //            nt.NotlarId = Convert.ToInt32(item["NotlarId", DataRowVersion.Original]);
            //            NotlarBL.NotlarıSil(nt.NotlarId);
            //            break;
            //        case DataRowState.Modified:
            //            nt.Vize = Convert.ToInt32(item["Vize"]);
            //            nt.Sozlu = Convert.ToInt32(item["Sozlu"]);
            //            nt.Final = Convert.ToInt32(item["Final"]);
            //            nt.Ortalama = Convert.ToInt32(item["Ortalama"]);
            //            NotlarBL.NotlarıDuzenleme(nt);
            //            break;
            //        default:
            //            break;
            //    }

            //} 
            #endregion

        }
        //Sınıf kaydet
        private void btnSinifOgrtKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SifreOgretmen sfr = new SifreOgretmen();
                sfr.OgretmenId = Convert.ToInt32(txtGelenOgrtmenId.Text);
                sfr.Login = txtOgretmenAd2.Text.Trim().ToUpper();
                sfr.Password = txtSifreOgrtmen.Text.Trim();
                bool sonuc3 = SifreOgretmenBL.SifreBelirleme(sfr);
                Sinif sn = new Sinif();
                sn.SinifAdi = txtSinifAdi.Text.Trim().ToUpper();
                sn.Kapasite = Convert.ToInt32(txtKapasite2.Text);
                sn.OgretmenId = Convert.ToInt32(txtGelenOgrtmenId.Text);
                bool sonuc2 = SinifBL.SinifEkleme(sn);
                if (sonuc2 && sonuc3)
                {
                    MessageBox.Show("Sınıf Kayıt Başarılı");
                    SinifListele();
                    Utility.CleanTextBoxes(grpSınıfBilg.Controls);
                    Utility.CleanTextBoxes(grpDersler.Controls);
                    Utility.CleanTextBoxes(grpOgretmen.Controls);
                }
                else
                {
                    MessageBox.Show("Sınıf Kayıt Başarısız!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("İlk Önce Sınıf Öğretmeninizi Seçiniz!!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #region DataTıklama
            //Sinif sn = new Sinif();
            //foreach (DataRow item in dt3.Rows)
            //{
            //    switch (item.RowState)
            //    {
            //        case DataRowState.Added:
            //           sn.SinifAdi=item["SinifAdi"].ToString();
            //            sn.Kapasite = Convert.ToInt32(item["Kapasite"]);
            //            sn.OgretmenId = Convert.ToInt32(txtGelenOgrtmenId.Text);
            //            SinifBL.SinifEkleme(sn);
            //            break;
            //        case DataRowState.Deleted:
            //            sn.SinifId = Convert.ToInt32(item["SinifId", DataRowVersion.Original]);
            //            SinifBL.SinifSil(sn.SinifId);
            //            break;
            //        case DataRowState.Modified:
            //            sn.SinifAdi = item["SinifAdi"].ToString();
            //            sn.Kapasite = Convert.ToInt32(item["Kapasite"]);
            //            sn.OgretmenId = Convert.ToInt32(txtGelenOgrtmenId);
            //            SinifBL.SinifDuzenleme(sn);
            //            break;
            //        default:
            //            break;
            //    }
            //} 
            #endregion
        }
        private void btnArastir_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Title = "Yüklemek istediğiniz Fotoğrafı seçiniz..";
            //openFileDialog1.Filter = "Jpg |*.jpg| Png|*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.ShowDialog();
                pcbOgrenci.ImageLocation = openFileDialog1.FileName;
                txtResim.Text = openFileDialog1.FileName;
            }
        }
        private void btnGrpOgretKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Ogretmen og = new Ogretmen();
                og.OgretmenAd = txtOgretmenAd2.Text.Trim().ToUpper();
                og.OgretmenSoyad = txtOgretSoyad.Text.Trim().ToUpper();
                bool sonuc = OgretmenBL.OgretmenEkleme(og);
                if (sonuc)
                {
                    MessageBox.Show("Öğretmen Kayıt Başarılı");
                    OgretmenListele();
                    Utility.CleanTextBoxes(grpOgretmen.Controls);
                    Utility.CleanTextBoxes(grpSınıfBilg.Controls);
                    Utility.CleanTextBoxes(grpDersler.Controls);
                }
                else
                {
                    MessageBox.Show("Öğretmen Kayıt Başarısız!!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}
