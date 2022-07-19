using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu.Ogretmen
{
    public class Ogretmen
    {
        public int OgrId { get; set; }
        public string OgrTc { get; set; }
        public string OgrAd { get; set; }
        public string OgrSoyad { get; set; }
        public int OgrSicilNo { get; set; }
        public string OgrVerdigiBolum { get; set; }
        public string OgrVerdigiDersler { get; set; }
        public string Sifre { get; set; }
        public int BolumId { get; set; }
    }
}
