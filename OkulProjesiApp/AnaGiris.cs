using OkulApp.BLL;
using OkulApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulProjesiApp
{
    public partial class AnaGiris : Form
    {
        public static string ad;
        public AnaGiris()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnOgrenciGiris_Click(object sender, EventArgs e)
        {
            try
            {
                Ogrenci o = new Ogrenci();
                o.OkulNo = txtOkulNo.Text.Trim();
                o.Sifre = txtSifreOgrenci.Text.Trim();
                int snc = OgrenciBL.OgrenciSifre(o);
                if (snc == 1)
                {
                    OgrenciEkran frm = new OgrenciEkran();
                    ad = txtOkulNo.Text;
                    frm.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Bilgilerinizi kontrol ediniz", "Hata!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Restart();
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Test"+ex.Number);
                throw;
            }


        }

        private void BtnYoneticiGiris_Click(object sender, EventArgs e)
        {
            try
            {
                
                SifreOgretmen sfr = new SifreOgretmen();
                sfr.Login = txtKullaniciAdi.Text.Trim();
                sfr.Password = txtSifre.Text.Trim();
                int sonuc = SifreOgretmenBL.OgretmenSifre(sfr);
                if (sonuc == 1)
                {
                    OgretmenEkran frm = new OgretmenEkran();
                    frm.ShowDialog();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Bilgilerinizi kontrol ediniz", "Hata!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Restart();

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult tus;
            tus = MessageBox.Show("Çıkmak istediğinizden eminmisiniz ?", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {
                Close();
            }

        }

        private void LnkSifre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifreUnuttum frm = new SifreUnuttum();
            frm.ShowDialog();
        }
    }

}
