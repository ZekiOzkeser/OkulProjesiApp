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
    public class OgretmenBL
    {
        public static bool OgretmenEkleme(Ogretmen og)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@OgretmenAd",og.OgretmenAd),
                    new SqlParameter("@OgretmenSoyad",og.OgretmenSoyad),
                   
                };
                return Helper.ExecuteNonQuery("spOgretmenEkle", p) > 0;

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

        public static bool OgretmenDuzenleme(Ogretmen og)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@OgretmenAd",og.OgretmenAd),
                    new SqlParameter("@OgretmenSoyad",og.OgretmenSoyad),
                    new SqlParameter("@OgretmenId",og.OgretmenId)
                    
                };
                return Helper.ExecuteNonQuery("spOgretmenGuncelle", p) > 0;
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
        public static bool OgretmenSil(int OgretmenId)
        {
            try
            {
                SqlParameter[] p = { new SqlParameter("OgretmenId", OgretmenId) };
                return Helper.ExecuteNonQuery("spOgretmenSil", p) > 0;

            }
            catch (Exception)
            {

                throw;
            }
        }



        public static DataTable OgretmenListele()
        {
            return Helper.MyDataTable("SELECT OgretmenAd, OgretmenSoyad, OgretmenId FROM tblOgretmenler",null);
        }


    }
}
