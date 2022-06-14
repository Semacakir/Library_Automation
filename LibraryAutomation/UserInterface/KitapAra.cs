using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Entities.Concrete;
using Service.Concrete;
using Service.Interfaces;

namespace UserInterface
{
    public partial class KitapAra : Form
    {
        IKitapService kitapService;  //yeni nesne
        IEmanetService emanetService;   //yeni nesne
        List<Kitap> kitaplar;  //kitaplar adında nesne
        public KitapAra()
        {
            InitializeComponent();
            kitapService = new KitapService();  //yeni nesne
            emanetService = new EmanetService();  //yeni nesne
            kitaplar = kitapService.listele();  //kitaplar adında yeni nesne
            DataGridViewFill();  //DataGridFill çağrıldı.
        }
     

        private void KitapAra_Load(object sender, EventArgs e)
        {

        }
        private void DataGridViewFill()
        {
            dtvlistele.DataSource = emanetService.listele();  //dtvListele'ye emanetService listelendi
            dtvlistele.DataSource = kitaplar; kitaplar = kitapService.listele();   //kitapService listelendi.
            dtvlistele.DataSource = kitaplar;
        }

            private void btnBul_Click(object sender, EventArgs e)
        {
            string Adi = textBox1.Text;  //Adı girdiriyoruz.
            if (!String.IsNullOrEmpty(textBox1.Text)) 
            {
               
                Kitap suankikitaplar = kitaplar.FirstOrDefault(y => y.Adi == Adi);
                if (suankikitaplar != null)  //değer boş değilse içeri gir
                {
                    txtkad.Text = suankikitaplar.Adi.ToString();  //adı ata
                    txtyazar.Text = suankikitaplar.Yazari.ToString();  //yazarı ata
                    txtsayfasayisi.Text = suankikitaplar.SayfaSayisi.ToString();  //sayfasayısını ata
                    txtbasimtarihi.Text = suankikitaplar.BasimTarihi.ToString();  //basımtarihini ata
                    txttur.Text = suankikitaplar.Turu.ToString();  //turunu ata
                    txtkid.Text = suankikitaplar.Id.ToString();  //id sini ata
                }
            }

            Kitap kitap = kitapService.KitapBul(Adi);  //KitapBul metodunu çağırdık
            
            dtvlistele.DataSource = emanetService.listele().Where(x => x.Kitap_Id == kitap.Id).ToList();
            //emanetService'teki Kitap_Id'sine göre kimlere verildiğinin sprgusunu yazdık.      
        }

        private void dtvlistele_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            Baslangic bs = new Baslangic();  //Başlangıça geri dönemk için yeni nesne
            bs.Show();  //göstermesi için
            this.Close();  //kapatması için
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Grafikler gf = new Grafikler();  //Grafiklere gitmek için yeni nesne
            gf.Show();  //Göstermesi için
            this.Close();  //kapatması için
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
