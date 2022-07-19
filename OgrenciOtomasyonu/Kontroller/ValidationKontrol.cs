using OgrenciOtomasyonu.BolumlerBilgi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciOtomasyonu.Kontroller
{
    public class ValidationKontrol
    {
        BolumKod bolumKod = new BolumKod();
        public bool TextBoxUzunlukKontrol(string key, int length)
        {
            try
            {
                Convert.ToInt64(key);
                if (key.Length != length)
                {
                    MessageBox.Show("Karakter sayısı uygun değil.");
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Sadece sayı girişi yapınız");
                return false;
            }
        }
        public bool OgrenciNoBolumKontrol(int id, string ogrenciNo)
        {
            foreach (var bolum in bolumKod.GetAll())
            {
                if (bolum.BolumId == id)
                {
                    if (bolum.BolumKodu.ToCharArray().ElementAt(1).ToString() == ogrenciNo.ElementAt(0).ToString())
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Ogrenci numarası kurallara uygun değil");
                    }
                }
            }
            return false;
        }

    }
}
