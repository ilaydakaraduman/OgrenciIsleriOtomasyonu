using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciOtomasyonu.AlinanDersler
{
    public class AlinanDers
    {
        public int Id { get; set; }
        public string OgrenciNo { get; set; }
        public int DersId { get; set; }
        public decimal Vize { get; set; }
        public decimal Final { get; set; }
        public decimal Ortalama { get; set; }
        public string DersAdi { get; set; }
        public int DersKredi { get; set; }
    }
}
