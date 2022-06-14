using Service.Concrete;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace UserInterface
{
    public partial class Grafikler : Form
    {
        IKitapService kitapService;  //yeni nesne
        IEmanetService emanetService;   //yeni nesne
        public Grafikler()
        {
            InitializeComponent();
            kitapService = new KitapService();  //yeni nesne
            emanetService = new EmanetService();  //yeni nesne
            drawGraph();  //drawGraph metodu çağrıldı.
        }
       
        private void drawGraph()
        {
            
            GraphPane myPane = new GraphPane();  //myPane adında yeni nesne
            zedGraphControl1.GraphPane = myPane;

            myPane.Title.Text = "Kütüphane Grafiğimiz";  //Grafik başlığı
            myPane.XAxis.Title.Text = "Yer";  //XAxis adı
            myPane.YAxis.Title.Text = "Sayı";  //YAxis adı
            string[] x0 = new string[3];  //string değerler girilebilir
            double[] y0 = new double[3];  //double değerlerde olabilir.

            int Kutuphanedeki_kitap_sayisi = kitapService.listele().Count; //kitapService'teki kitapları saymak için
            int emanet_sayi = emanetService.listele().Count;//emanet listesi sayımı
            int verilebilecek_kitaplar = kitapService.listele().Count - emanetService.listele().Count;//kitaptan emanet sayısını çıkarıp atama yapma

            x0[0] = "Kütüphanedeki \nKitap Sayısı"; //kutuphanede bulunan kitap sayisi
            x0[1] = "Verilen \nKitap Sayısı"; //Verilen Kitap sayısı
            x0[2] = "Verilebilecek \nKitap Sayısı"; //Verilebilecek Kitap sayısı
            y0[0] = Kutuphanedeki_kitap_sayisi;//ifade ataması
            y0[1] = emanet_sayi;//ifade ataması
            y0[2] = verilebilecek_kitaplar;//ifade ataması

            BarItem myCurve;
            myCurve = myPane.AddBar("Book Item Count", null, y0, Color.Red);
            myCurve.Bar.Fill = new Fill(Color.Brown, Color.Brown, Color.Brown, 0f); //renkleri belirliyoruz
            myPane.XAxis.Scale.TextLabels = x0; //Xasis label'indeki yazıyı yazdı
            myPane.XAxis.Type = AxisType.Text; //Type ı verildi
            myPane.BarSettings.Base = BarBase.X;//Base
            myPane.AxisChange();

        }
        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
        }

    }
}
