using Entities.Concrete;
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

namespace UserInterface
{
    public partial class OgrenciForm : Form
    {
        IOgrenciService ogrenciService;   //yeni nesne
        IEmanetService emanetService;  //yeni nesne
        Ogrenci suankiOgrenci;
        public OgrenciForm(Ogrenci ogrenci)
        {
            InitializeComponent();
            ogrenciService = new OgrenciService();  //yeni nesne
            emanetService = new EmanetService();  //yeni nesne
            suankiOgrenci = ogrenci;  //yeni nesne
            Doldur();  //Doldur metodumuzu  çağırıyoruz
            DataGridFill();  //DataGridFill'i çağırıyoruz.
        }

        private void DataGridFill()
        {
            string Ad = textBox1.Text;  //adı textBox'a yazdırmak için
            Ogrenci ogrenci = ogrenciService.OgrBul(Ad);  // ogrenci adında yeni nesne
            dGwlistele.DataSource = emanetService.listele().Where(x => x.Ogrenci_Id == ogrenci.Id).ToList(); //emanetService'deki öğrenci id'sine göre hangi kitapları aldığını bulmak için
        }

        private void Doldur()  // şifre girilince direk textBox'lara doldurması için
        {
            textBox1.Text = suankiOgrenci.Ad;  //textBox'a adı atadık
            textBox2.Text = suankiOgrenci.Soyad;  //textBox'a soyadı atadık
            textBox3.Text = suankiOgrenci.Tel;  //textBox'a teli atadık
            textBox4.Text = suankiOgrenci.Eposta;  //textBox'a epostayı atadık
            textBox5.Text = suankiOgrenci.Adres;  //textBox'a adresi atadık
            textBox6.Text = suankiOgrenci.Sifre;  //textBox'a şifreyi atadık
            textBox7.Text = suankiOgrenci.Tc;  //textBox'a tc'yi atadık
            textBox8.Text = Convert.ToInt32(suankiOgrenci.Borc).ToString(); //textBox'a borcu atadık
            textBox9.Text = Convert.ToInt32(suankiOgrenci.Id).ToString(); //textBox'a Id'yi atadık
        }


        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            Baslangic bs = new Baslangic();  //Baslangıca geri dönmek için yeni nesne 
            bs.Show();  //göstermesi için
            this.Close();  //tıklandıktan sonra bunu kapatması için
        }

        private void OgrenciForm_Load(object sender, EventArgs e)
        {

        }
    }
}
