using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulApp.Models
{
    public class Sinif
    {
        public int SinifId { get; set; }
        public string SinifAdi { get; set; }
        public int Kapasite { get; set; }
        public int OgretmenId { get; set; }
    }
}
