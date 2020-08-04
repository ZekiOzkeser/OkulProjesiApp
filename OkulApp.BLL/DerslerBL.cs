using Izek.DAL;
using OkulApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulApp.BLL
{
    public class DerslerBL
    {
        public static bool DersEkleme(Dersler ders )
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@DersAdi",ders.DersAdi),
                    new SqlParameter("@OgretmenId",ders.OgretmenId)
                    
                };

                return Helper.ExecuteNonQuery("spDersEkle", p) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DersDuzenleme(Dersler ders)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@DersAdi",ders.DersAdi),
                    new SqlParameter("@DerslerId",ders.DerslerId),
                    new SqlParameter("@OgretmenId",ders.OgretmenId)
                };
                return Helper.ExecuteNonQuery("spDersDuzenleme", p)>0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DersSil(int DerslerId)
        {
            try
            {
                SqlParameter[] p = { new SqlParameter("@DerslerId", DerslerId )};
                return Helper.ExecuteNonQuery("spDersSil", p) > 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Dersler DersAdiGetir(string dersadi)
        {
            try
            {
                SqlParameter[] p = { new SqlParameter("@DersAdi", dersadi) };
                SqlDataReader dr = Helper.ExecuteReader("spDersGetir", p);
                Dersler ders = null;
                if (dr.Read())
                {
                    ders = new Dersler();
                    ders.DersAdi = dersadi;
                    ders.OgretmenId = Convert.ToInt32(dr["OgretmenId"]);
                    ders.DerslerId = Convert.ToInt32(dr["DerslerId"]);
                    dr.Close();
                }
                return ders;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable DersListesi()
        {
            return Helper.MyDataTable("SELECT tblDersler.DerslerId, tblDersler.DersAdi, tblDersler.OgretmenId, tblOgretmenler.OgretmenAd, " +
                "tblOgretmenler.OgretmenSoyad, tblSinif.SinifAdi FROM tblDersler INNER JOIN tblOgretmenler ON " +
                "tblDersler.OgretmenId = tblOgretmenler.OgretmenId INNER JOIN tblSinif ON tblOgretmenler.OgretmenId = tblSinif.OgretmenId", null);
        }

        public static DataTable DersleriGoster()
        {
            return Helper.MyDataTable("SELECT DersAdi, DerslerId FROM tblDersler", null);
        }

    }
    
}
