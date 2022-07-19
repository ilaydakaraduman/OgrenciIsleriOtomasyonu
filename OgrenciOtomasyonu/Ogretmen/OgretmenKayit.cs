using OgrenciOtomasyonu.BolumlerBilgi;
using OgrenciOtomasyonu.DerslerBilgi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciOtomasyonu.Ogretmen
{
    public partial class OgretmenKayit : Form
    {
        public OgretmenKayit()
        {
            InitializeComponent();
        }
        Regex regex = new Regex(@"^(\d{11,11}$)");
        Regex regex2 = new Regex(@"^(?=.{6,15}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[@#$%*?^:;+-._,])(?=.*[0-9]).*");
        Regex regex3 = new Regex(@"^(\d{4,4}$)");
        string VerilenDers = "";
        string ResimYer = "";
        string ResimDestination = "";
        string Path = "";
        //public string dgwTc;
        bool ResimSecildiMi;
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        OgretmenKod _OgretmenKod = new OgretmenKod();
        DersKod ders = new DersKod();
        BolumKod bolum = new BolumKod();
        List<Ogretmen> siciller = new List<Ogretmen>();
        List<Ogretmen> tcKontrol = new List<Ogretmen>();
        List<Bolum> bolumkodlar = new List<Bolum>();
        //List<Ders> dersler = new List<Ders>();
        //List<Ders> bolumDersleri = new List<Ders>();
        string bolumKodu = "";
        int kodNo = 0;
        int SicilKontrol = 0;
        int OgretmenId = 0;
        bool girdiMiTc = false;
        bool GirdiMiSicil = false;
        bool TıklandıMi;


        private void OgretmenKayit_Load(object sender, EventArgs e)
        {
            siciller.AddRange(_OgretmenKod.GetAll());
            bolumkodlar = bolum.GetAll();
            tcKontrol = _OgretmenKod.GetAll();
            Path = directory + @"OgretmenResim\";
            BolumDoldur();
            DersDoldur();
            OgretmeNDoldur();
        }
        public void OgretmeNDoldur()
        {

            List<Ogretmen> ogretmen = _OgretmenKod.GetAll();
            dgwOgretmenGoruntule.DataSource = ogretmen;
        }
        public void Bosalt()
        {
            tbxOgrAd.Text = "";
            tbxOgrSoyad.Text = "";
            tbxOgrTc.Text = "";
            tbxOgrSicil.Text = "";
            tbxOgrSifre.Text = "";
            VerilenDers = "";
        }
        public void BolumDoldur()
        {
            cbxBolum.DataSource = bolum.GetAll();
            cbxBolum.DisplayMember = "BolumAd";
            cbxBolum.ValueMember = "BolumId";
        }
        public void DersDoldur()
        {
            if (cbxBolum.ValueMember.ToString() != "")
            {
                if (cbxBolum.SelectedValue != null)
                {
                    cbxDersler.DataSource = ders.BolumlerinDersiniGetir(Convert.ToInt32(cbxBolum.SelectedValue));
                    cbxDersler.DisplayMember = "DersAdi";
                    cbxDersler.ValueMember = "Id";
                }
            }
        }
        public void DersKoduBul()
        {
            foreach (var bolum in bolumkodlar)
            {
                if (cbxBolum.Text == bolum.BolumAd)
                {
                    bolumKodu = bolum.BolumKodu;
                }

            }
            kodNo = Convert.ToInt32(bolumKodu.Substring(bolumKodu.Length - 1));
            SicilKontrol = Convert.ToInt32(tbxOgrSicil.Text) / 1000;
            //label8.Text = kodNo.ToString();
        }
        public bool TcKontrolu()
        {
            foreach (var tc in tcKontrol)
            {
                if (tc.OgrTc != (tbxOgrTc.Text).ToString())
                {
                    girdiMiTc = false;
                }
                else
                {
                    girdiMiTc = true;

                }

            }
            return girdiMiTc;
        }
        public bool SicilKontrolu()
        {
            foreach (var sicil in siciller)
            {
                if (sicil.OgrSicilNo != Convert.ToInt32(tbxOgrSicil.Text) && kodNo == SicilKontrol)
                {

                    GirdiMiSicil = false;
                }
                else
                {
                    GirdiMiSicil = true;

                }

            }
            return GirdiMiSicil;
        }
        private void btnDersEkle_Click(object sender, EventArgs e)
        {
            if (!VerilenDers.Contains((cbxDersler.SelectedValue).ToString()))
            {
                VerilenDers += Convert.ToInt32(cbxDersler.SelectedValue) + ",";
                MessageBox.Show(cbxDersler.Text + " dersini eklediniz ");
            }
            else
            {
                MessageBox.Show("Bu dersi daha önce eklemiştiniz   :" + cbxDersler.Text);
            }


        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (regex2.Match(tbxOgrSifre.Text).Success)//şifre oluşturma kuralı
                {


                    if (regex.Match(tbxOgrTc.Text).Success)//tc kimlik hane kontrol
                    {
                        DersKoduBul();
                        if (!TcKontrolu())
                        {

                            if (regex3.Match(tbxOgrSicil.Text).Success) //sicil no
                            {

                                if (!SicilKontrolu())
                                {

                                    _OgretmenKod.Add(new Ogretmen
                                    {
                                        OgrAd = tbxOgrAd.Text,
                                        OgrSoyad = tbxOgrSoyad.Text,
                                        OgrTc = tbxOgrTc.Text,
                                        OgrSicilNo = Convert.ToInt32(tbxOgrSicil.Text),
                                        OgrVerdigiBolum = (cbxBolum.Text).ToString(),
                                        OgrVerdigiDersler = VerilenDers,
                                        Sifre = tbxOgrSifre.Text,
                                        BolumId = Convert.ToInt32(cbxBolum.SelectedValue),

                                    });
                                    ResimSec();
                                    OgretmeNDoldur();

                                    MessageBox.Show("Ögretmen Sistemimize Başarıyla Eklenmiştir");
                                }
                                else
                                {
                                    MessageBox.Show("Vermiş olduğunuz sicil numarası kullanılmaktadır veya kurallara uymamaktadır lütfen tekrar deneyiniz..");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Vermiş olduğunuz sicil numarası 4 haneden fazla eklenmiştir lütfen tekrar deneyiniz..");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Yazdıgınız tc de sistemde bulunmaktadır");
                        }

                    }

                    else
                    {
                        MessageBox.Show("TC Kimlik numarası eksik veya fazla yazılmıştır lütfen kontrol ediniz");
                    }


                }
                else
                {
                    MessageBox.Show(" Güvenlik Açısından oluşturduğunuz Şifre '6-15 karekter arasında olması ve min 1 küçük ve buyuk harf bulundurmaktadır.Güvenliği arttırmak amacıyla @#$%*?^:;+-._, özel karakterini kullanmanız gerekmektedir.");
                }

            }
            catch (Exception _hata)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu!" + _hata.Message);
            }



        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (regex2.Match(tbxOgrSifre.Text).Success)//şifre oluşturma kuralı
                {


                    if (regex.Match(tbxOgrTc.Text).Success)//tc kimlik hane kontrol
                    {
                        DersKoduBul();
                        if (!TcKontrolu()) //tc geçmişte yazılmış mı
                        {

                            if (regex3.Match(tbxOgrSicil.Text).Success) //sicil no
                            {

                                if (!SicilKontrolu())
                                {

                                    _OgretmenKod.Update(new Ogretmen
                                    {
                                        OgrId = OgretmenId,
                                        OgrAd = tbxOgrAd.Text,
                                        OgrSoyad = tbxOgrSoyad.Text,
                                        OgrTc = tbxOgrTc.Text,
                                        OgrSicilNo = Convert.ToInt32(tbxOgrSicil.Text),
                                        OgrVerdigiBolum = cbxBolum.Text,
                                        OgrVerdigiDersler = VerilenDers,
                                        Sifre = tbxOgrSifre.Text,
                                        BolumId = Convert.ToInt32(cbxBolum.SelectedValue),

                                    });
                                    if (ResimSecildiMi)
                                    {
                                        File.Delete(Path + tbxOgrTc.Text + ".jpg");
                                        ResimSec(tbxOgrTc.Text);
                                    }
                                    OgretmeNDoldur();

                                    MessageBox.Show("Ögretmen Sistemimize Başarıyla Güncellenmiştir");
                                }

                                else
                                {
                                    MessageBox.Show("Vermiş olduğunuz sicil numarası kullanılmaktadır veya kurallara uymamaktadır lütfen tekrar deneyiniz..");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Vermiş olduğunuz sicil numarası 4 haneden fazla eklenmiştir lütfen tekrar deneyiniz..");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Yazdıgınız tc de sistemde bulunmaktadır");
                        }



                    }
                    else
                    {
                        MessageBox.Show("TC Kimlik numarası eksik veya fazla yazılmıştır lütfen kontrol ediniz");
                    }



                }
                else
                {
                    MessageBox.Show(" Güvenlik Açısından oluşturduğunuz Şifre '6-15 karekter arasında olması ve min 1 küçük ve buyuk harf bulundurmaktadır.Güvenliği arttırmak amacıyla @#$%*?^:;+-._, özel karakterini kullanmanız gerekmektedir.");
                }

            }
            catch (Exception _hata)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu!" + _hata.Message);
            }

        }
        public void ResimSec(string Urunresim)
        {
            ResimDestination = Path + Urunresim + ".jpg";
            File.Copy(ResimYer, ResimDestination);

        }
        public void ResimSec()
        {
            string resim = tbxOgrTc.Text;
            ResimDestination = Path + resim + ".jpg";
            File.Copy(ResimYer, ResimDestination);


        }

        private void btnBosalt_Click(object sender, EventArgs e)
        {
            Bosalt();
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

        private void btnSilme_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwOgretmenGoruntule.CurrentRow.Cells[0].Value);
            _OgretmenKod.Delete(id);
            if (MessageBox.Show("Silmek istediğine emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Öğretmen Sistemimize Başarıyla Silinmiştir");
            }
            dgwOgretmenGoruntule.DataSource = _OgretmenKod.GetAll();

        }

        private void tbxArama_TextChanged(object sender, EventArgs e)
        {
            dgwOgretmenGoruntule.DataSource = _OgretmenKod.Search(tbxArama.Text);
        }

        private void cbxDersler_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void dgwOgretmenGoruntule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            OgretmenId = Convert.ToInt32(dgwOgretmenGoruntule.CurrentRow.Cells[0].Value);
            tbxOgrTc.Text = dgwOgretmenGoruntule.CurrentRow.Cells[1].Value.ToString();
            tbxOgrAd.Text = dgwOgretmenGoruntule.CurrentRow.Cells[2].Value.ToString();
            tbxOgrSoyad.Text = dgwOgretmenGoruntule.CurrentRow.Cells[3].Value.ToString();
            tbxOgrSicil.Text = dgwOgretmenGoruntule.CurrentRow.Cells[4].Value.ToString();
            int index = cbxBolum.FindString(dgwOgretmenGoruntule.CurrentRow.Cells[5].Value.ToString());
            cbxBolum.SelectedIndex = index;
            VerilenDers = dgwOgretmenGoruntule.CurrentRow.Cells[6].Value.ToString();
            tbxOgrSifre.Text = dgwOgretmenGoruntule.CurrentRow.Cells[7].Value.ToString();
            pbxOgr.ImageLocation = Path + dgwOgretmenGoruntule.CurrentRow.Cells[1].Value.ToString() + ".jpg";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void cbxBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxBolum.Text != "")
            {
                DersDoldur();
            }
        }
    }
}
