using OgrenciOtomasyonu.Ogrenci;
using OgrenciOtomasyonu.Ogretmen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciOtomasyonu
{
    public partial class OgrenciKadro : Form
    {
        public OgrenciKadro()
        {
            InitializeComponent();
        }
        int KayitSayisi ;
        OgretmenKod ogretmen = new OgretmenKod();
        OgrenciKod ogrenci = new OgrenciKod();
        string BolumAd = "";
        List<Ogretmen.Ogretmen> ogretmens = new List<Ogretmen.Ogretmen>();
        List<Ogrenci.Ogrenci> ogrencis = new List<Ogrenci.Ogrenci>();
        static string OgrNo=" ";
        static string OgrAd = "";
        static string OgrSoyad ="";
        static string OgSicilNo = "";
        static string OgAd = "";
        static string OgSoyad = "";

        string[] doldurOgrenci = new string[] {OgrNo, OgrAd , OgrSoyad };
        string[] doldurOgretmen = new string[] { OgSicilNo, OgAd, OgSoyad };
        string[] bosaltogr = new string[] { "", "", "" };
        string[] bosaltog = new string[] { "", "", "" };

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void BosaltLV()
        {
            lvOgretmen.Items.Clear();
            lvOgrenci.Items.Clear();
        }

        private void OgrenciKadro_Load(object sender, EventArgs e)
        {
            ogretmens = ogretmen.GetAll();
            ogrencis = ogrenci.GetAll();
           // KatilimciGorutule();
            lvOgrenci.Columns.Add("Okul No" ,100);
            lvOgrenci.Columns.Add("Ad", 80);
            lvOgrenci.Columns.Add("Soyad" ,150);
            lvOgretmen.Columns.Add("Sicil No" , 50);
            lvOgretmen.Columns.Add("Ad" ,80);
            lvOgretmen.Columns.Add("Soyad" , 200);
        }

        public void ListeDoldur(string Bolum)
        {
            foreach (var ogr in ogrencis)
            {
                if (ogr.BulunduguBolum== BolumAd)
                {
                    doldurOgrenci[0] = ogr.OgrenciNo;
                    doldurOgrenci[1] = ogr.OgrenciIsim;
                    doldurOgrenci[2] = ogr.OgrenciSoyisim;
                    ListViewItem list = new ListViewItem(doldurOgrenci);
                    lvOgrenci.Items.Add(list);
                }

            }
            foreach (var ogretmen in ogretmens)
            {
                if (ogretmen.OgrVerdigiBolum==BolumAd)
                {
                    doldurOgretmen[0] = (ogretmen.OgrSicilNo).ToString();
                    doldurOgretmen[1] = ogretmen.OgrAd;
                    doldurOgretmen[2] = ogretmen.OgrSoyad;
                    ListViewItem list2 = new ListViewItem(doldurOgretmen);
                    lvOgretmen.Items.Add(list2);

                }

            }
            

        }
        public void KatilimciGorutule()
        {
            KayitSayisi = lvOgrenci.Items.Count;
        }

        private void btnElektrik_Click(object sender, EventArgs e)
        {
            KatilimciGorutule();
            lblMevcud.Text = KayitSayisi.ToString();
            BolumAd = "ElektrikElektronik";
            BosaltLV();
            ListeDoldur( BolumAd);
        }

        private void btnBilgisayar_Click(object sender, EventArgs e)
        {
            KatilimciGorutule();
            lblMevcud.Text = KayitSayisi.ToString();
            BolumAd = "BilgisayarMühendisliği";
            BosaltLV();
            ListeDoldur(BolumAd);
        }

        private void btnEndusturi_Click(object sender, EventArgs e)
        {
            KatilimciGorutule();
            lblMevcud.Text = KayitSayisi.ToString();
            BolumAd = "Endüstri";
            BosaltLV();
            ListeDoldur(BolumAd);
        }

        private void btnMakine_Click(object sender, EventArgs e)
        {
            KatilimciGorutule();
            lblMevcud.Text = KayitSayisi.ToString();
            BolumAd = "Makina";
            BosaltLV();
            ListeDoldur(BolumAd);
        }

        private void btnInsaat_Click(object sender, EventArgs e)
        {

            KatilimciGorutule();
            lblMevcud.Text = KayitSayisi.ToString();
            BolumAd = "Insaat";
            BosaltLV();
            ListeDoldur(BolumAd);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void lvOgrenci_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
