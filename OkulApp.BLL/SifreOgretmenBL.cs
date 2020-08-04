using Izek.DAL;
using OkulApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OkulApp.BLL
{
    public class SifreOgretmenBL
    {
        public static bool SifreBelirleme(SifreOgretmen sfr)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@OgretmenId",sfr.OgretmenId),
                    new SqlParameter("@Password",sfr.Password),
                    new SqlParameter("@Login",sfr.Login)
                };

                return Helper.ExecuteNonQuery("spYetSifreEkle", p) > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int OgretmenSifre(SifreOgretmen sfr)
        {
            try
            {
                return Helper.ExecuteScalar("spKullaniciKontrol", new SqlParameter[] { new SqlParameter("@login", sfr.Login), new SqlParameter("@password", sfr.Password) });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool YetkSifGuncelleme(SifreOgretmen sfr)
        {
            try
            {
                SqlParameter[] p ={
                   new SqlParameter("@Login",sfr.Login),
                   new SqlParameter("@Password",sfr.Password),
                   new SqlParameter("@Sifre2Id",sfr.Sifre2Id)

                };
                return Helper.ExecuteNonQuery("spSifreGuncelle", p) > 0;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable OgrSfrListele()
        {
            return Helper.MyDataTable("SELECT OgrenciId, Ad, TCKimlikNo, OkulNo, Sifre FROM tblOgrenciler", null);
        }

        public static DataTable YetkSfrListele()
        {
            return Helper.MyDataTable("SELECT tblSifreOgretmen.Sifre2Id, tblSifreOgretmen.Password, tblSifreOgretmen.Login, tblOgretmenler.OgretmenAd, " +
                "tblOgretmenler.OgretmenId FROM tblOgretmenler INNER JOIN tblSifreOgretmen ON tblOgretmenler.OgretmenId = tblSifreOgretmen.OgretmenId", null);
        }

    }
}
