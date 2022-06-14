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

namespace UserInterface
{
    public partial class PersonelGiris : Form
    {
        public PersonelGiris()
        {
            InitializeComponent();
        }
        OleDbConnection con;   
        OleDbCommand cmd;
        OleDbDataReader dr; 

        private void btnPersonelGiris_Click(object sender, EventArgs e)
        {
            string ad =txtPrsTc.Text;  // adı texte atamak için
            string sifre = txtPrsSifre.Text;  // şifreyi texte atamak için
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=library.mdb");
            cmd = new OleDbCommand();
            con.Open();  //bağlantı açıldı
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Personel_tbl where Personel_Tc='" + txtPrsTc.Text + "' AND Personel_Sifre='" + txtPrsSifre.Text + "'";
            //Personel tablosundaki şifre ve tc uyumu için sorgu
            dr = cmd.ExecuteReader();   //çalıştırmak için
            if (dr.Read()) //doğruysa yapacağı işlem
            {
                PersonelIslemler p1 = new PersonelIslemler();  // Personelİslemler formuna geçebilmek için yeni nesne tanımlandı. 
                p1.Show();  //sayfamızı göstermek için
                this.Close();  // önceki sayfayı kapatmak için
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış"); //Eğer şifre hatalıysa verilcek olan mesaj
            }

            con.Close();  //bağlantı kapatmak için
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            Baslangic bs = new Baslangic();  //Baslangıca geri dönmek için bs adında yeni nesne tanımlandı.
            bs.Show();  // göstermesi için
            this.Close();  // kapatmak için
        }
    }
}
