using OkulApp.BLL;
using OkulApp.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace OkulProjesiApp
{
    public partial class OgrenciEkran : Form
    {
        DataTable dt;
        public OgrenciEkran()
        {
            InitializeComponent();
            dtOgrenciBilgileri.AutoGenerateColumns = false;
        }

        private void BtnDuzenle_Click(object sender, EventArgs e)
        {
            AnaGiris frm = new AnaGiris();
            frm.Show();
            this.Close();

        }
        void OgrenciGoruntule()
        {
            dt = OgrenciBL.NotlarıListele();
            dtOgrenciBilgileri.DataSource = dt;
        }
        private void OgrenciEkran_Load(object sender, EventArgs e)
        {
            OgrenciGoruntule();

            lblHoslgeldiniz.Text = AnaGiris.ad;
            DataView dw = dt.DefaultView;

            dw.RowFilter = "OkulNo Like '" + lblHoslgeldiniz.Text + "%'";
            dtOgrenciBilgileri.DataSource = dw;

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Ogrenci sfr1 = new Ogrenci();
            //SifreOgrenci sfr1 = new SifreOgrenci();
            sfr1.Sifre = txtYeniSifre.Text.Trim();
            sfr1.OkulNo = lblHoslgeldiniz.Text;
            sfr1.OgrenciId = Convert.ToInt32(lblGelenSifreId.Text);

            if (txtYeniSifre.Text.Trim() == txtYeniSifreTekrar.Text.Trim())
            {
                bool sonuc = OgrenciBL.SifreDuzenleme(sfr1);
                if (sonuc)
                {
                    MessageBox.Show("Şifreniz Değiştirildi");
                }
                else
                {
                    MessageBox.Show("Şifreniz Değiştirilmedi!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Girilen Değerleri Kontrol Ediniz!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtOgrenciBilgileri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtOgrenciBilgileri.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dtOgrenciBilgileri.CurrentRow.Selected = true;
                lblGelenSifreId.Text = dtOgrenciBilgileri.Rows[e.RowIndex].Cells["glnid"].FormattedValue.ToString();
                lblAd.Text = dtOgrenciBilgileri.Rows[e.RowIndex].Cells["ad"].FormattedValue.ToString();
            }
        }
    }
}
