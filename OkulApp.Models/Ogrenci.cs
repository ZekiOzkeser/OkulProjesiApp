using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulApp.Models
{
    public class Ogrenci
    {
        public int OgrenciId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string OkulNo { get; set; }
        public string TCKimlikNo { get; set; }
        public string Resim { get; set; }
        public int SinifId { get; set; }
        public string VeliAd { get; set; }
        public string VeliSoyad { get; set; }
         public string Tel { get; set; }
        public string Adres { get; set; }
        public string Sifre { get; set; }

    }
}
