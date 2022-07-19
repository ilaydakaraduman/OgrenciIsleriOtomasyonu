using OgrenciOtomasyonu.AlinanDersler;
using OgrenciOtomasyonu.BolumlerBilgi;
using OgrenciOtomasyonu.DerslerBilgi;
using OgrenciOtomasyonu.Kontroller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciOtomasyonu.Ogrenci
{
    public partial class CapOgrenci : Form
    {
        OgrenciKod ogrenciKod = new OgrenciKod();
        BolumKod bolumKod = new BolumKod();
        DersKod dersKod = new DersKod();
        AlinanDersKod alinanDersKod = new AlinanDersKod();
        ValidationKontrol validation = new ValidationKontrol();
        List<int> alinanDersId = new List<int>();
        List<string> alinanDersAd = new List<string>();
        string aldigiDersler = "";
        public string bolumIsmi;
        string VerilenDers = "";
        string ResimYer = "";
        string ResimDestination = "";
        string Path = "";
        //public string dgwTc;
        bool ResimSecildiMi;
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        bool TıklandıMi;
        public CapOgrenci()
        {
            InitializeComponent();
        }
        
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!OgrenciNoVarMıKontrol(tbxOgrenciNo.Text) && validation.TextBoxUzunlukKontrol(tbxTC.Text, 11) && validation.TextBoxUzunlukKontrol(tbxOgrenciNo.Text, 9) && validation.TextBoxUzunlukKontrol(tbxTelefon.Text, 11) && validation.OgrenciNoBolumKontrol(Convert.ToInt32(cbxBolum.SelectedValue), tbxOgrenciNo.Text))
            {
                if (bolumIsmi != cbxBolum.Text)
                {
                    ogrenciKod.Add(new Ogrenci
                    {
                        OgrenciNo = tbxOgrenciNo.Text,
                        OgrenciTc = tbxTC.Text,
                        OgrenciIsim = tbxIsim.Text,
                        OgrenciSoyisim = tbxSoyisim.Text,
                        BulunduguBolum = cbxBolum.Text,
                        Telefon = tbxTelefon.Text,
                        IsCap = checkCap.Checked.ToString(),
                        AldigiDersler = aldigiDersler,
                        BolumId = Convert.ToInt32(cbxBolum.SelectedValue.ToString()), // değiştirilecek
                        Ortalamasi = Convert.ToSingle(tbxOrtalama.Text),
                        Sifre = tbxSifre.Text,
                    });
                    ResimSec();
                    AlinanDerslerEkle();
                    alinanDersId.Clear();
                    alinanDersAd.Clear();
                    aldigiDersler = "";
                    MessageBox.Show("Öğrenci Eklendi");
                }
                else
                {
                    MessageBox.Show("Öğrencinin ana bilim dalıyla ÇAP aynı olamaz");
                }
            }
            else
            {
                MessageBox.Show("Öğrenci zaten mevcut");
            }
        }
        public bool OgrenciNoVarMıKontrol(string ogrenciNo)
        {
            bool isMatch = false;
            foreach (var ogrenci in ogrenciKod.GetAll())
            {
                if (ogrenci.OgrenciNo == ogrenciNo)
                {
                    isMatch = true;
                    return isMatch;
                }
            }
            return isMatch;
        }

        private void btnDersEkle_Click(object sender, EventArgs e)
        {

            if (!aldigiDersler.Contains(cbxDersler.SelectedValue.ToString()))
            {
                MessageBox.Show(cbxDersler.Text.ToString() + " eklendi.");
                aldigiDersler += cbxDersler.SelectedValue.ToString() + ",";
                alinanDersId.Add(Convert.ToInt32(cbxDersler.SelectedValue));
                alinanDersAd.Add(cbxDersler.Text);
            }
            else
            {
                MessageBox.Show("Zaten bu dersten almakta");
            }
        }
        public void AlinanDerslerEkle()
        {
            for (int i = 0; i < alinanDersAd.Count; i++)
            {
                alinanDersKod.Add(new AlinanDers
                {
                    DersAdi = alinanDersAd[i],
                    DersId = alinanDersId[i],
                    Final = 0,
                    Vize = 0,
                    OgrenciNo = tbxOgrenciNo.Text,
                    Ortalama = Convert.ToDecimal(tbxOrtalama.Text),
                });
            }
        }
        public void BolumDoldur()
        {
            cbxBolum.DataSource = bolumKod.GetAll();
            cbxBolum.DisplayMember = "BolumAd";
            cbxBolum.ValueMember = "BolumId";
        }
        public void DersDoldur()
        {
            if (cbxBolum.ValueMember.ToString() != "")
            {
                if (cbxBolum.SelectedValue != null)
                {
                    int bolumId = Convert.ToInt32(cbxBolum.SelectedValue.ToString());
                    cbxDersler.DataSource = dersKod.BolumlerinDersiniGetir(bolumId);
                    cbxDersler.DisplayMember = "DersAdı";
                    cbxDersler.ValueMember = "Id";
                }
            }
        }
     
        private void CapOgrenci_Load(object sender, EventArgs e)
        {
            Path = directory + @"OgrenciResim\";
            BolumDoldur();
        }



        public void ResimSec(string Urunresim)
        {
            ResimDestination = Path + Urunresim + ".jpg";
            File.Copy(ResimYer, ResimDestination);

        }
        public void ResimSec()
        {
            string resim = tbxTC.Text;
            ResimDestination = Path + resim + ".jpg";
            File.Copy(ResimYer, ResimDestination);


        }
        private void cbxBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            DersDoldur();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "Image Files(*.JPG;)|*.JPG;";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    ResimYer = dialog.FileName;
                    pbxOgr.ImageLocation = ResimYer;

                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnResimGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files(*.JPG;)|*.JPG;";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    ResimYer = dialog.FileName;
                    pbxOgr.ImageLocation = ResimYer;
                    TıklandıMi = true;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
