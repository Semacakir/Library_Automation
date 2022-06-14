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
using Service.Interfaces;
using Service.Concrete;
using Entities.Concrete;

namespace UserInterface
{
    public partial class OgrenciGiris : Form
    {
        IOgrenciService ogrenciService;  //yeni nesne
        public OgrenciGiris()
        {
            InitializeComponent();
            ogrenciService = new OgrenciService();  //yeni nesne tanımı
        }


        private void btnOgrGiris_Click(object sender, EventArgs e)
        {
            string tc = txtOgrTc.Text;  //tc'yi texte yazdırmak için
            string sifre = txtOgrSifre.Text;  //şifreyi atamak için
            Entities.Concrete.Ogrenci ogrenci = ogrenciService.TcVeSifreyeGoreBul(tc, sifre); //yeni nesne tanımlandı.
            if (ogrenci != null)  //Boş değilse alltaki sayfaya geçicek
            {
                OgrenciForm frm = new OgrenciForm(ogrenci); //ÖğrenciForm sayfasına geçmek için frm adında yeni nesne
                frm.Show();  //göstermesi için
                this.Close();  //kapatmak için
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");  //Eğer şifre hatalıysa verilcek olan mesaj
            }

        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            Baslangic bs = new Baslangic();  //Baslangıca geri dönmek için bs adında yeni nesne tanımlandı.
            bs.Show();  // göstermesi için
            this.Close();  // kapatmak için
        }
    }
}
