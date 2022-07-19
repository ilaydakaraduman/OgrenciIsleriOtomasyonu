using OgrenciOtomasyonu.Ogrenci;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciOtomasyonu.AlinanDersler
{
    public partial class Notlandirma : Form
    {
        public Notlandirma()
        {
            InitializeComponent();
        }
        AlinanDersKod alinanDersKod = new AlinanDersKod();
        OgrenciKod ogrenciKod = new OgrenciKod();
        Ogrenci.Ogrenci ogrenci = new Ogrenci.Ogrenci();
        AlinanDers alinanDers = new AlinanDers();
       
        int toplamKredi=0;
        decimal toplamNot = 0;
        private void btnOgrenciGetir_Click(object sender, EventArgs e)
        {
            bool bulduMu = false;
            foreach (var ogrenci in ogrenciKod.GetAll())
            {
                if(ogrenci.OgrenciNo == tbxOgrenciNo.Text)
                {
                    this.ogrenci = ogrenci;
                    tbxAd.Text = ogrenci.OgrenciIsim;
                    tbxSoyad.Text = ogrenci.OgrenciSoyisim;
                    tbxTelefon.Text = ogrenci.Telefon;
                    DerslerDoldur();
                    AlinanDerseDoldur();
                    ToplamKredi();
                    bulduMu = true;
                    break;
                }
            }
            if(bulduMu == false)
            {
                MessageBox.Show("Öğrenci bulunamadı.");
            }
        }
        private void Notlandirma_Load(object sender, EventArgs e)
        {

        }
        public void DerslerDoldur()
        {
            cbxDersler.DataSource = alinanDersKod.OgrenciDersGetirFiltreli(tbxOgrenciNo.Text);
            cbxDersler.DisplayMember = "DersAdi";
            cbxDersler.ValueMember = "Id";
        }
        public void AlinanDerseDoldur()
        {
            dgwDersler.DataSource = alinanDersKod.OgrenciDersGetirFiltreli(tbxOgrenciNo.Text);
        }
        private void cbxDersler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDersler.ValueMember.ToString() != "")
            {
                int id = Convert.ToInt32(cbxDersler.SelectedValue);
                foreach (var ders in alinanDersKod.OgrenciDersGetirFiltreli(tbxOgrenciNo.Text))
                {
                    if (ders.Id == id)
                    {
                        tbxVize.Text = ders.Vize.ToString();
                        tbxFinal.Text = ders.Final.ToString();
                        tbxOrtlama.Text = ders.Ortalama.ToString();
                        alinanDers = ders;
                    }
                }
            }
               
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            decimal vize = Convert.ToDecimal(tbxVize.Text) * Convert.ToDecimal(0.4);
            decimal final = Convert.ToDecimal(tbxFinal.Text) * Convert.ToDecimal(0.6);
            decimal ortalama = vize + final;
            tbxOrtlama.Text = ortalama.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            alinanDersKod.Update(new AlinanDers {
                Id = Convert.ToInt32(cbxDersler.SelectedValue),
                DersAdi = cbxDersler.Text,
                OgrenciNo = tbxOgrenciNo.Text,
                DersId = alinanDers.DersId,
                Final = Convert.ToDecimal(tbxFinal.Text),
                Vize= Convert.ToDecimal(tbxVize.Text),
                Ortalama = Convert.ToDecimal(tbxOrtlama.Text),
                DersKredi = alinanDers.DersKredi,
            });
            AlinanDerseDoldur();
            MessageBox.Show("Not giriş işlemi başarıyla gerçekleşti");
        }
        public void ToplamKredi()
        {
            
            foreach (var ders in alinanDersKod.OgrenciDersGetirFiltreli(tbxOgrenciNo.Text))
            {
                toplamKredi += ders.DersKredi;
                toplamNot += (ders.DersKredi * ders.Ortalama);
            }
        }
        public void OgrenciGenelOrtalama()
        {
            toplamKredi = 0;
            toplamNot = 0;
            ToplamKredi();
            decimal ortalama = toplamNot / Convert.ToDecimal(toplamKredi);
            MessageBox.Show((toplamNot / Convert.ToDecimal(toplamKredi)).ToString());
            ogrenci.Ortalamasi =  Convert.ToDouble(ortalama);
            ogrenciKod.Update(ogrenci);
        }

        private void btnGenelOrt_Click(object sender, EventArgs e)
        {
            OgrenciGenelOrtalama();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }
    }
}
