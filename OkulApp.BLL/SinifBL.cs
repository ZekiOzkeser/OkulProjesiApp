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
    public class SinifBL
    {
        public static bool SinifEkleme(Sinif snf)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@SinifAdi",snf.SinifAdi),
                    new SqlParameter("@Kapasite",snf.Kapasite),
                    new SqlParameter("@OgretmenId",snf.OgretmenId)
                };
                return Helper.ExecuteNonQuery("spSinifEkle", p) > 0;
            }
            catch(SqlException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool SinifDuzenleme(Sinif snf)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@SinifAdi",snf.SinifAdi),
                    new SqlParameter("@Kapasite",snf.Kapasite),
                    new SqlParameter("@SinifId",snf.SinifId),
                    new SqlParameter("@OgretmenId",snf.OgretmenId)
                };
                return Helper.ExecuteNonQuery("spSinifDuzenle", p) > 0;
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
        public static bool SinifSil(int SinifId)
        {
            try
            {
                SqlParameter[] p = { new SqlParameter("@SinifId", SinifId) };
                return Helper.ExecuteNonQuery("spSinifSil", p) > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable SinifListesi()
        {

            return Helper.MyDataTable("SELECT SinifAdi, Kapasite,SinifId FROM tblSinif", null);
            //return Helper.MyDataTable("SELECT tblSinif.SinifId, tblSinif.SinifAdi, tblSinif.Kapasite, " +
            //    "tblOgretmenler.OgretmenAd, tblOgretmenler.OgretmenSoyad, tblOgretmenler.Bolum FROM tblOgretmenler" +
            //    " INNER JOIN tblSinif ON tblOgretmenler.OgretmenId = tblSinif.OgretmenId", null);
        }
        public static DataTable SinifGrup()
        {
            return Helper.MyDataTable("Select SinifAdi,SinifId from tblSinif", null);
        }
    }
}
