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
    public class OgrenciBL
    {
        public static bool OgrenciEkleme(Ogrenci o)
        {
            try
            {
                SqlParameter[] p =
                {
                    new SqlParameter("@Ad", o.Ad),
                    new SqlParameter("@Soyad", o.Soyad),
                    new SqlParameter("@TCKimlikNo", o.TCKimlikNo),
                    new SqlParameter("@OkulNo", o.OkulNo),
                    new SqlParameter("@SinifId", o.SinifId),
                    new SqlParameter("@Resim",o.Resim),
                    new SqlParameter("@VeliAd",o.VeliAd),
                    new SqlParameter("@VeliSoyad",o.VeliSoyad),
                    new SqlParameter("@Tel",o.Tel),
                    new SqlParameter("@Adres",o.Adres),
                    new SqlParameter("@Sifre",o.Sifre)

                };
                return Helper.ExecuteNonQuery("spOgrenciEkle", p) > 0;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static bool OgrenciDuzenleme(Ogrenci o)
        {
            SqlParameter[] p =
             {
                new SqlParameter("@Ad",o.Ad),
                new SqlParameter("@Soyad",o.Soyad),
                new SqlParameter("@TCKimlikNo",o.TCKimlikNo),
                new SqlParameter("@OkulNo",o.OkulNo),
                new SqlParameter("@SinifId",o.SinifId),
                new SqlParameter("@Resim",o.Resim),
                new SqlParameter("@VeliAd",o.VeliAd),
                new SqlParameter("@VeliSoyad",o.VeliSoyad),
                new SqlParameter("@Tel",o.Tel),
                new SqlParameter("@Adres",o.Adres),
                new SqlParameter("OgrenciId",o.OgrenciId)
                
            };
            return Helper.ExecuteNonQuery("spOgrenciDuzenleme", p) > 0;
        }

        public static bool SifreDuzenleme(Ogrenci o)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@OgrenciId",o.OgrenciId),
                new SqlParameter("@Sifre",o.Sifre)
            };
            return Helper.ExecuteNonQuery("spSifreGuncelleme", p) > 0;
        }

        public static bool OgrenciSil(int OgrenciId)
        {
            try
            {
                SqlParameter[] p = {
                    new SqlParameter("@OgrenciId", OgrenciId),
                };
                return Helper.ExecuteNonQuery("spOgrenciSil", p) > 0;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public static Ogrenci OkulNoGetir(string OkulNo)
        {

            try
            {
                SqlParameter[] p = { new SqlParameter("@OkulNo", OkulNo) };
                SqlDataReader dr = Helper.ExecuteReader("spOgrenciGetir", p);
                Ogrenci o = null;
                if (dr.Read())
                {
                    o = new Ogrenci();
                    o.Ad = dr["Ad"].ToString();
                    o.Soyad = dr["Soyad"].ToString();
                    o.TCKimlikNo = dr["TCKimlikNo"].ToString();
                    o.OkulNo = dr["OkulNo"].ToString();
                    o.SinifId = Convert.ToInt32(dr["SinifId"]);
                    o.Resim = dr["Resim"].ToString();
                    o.OgrenciId = Convert.ToInt32(dr["OgrenciId"]);

                    dr.Close();

                }
                return o;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DataTable OgrenciListele()
        {
            return Helper.MyDataTable("SELECT tblOgrenciler.OgrenciId, tblOgrenciler.Ad, tblOgrenciler.TCKimlikNo, tblOgrenciler.Soyad, tblOgrenciler.OkulNo, " +
                "tblOgrenciler.SinifId, tblOgrenciler.Resim, tblOgrenciler.VeliAd, tblOgrenciler.VeliSoyad, tblOgrenciler.Tel,tblOgrenciler.Adres, tblSinif.SinifAdi " +
                "FROM tblOgrenciler INNER JOIN tblSinif ON tblOgrenciler.SinifId = tblSinif.SinifId", null);
        }

        public static DataTable OgrencileriGoster()
        {
            return Helper.MyDataTable("SELECT OgrenciId, Ad, Soyad, TCKimlikNo, OkulNo, Resim FROM tblOgrenciler", null);
        }
        public static DataTable NotlarıListele()
        {
            return Helper.MyDataTable("SELECT tblNotlar.NotlarId, tblNotlar.Vize, tblNotlar.Final, tblNotlar.Sozlu, tblNotlar.Ortalama, tblDersler.DersAdi, tblOgrenciler.Ad, " +
                "tblOgrenciler.OgrenciId, tblOgrenciler.OkulNo FROM tblDersler INNER JOIN tblNotlar ON tblDersler.DerslerId = tblNotlar.DerslerId INNER JOIN tblOgrenciler " +
                "ON tblNotlar.OgrenciId = tblOgrenciler.OgrenciId", null);
        }

        public static DataView NotlarGoster()
        {
            return Helper.MyDataView("SELECT tblNotlar.NotlarId, tblNotlar.Vize, tblNotlar.Final, tblNotlar.Sozlu, tblNotlar.Ortalama, tblOgrenciler.OkulNo, tblDersler.DersAdi," +
                " tblOgrenciler.Ad FROM tblDersler INNER JOIN tblNotlar ON tblDersler.DerslerId = tblNotlar.DerslerId INNER JOIN tblOgrenciler ON tblNotlar.OgrenciId = tblOgrenciler.OgrenciId", null);
        }

        public static DataTable SifreGetir()
        {
            return Helper.MyDataTable("SELECT OgrenciId, Ad, TCKimlikNo, OkulNo, Sifre FROM tblOgrenciler", null);
        }

        public static int OgrenciSifre(Ogrenci o)
        {
            try
            {
                return Helper.ExecuteScalar("spSfrKntrlOgrenci", new SqlParameter[] { new SqlParameter("@OkulNo", o.OkulNo), new SqlParameter("@sifre", o.Sifre) });
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
