using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu.Ogrenci
{
    public class Ogrenci
    {
        public int OgrenciId { get; set; }
        public string OgrenciNo { get; set; }
        public string OgrenciTc { get; set; }
        public string OgrenciIsim { get; set; }
        public string OgrenciSoyisim { get; set; }
        public string BulunduguBolum { get; set; }
        public string Telefon { get; set; }
        public string IsCap { get; set; }
        public string AldigiDersler { get; set; }
        public double Ortalamasi { get; set; }
        public int BolumId { get; set; }
        public string Sifre { get; set; }
    }
}
