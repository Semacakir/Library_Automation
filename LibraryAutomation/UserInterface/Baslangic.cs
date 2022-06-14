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
    public partial class Baslangic : Form
    {
        public Baslangic()
        {
            InitializeComponent();
        }

        OgrenciGiris ogrgiris = new OgrenciGiris(); //buton ile yönlendirme sağlamak için ogrgiris adında yeni bir nesne tanımlandı.
        PersonelGiris prsgiris = new PersonelGiris();  //buton ile yönlendirme sağlamak için prsgiris adında yeni bir nesne tanımlandı.
        KitapAra ktpara = new KitapAra();  //buton ile yönlendirme sağlamak için ktpara adında yeni bir nesne tanımlandı.

        private void btnpersonel_Click(object sender, EventArgs e)
        {
            prsgiris.Show();  //butona tıklanınca PersonelGiris sayfasına göstermesi için.
            this.Hide();  //kapatması için
        } 

        private void btnogr_Click(object sender, EventArgs e)
        {
            ogrgiris.Show();  //butona tıklanınca ÖğrenciGiris sayfasına göstermesi için.
            this.Hide();  //kapatması için
        }

        private void btnKitapBul_Click(object sender, EventArgs e)
        {
            ktpara.Show();  //butona tıklanınca KitapAra sayfasına göstermesi için.
            this.Hide();  //kapatması için
        }
    }
}
