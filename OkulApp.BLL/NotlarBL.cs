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
    public class NotlarBL
    {
        public static bool NotlarıEkle(Notlar nt)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@Vize",nt.Vize),
                    new SqlParameter("@Final",nt.Final),
                    new SqlParameter("@Sozlu",nt.Sozlu),
                    new SqlParameter("@Ortalama",nt.Ortalama),
                    new SqlParameter("@OgrenciId",nt.OgrenciId),
                    new SqlParameter("DerslerId",nt.DerslerId)
                };
                return Helper.ExecuteNonQuery("spNotEkle", p) > 0;
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
        public static bool NotlarıDuzenleme(Notlar nt)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@Vize",nt.Vize),
                    new SqlParameter("@Final",nt.Final),
                    new SqlParameter("@Sozlu",nt.Sozlu),
                    new SqlParameter("@Ortalama",nt.Ortalama),
                    new SqlParameter("@NotlarId",nt.NotlarId),
                    new SqlParameter("@DerslerId",nt.DerslerId),
                    new SqlParameter("@OgrenciId",nt.OgrenciId)
                    
                };
                return Helper.ExecuteNonQuery("spNotDuzenle", p) > 0;
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
        public static bool NotlarıSil(int NotlarId)
        {
            try
            {
                SqlParameter[] p = { new SqlParameter("@NotlarId", NotlarId) };
                return Helper.ExecuteNonQuery("spNotSil", p) > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        //Notları Getir die bişey olmaz zaten geliyor:
        //public static Notlar NotlarıGetir(int derslerid)
        //{
        //    try
        //    {
        //        SqlParameter[] p = { new SqlParameter("@DerslerId", derslerid) };
        //        SqlDataReader dr = Helper.ExecuteReader("Select * from tblNotlar where Ortalama=@Ortalama", p);
        //        Notlar nt = null;
        //        if (dr.Read())
        //        {
        //            nt = new Notlar();
        //            nt.Vize = Convert.ToInt32(dr["Vize"]);
        //            nt.Final = Convert.ToInt32(dr["Final"]);
        //            nt.Sozlu = Convert.ToInt32(dr["Sozlu"]);
        //            nt.Ortalama = Convert.ToInt32(dr["Ortalama"]);
        //            nt.NotlarId = Convert.ToInt32(dr["NotlarId"]);
                    
        //            dr.Close();
        //        }
        //        return nt;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public static DataTable NotlarListesi()
        {
            return Helper.MyDataTable("SELECT tblNotlar.NotlarId, tblNotlar.Vize, tblNotlar.Final, tblNotlar.Sozlu, tblNotlar.Ortalama, tblNotlar.OgrenciId, tblNotlar.DerslerId," +
                " tblDersler.DersAdi, tblOgrenciler.Ad, tblOgrenciler.OgrenciId AS Expr1, tblOgrenciler.OkulNo,tblOgrenciler.TCKimlikNo, tblOgrenciler.Resim FROM tblDersler " +
                "INNER JOIN tblNotlar ON tblDersler.DerslerId = tblNotlar.DerslerId INNER JOIN tblOgrenciler ON tblNotlar.OgrenciId = tblOgrenciler.OgrenciId", null);

            //return Helper.MyDataTable("SELECT tblNotlar.NotlarId, tblNotlar.Final, tblNotlar.Vize, tblNotlar.Sozlu, tblNotlar.Ortalama, tblNotlar.OgrenciId, " +
            //    "tblNotlar.DerslerId, tblDersler.DersAdi, tblOgrenciler.Ad, tblOgrenciler.Soyad, tblOgrenciler.OkulNo, tblSinif.SinifAdi FROM tblDersler INNER " +
            //    "JOIN tblNotlar ON tblDersler.DerslerId = tblNotlar.DerslerId INNER JOIN tblOgrenciler ON tblNotlar.OgrenciId = tblOgrenciler.OgrenciId INNER JOIN " +
            //    "tblSinif ON tblOgrenciler.SinifId = tblSinif.SinifId", null);
        }
    }
}
