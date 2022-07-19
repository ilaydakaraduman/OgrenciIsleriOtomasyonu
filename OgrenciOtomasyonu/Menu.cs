using OgrenciOtomasyonu.AlinanDersler;
using OgrenciOtomasyonu.BolumlerBilgi;
using OgrenciOtomasyonu.DerslerBilgi;
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        

        private void btnOgrenci_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBolum_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDers_Click(object sender, EventArgs e)
        {
           

        }

        private void btnOgretmen_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNot_Click(object sender, EventArgs e)
        {
           
        }

        private void btnHakkımda_Click(object sender, EventArgs e)
        {
           

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bÖLÜMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciKayit ogrenciKayit = new OgrenciKayit();
            this.Hide();
            ogrenciKayit.Show();
        }

        private void öĞRETİMÜYESİToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BolumBilgi bolumBilgi = new BolumBilgi();
            this.Hide();
            bolumBilgi.Show();
        }

        private void dERSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DersBilgi ders = new DersBilgi();
            this.Hide();
            ders.Show();

        }

        private void öĞRETİMÜYESİToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OgretmenKayit ogretmen = new OgretmenKayit();
            this.Hide();
            ogretmen.Show();
        }

        private void nOTLANDIRMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notlandirma notlandirma = new Notlandirma();
            this.Hide();
            notlandirma.Show();
        }

        private void hAKKIMIZDAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hakkımızda hakkımızda = new Hakkımızda();
            this.Hide();
            hakkımızda.Show();
        }

        private void btnKadro_Click(object sender, EventArgs e)
        {
            OgrenciKadro kadro = new OgrenciKadro();
            this.Hide();
            kadro.Show();
        }
    }
}
