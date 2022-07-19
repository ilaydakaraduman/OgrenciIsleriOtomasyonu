using OgrenciOtomasyonu.BolumlerBilgi;
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

namespace OgrenciOtomasyonu.DerslerBilgi
{
    public partial class DersBilgi : Form
    {
        BolumKod bolumler = new BolumKod();
        OgretmenKod ogretmenler = new OgretmenKod();
        DersKod dersler = new DersKod();
        int DersId=0;
        List<Bolum> bolums = new List<Bolum>();
        List<Ders> dersk = new List<Ders>();
        List<Ogretmen.Ogretmen> ogretmens = new List<Ogretmen.Ogretmen>();
        string  AdSoyad = "";
        string BolumDersKod = "";
        string OgretimUye = "";
        bool KodKontrol = false;
        bool KodVar = false;
        public DersBilgi()
        {
            InitializeComponent();
        }
        private void DersBilgi_Load(object sender, EventArgs e)
        {
            bolums = bolumler.GetAll();
            
            dersk = dersler.GetAll();
             DersleriDoldur();
            BolumDoldur();
            HocaDoldur();
           // DerskodKontrol();
        }

        public void DersleriDoldur()
        {
            dgwDersler.DataSource = dersler.GetAll();
        }
        public void BolumDoldur()
        {
            cbxBolum.DataSource = bolumler.GetAll();
            cbxBolum.DisplayMember = "BolumAd";
            cbxBolum.ValueMember = "BolumId";
        }
        public void HocaDoldur()
        {
            List<string> birlestir = new List<string>();
           
            foreach (var ogretmen in ogretmens)
            {
                AdSoyad = ogretmen.OgrAd + " " + ogretmen.OgrSoyad;
                birlestir.Add(AdSoyad);
               
            }


            cbxOgretimUyesi.DataSource = birlestir;
            
        }
        public bool DerskodKontrol()
        {
            foreach (var bolumKd in bolums)
            {
                if (bolumKd.BolumAd==cbxBolum.Text)
                {
                    BolumDersKod= bolumKd.BolumKodu;
                }

            }
            if ((tbxDersKodu.Text).StartsWith(BolumDersKod))
            {
                KodKontrol = true;
                
            }
            else
            {
                KodKontrol = false;
            }

            return KodKontrol;

        }
        public bool KodVarMi()
        {
            foreach (var kod in dersk)
            {
                if (tbxDersKodu.Text==kod.DersKodu)
                {
                    KodVar = true;
                }
                else
                {
                    KodVar = false;
                }

            }
            return KodVar;

        }
       

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (DerskodKontrol())
                {
                    if (!KodVarMi())
                    {
                        if (MessageBox.Show("Eklemek istediğine emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            dersler.Add(new Ders
                            {


                                DersKodu = tbxDersKodu.Text,
                                Kredi = Convert.ToInt32(tbxKredi.Text),
                                Bolum = cbxBolum.Text,
                                OgretimUyesi = OgretimUye,
                                Derslik = tbxDerslik.Text,
                                BolumId = Convert.ToInt32(cbxBolum.SelectedValue),
                                DersAdi = tbxDersAdi.Text,



                            });
                            MessageBox.Show("Ders Sistemimize Başarıyla Eklenmiştir");
                        }
                        DersleriDoldur();

                    }
                    else
                    {
                        MessageBox.Show("Dersin kodu başr ka bir derse aittir lütfen tekra girdiniz");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Dersin kodunu hatalı girdiniz");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu .. " + ex.Message);
                
            }
           

        }
        public void Bosalt()
        {
            tbxDersAdi.Text = "";
            tbxDersKodu.Text = "";
            tbxKredi.Text = "";
            tbxDerslik.Text = "";
            OgretimUye = "";
            DersleriDoldur();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void dgwDersler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DersId = Convert.ToInt32(dgwDersler.CurrentRow.Cells[0].Value);
            tbxDersKodu.Text= dgwDersler.CurrentRow.Cells[1].Value.ToString();
            tbxKredi.Text = dgwDersler.CurrentRow.Cells[2].Value.ToString();
            cbxBolum.Text= dgwDersler.CurrentRow.Cells[3].Value.ToString();
            OgretimUye = dgwDersler.CurrentRow.Cells[4].Value.ToString();
            tbxDerslik.Text= dgwDersler.CurrentRow.Cells[5].Value.ToString();
            int index = cbxBolum.FindString(dgwDersler.CurrentRow.Cells[6].Value.ToString());
            cbxBolum.SelectedIndex = index;
            tbxDersAdi.Text= dgwDersler.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Silmek istediğine emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgwDersler.CurrentRow.Cells[0].Value);
                dersler.Delete(id);
                MessageBox.Show("Ders Sistemimize Başarıyla Silinmiştir");
            }
            DersleriDoldur();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Bosalt();
        }

        private void tbxArama_TextChanged(object sender, EventArgs e)
        {
            dgwDersler.DataSource = dersler.Search(tbxArama.Text);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (DerskodKontrol())
                {
                    if (!KodVarMi())
                    {
                        if (MessageBox.Show("Eklemek istediğine emin misiniz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                            dersler.Update(new Ders
                            {
                                Id= DersId,
                                DersAdi = tbxDersAdi.Text,
                                DersKodu = tbxDersKodu.Text,
                                Bolum = cbxBolum.Text,
                                Derslik = tbxDerslik.Text,
                                OgretimUyesi= OgretimUye,
                                Kredi = Convert.ToInt32(tbxKredi.Text),
                                BolumId = Convert.ToInt32(cbxBolum.SelectedValue),


                            });

                    }
                    else
                    {
                        MessageBox.Show("Dersin kodu başr ka bir derse aittir lütfen tekra girdiniz");
                    }


                }
                else
                {
                    MessageBox.Show("Dersin kodunu hatalı girdiniz");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu .. " + ex.Message);

            }


        }

        private void btnOgretmenEkle_Click(object sender, EventArgs e)
        {
            if (!OgretimUye.Contains((cbxOgretimUyesi.SelectedValue).ToString()))
            {
                OgretimUye += cbxOgretimUyesi.Text + ",";
                MessageBox.Show(cbxOgretimUyesi.Text + " Hocasını eklediniz ");
            }
            else
            {
                MessageBox.Show("Bu Hocayı daha önce eklemiştiniz   :" + cbxOgretimUyesi.Text);
            }
        }

        private void cbxOgretimUyesi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxBolum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxBolum.ValueMember.ToString()!="")
            {
                OgretmenFiltrele(Convert.ToInt32(cbxBolum.SelectedValue));
            }
            

        }
        public void OgretmenFiltrele(int bolum)
        {
            ogretmens = ogretmenler.BolumlerinOgretmenleriGetir(bolum);
            HocaDoldur();
        }
    }
}
