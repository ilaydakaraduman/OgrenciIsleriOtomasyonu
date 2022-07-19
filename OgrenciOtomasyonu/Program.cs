using OgrenciOtomasyonu.AlinanDersler;
using OgrenciOtomasyonu.BolumlerBilgi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciOtomasyonu
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BolumBilgi());
        }
    }
}
