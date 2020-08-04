using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulApp.Models
{
   public class Notlar
    {
        public int NotlarId { get; set; }
        public int DerslerId { get; set; }
        public int OgrenciId { get; set; }
        public int Vize { get; set; }
        public int Final { get; set; }
        public int Sozlu { get; set; }
        public int Ortalama { get; set; }
    }
}
