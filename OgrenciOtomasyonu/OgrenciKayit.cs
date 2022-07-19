using OgrenciOtomasyonu.AlinanDersler;
using OgrenciOtomasyonu.BolumlerBilgi;
using OgrenciOtomasyonu.DerslerBilgi;
using OgrenciOtomasyonu.Kontroller;
using OgrenciOtomasyonu.Ogrenci;
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

namespace OgrenciOtomasyonu
{
    public partial class OgrenciKayit : Form
    {
        public OgrenciKayit()
        {
            InitializeComponent();
        }
        BolumKod bolumKod = new BolumKod();
        DersKod dersKod = new DersKod();
        AlinanDersKod alinanDersKod = new AlinanDersKod();
        OgrenciKod ogrenciKod = new OgrenciKod();
        List<Ders> filtreliDersler = new List<Ders>();
        List<int> alinanDersId = new List<int>();
        List<string> alinanDersAd = new List<string>();
        List<int> alinanDersKredi = new List<int>();
        ValidationKontrol validation = new ValidationKontrol();
        string aldigiDersler = "";
        int ogrenciId;
        int bolumId;
        string VerilenDers = "";
        string ResimYer = "";
        string ResimDestination = "";
        string Path = "";
        //public string dgwTc;
        bool ResimSecildiMi;
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        bool TıklandıMi;
        private void OgrenciKayit_Load(object sender, EventArgs e)
        {
            Path = directory + @"OgrenciResim\";
            BolumDoldur();
            OgrencileriDoldur();
            FiltreKategoriDoldur();
            
        }
        public void OgrencileriDoldur()
        {
            dgwOgrenciler.DataSource = ogrenciKod.GetAll();
        }
        public void OgrenciFiltreliDoldur(int Id)
        {
            dgwOgrenciler.DataSource = ogrenciKod.BolumFiltreliOgrenci(Id); 
        }
        public void FiltreKategoriDoldur()
        {
            cbxBolumFiltre.DataSource = bolumKod.GetAll();
            cbxBolumFiltre.DisplayMember = "BolumAd";
            cbxBolumFiltre.ValueMember = "BolumId";
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (TcVarMıKontrol(tbxTC.Text) && !OgrenciNoVarMıKontrol(tbxOgrenciNo.Text) && validation.TextBoxUzunlukKontrol(tbxTC.Text,11) && validation.TextBoxUzunlukKontrol(tbxOgrenciNo.Text, 9) && validation.TextBoxUzunlukKontrol(tbxTelefon.Text, 11) && validation.OgrenciNoBolumKontrol(Convert.ToInt32(cbxBolum.SelectedValue), tbxOgrenciNo.Text))
            {
                ogrenciKod.Add(new Ogrenci.Ogrenci
                {
                    OgrenciNo = tbxOgrenciNo.Text,
                    OgrenciTc = tbxTC.Text,
                    OgrenciIsim = tbxIsim.Text,
                    OgrenciSoyisim = tbxSoyisim.Text,
                    BulunduguBolum = cbxBolum.Text,
                    Telefon = tbxTelefon.Text,
                    IsCap = checkCap.Checked.ToString(),
                    AldigiDersler = aldigiDersler,
                    BolumId = Convert.ToInt32(cbxBolum.SelectedValue),
                    Ortalamasi = Convert.ToDouble(tbxOrtalama.Text),
                    Sifre = tbxSifre.Text,
                });
                ResimSec();
                AlinanDerslerEkle();
                OgrencileriDoldur();
                alinanDersId.Clear();
                alinanDersAd.Clear();
                aldigiDersler = "";
                MessageBox.Show("Öğrenci Kaydı Gerçekleşti");
            }
           
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
        public bool TcVarMıKontrol(string Tc)
        {
            foreach (var ogrenci in ogrenciKod.GetAll())
            {
                if(ogrenci.OgrenciTc == Tc && ogrenci.IsCap =="False")
                {
                    MessageBox.Show("Öreci zaten mevcut");
                    return false;
                }
            }
            return true ;
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
                    DersKredi = alinanDersKredi[i],
                });
            }
        }

        private void btnDersEkle_Click(object sender, EventArgs e)
        {
            if (!aldigiDersler.Contains(cbxDersler.SelectedValue.ToString()))
            {
                MessageBox.Show(cbxDersler.Text.ToString() + " eklendi.");
                aldigiDersler += cbxDersler.SelectedValue.ToString() + ",";
                alinanDersId.Add(Convert.ToInt32(cbxDersler.SelectedValue));
                alinanDersAd.Add(cbxDersler.Text);
                
                foreach (var ders in dersKod.GetAll())
                {
                    if (ders.Id == Convert.ToInt32(cbxDersler.SelectedValue))
                    {
                        alinanDersKredi.Add(ders.Kredi);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Zaten bu dersten almakta");
            }
         
        }
       
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (validation.TextBoxUzunlukKontrol(tbxTC.Text, 11) && validation.TextBoxUzunlukKontrol(tbxOgrenciNo.Text, 9) && validation.TextBoxUzunlukKontrol(tbxTelefon.Text, 11) && validation.OgrenciNoBolumKontrol(Convert.ToInt32(cbxBolum.SelectedValue), tbxOgrenciNo.Text))
            {
                ogrenciKod.Update(new Ogrenci.Ogrenci
                {
                    OgrenciId = ogrenciId,
                    OgrenciNo = tbxOgrenciNo.Text,
                    OgrenciTc = tbxTC.Text,
                    OgrenciIsim = tbxIsim.Text,
                    OgrenciSoyisim = tbxSoyisim.Text,
                    BulunduguBolum = cbxBolum.Text,
                    Telefon = tbxTelefon.Text,
                    IsCap = checkCap.Checked.ToString(),
                    AldigiDersler = aldigiDersler, // index değiştir
                    BolumId = Convert.ToInt32(cbxBolum.SelectedValue.ToString()),
                    Ortalamasi = Convert.ToSingle(tbxOrtalama.Text),
                    Sifre = tbxSifre.Text,
                });
                if (ResimSecildiMi)
                {
                    File.Delete(Path + tbxTC.Text + ".jpg");
                    ResimSec(tbxTC.Text);
                }
                OgrencileriDoldur();
                AlinanDerslerEkle();
                MessageBox.Show("Güncelleme Gerçekleşti");
            }
                
        }
        private void dgwOgrenciler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ogrenciId = Convert.ToInt32( dgwOgrenciler.CurrentRow.Cells[0].Value.ToString());
            tbxOgrenciNo.Text = dgwOgrenciler.CurrentRow.Cells[1].Value.ToString();
            tbxTC.Text = dgwOgrenciler.CurrentRow.Cells[2].Value.ToString();
            tbxIsim.Text = dgwOgrenciler.CurrentRow.Cells[3].Value.ToString();
            tbxSoyisim.Text = dgwOgrenciler.CurrentRow.Cells[4].Value.ToString();
            int index = cbxBolum.FindString(dgwOgrenciler.CurrentRow.Cells[5].Value.ToString());
            cbxBolum.SelectedIndex = index;
            DersDoldur();
            tbxTelefon.Text = dgwOgrenciler.CurrentRow.Cells[6].Value.ToString();
            checkCap.Checked = Convert.ToBoolean(dgwOgrenciler.CurrentRow.Cells[7].Value.ToString());
            aldigiDersler = dgwOgrenciler.CurrentRow.Cells[8].Value.ToString(); 
            tbxOrtalama.Text = dgwOgrenciler.CurrentRow.Cells[9].Value.ToString() ;
            bolumId = Convert.ToInt32(dgwOgrenciler.CurrentRow.Cells[10].Value.ToString());
            tbxSifre.Text = dgwOgrenciler.CurrentRow.Cells[11].Value.ToString();
            pbxOgr.ImageLocation = Path + dgwOgrenciler.CurrentRow.Cells[1].Value.ToString() + ".jpg";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ogrenciKod.Delete(ogrenciId);
            OgrencileriDoldur();
        }

        private void checkCap_Click(object sender, EventArgs e)
        {
            CapOgrenci capOgrenci = new CapOgrenci();
            capOgrenci.tbxIsim.Text = tbxIsim.Text;
            capOgrenci.tbxSoyisim.Text = tbxSoyisim.Text;
            capOgrenci.tbxTC.Text = tbxTC.Text;
            capOgrenci.tbxTelefon.Text = tbxTelefon.Text;
            capOgrenci.tbxSifre.Text = tbxSifre.Text;
            capOgrenci.bolumIsmi = cbxBolum.Text;
            capOgrenci.Show();
        }

        
        
        public bool OgrenciNoVarMıKontrol(string ogrenciNo)
        {
             bool isMatch = false;
            foreach (var ogrenci in ogrenciKod.GetAll())
            {
                if(ogrenci.OgrenciNo == ogrenciNo)
                {
                    isMatch = true;
                    return isMatch;
                }
            }
            return isMatch;
        }
        public void BolumDoldur()
        {
            cbxBolum.DataSource = bolumKod.GetAll();
            cbxBolum.DisplayMember = "BolumAd";
            cbxBolum.ValueMember = "BolumId";
        }
        public void DersDoldur()
        {
            if(cbxBolum.ValueMember.ToString() != "")
            {
                if(cbxBolum.SelectedValue != null)
                {
                    int bolumId = Convert.ToInt32(cbxBolum.SelectedValue.ToString());
                    cbxDersler.DataSource = dersKod.BolumlerinDersiniGetir(bolumId);
                    cbxDersler.DisplayMember = "DersAdi";
                    cbxDersler.ValueMember = "Id";
                }
            }
        }
        private void cbxBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            DersDoldur();
            aldigiDersler = "";
        }
        int tutucu = 0;
        private void cbxBolumFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(tutucu != 0)
                {
                    OgrenciFiltreliDoldur(Convert.ToInt32(cbxBolumFiltre.SelectedValue.ToString()));
                }
                tutucu++;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSıfırla_Click(object sender, EventArgs e)
        {
            OgrencileriDoldur();
        }

        private void tbxOgrenciNoFilter_TextChanged(object sender, EventArgs e)
        {
            if(tbxOgrenciNoFilter.Text != "")
            {
                dgwOgrenciler.DataSource = ogrenciKod.OgrenciNoFiltreliOgrenci(tbxOgrenciNoFilter.Text);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
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
                    ResimSecildiMi = true;

                }

            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
   
}
