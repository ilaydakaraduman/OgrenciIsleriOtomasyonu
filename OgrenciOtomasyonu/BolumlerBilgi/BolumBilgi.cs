using OgrenciOtomasyonu.DerslerBilgi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciOtomasyonu.BolumlerBilgi
{
    public partial class BolumBilgi : Form
    {
        BolumKod bolumKod = new BolumKod();
        DersKod dersKod = new DersKod();
        List<Bolum> bolumler = new List<Bolum>();
        string dersler = "";
        string bolumKodTutucu = "";
        int bolumId;
        public BolumBilgi()
        {
            InitializeComponent();
        }

        private void BolumBilgi_Load(object sender, EventArgs e)
        {

            BolumDoldur();
            DersDoldur();

        }
        public void BolumDoldur()
        {

            bolumler = bolumKod.GetAll();
            dgwBolumler.DataSource = bolumKod.GetAll();
            bolumKodTutucu = "B" + (bolumler.Count + 1);
            tbxBolumKod.Text = bolumKodTutucu;
        }
        public void DersDoldur()
        {
            cbxDersler.DataSource = dersKod.GetAll();
            cbxDersler.DisplayMember = "DersAdı";
            cbxDersler.ValueMember = "Id";
        }
        private void dgwBolumler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bolumId = Convert.ToInt32(dgwBolumler.CurrentRow.Cells[0].Value);
            tbxBolumAd.Text = dgwBolumler.CurrentRow.Cells[1].Value.ToString();
            tbxBolumKod.Text = dgwBolumler.CurrentRow.Cells[2].Value.ToString();
            dersler = dgwBolumler.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if(tbxBolumAd.Text != "")
                {
                    bolumKod.Add(new Bolum
                    {
                        BolumAd = tbxBolumAd.Text,
                        BolumKodu = tbxBolumKod.Text,
                        AlinanDersler = dersler,
                    });
                    BolumDoldur();
                    MessageBox.Show(tbxBolumAd.Text + " bölümü eklendi");
                }
                else
                {
                    MessageBox.Show("Bölüm adı boş bırakılamaz");
                }
               
            }
            catch (Exception)
            {
                MessageBox.Show("Bir problem oluştu");
            }
        }

        private void tbxBolumAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSıfırla_Click(object sender, EventArgs e)
        {
            tbxBolumAd.Text = "";
            tbxBolumKod.Text = bolumKodTutucu;
            dersler = "";
        }

        private void btnDersEkle_Click(object sender, EventArgs e)
        {
            if (!dersler.Contains(cbxDersler.SelectedValue.ToString()))
            {
                MessageBox.Show(cbxDersler.Text.ToString() + " eklendi.");
                dersler += cbxDersler.SelectedValue.ToString() + ",";
            }
            else
            {
                MessageBox.Show("Zaten bu dersten almakta");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                bolumKod.Delete(Convert.ToInt32(dgwBolumler.CurrentRow.Cells[0].Value));
                BolumDoldur();
                MessageBox.Show(dgwBolumler.CurrentRow.Cells[1].Value.ToString() + " silindi");
            }
            catch (Exception)
            {

                MessageBox.Show("Bir sorun oluştu");
            }
          
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxBolumAd.Text != "")
                {
                    bolumKod.Update(new Bolum
                    { 
                        BolumId=bolumId,
                        BolumAd = tbxBolumAd.Text,
                        BolumKodu = tbxBolumKod.Text,
                        AlinanDersler = dersler,
                    });
                    BolumDoldur();
                    MessageBox.Show(tbxBolumAd.Text + " bölümü eklendi");
                }
                else
                {
                    MessageBox.Show("Bölüm adı boş bırakılamaz");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Bir problem oluştu");
            }
        }
    }
}
