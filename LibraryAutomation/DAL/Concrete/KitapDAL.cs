using DAL.Interfaces;
using DAL.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class KitapDAL : IKitapDAL
    {
        private string baglantiSorgusu;  // burada baglantiSorgusu tanımlandı.
        public KitapDAL()
        {
            baglantiSorgusu = Baglanti.getir();    //  bağlantıyı burada tanımlıyoruz.
        }


        public void ekle(Kitap entity)
        {
            string query = "insert into Kitap_tbl (Kitap_adi,Kitap_yazari,Kitap_sayfasayisi,Kitap_basimtarihi,Kitap_turu) VALUES (@Adi,@Yazari,@SayfaSayisi,@BasimTarihi,@Turu)";
            //eklemek için yazılan sorgu.
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu)) // bağlantı sağlandı.
            {
                using (OleDbCommand selectCommand = new OleDbCommand(query, connection))  //sorgu sağlandı.
                {
                    connection.Open(); // bağlantı açıldı. 
                    selectCommand.Parameters.AddWithValue("@Adi", entity.Adi);  // Bundan sonrasında veriler çekildi.
                    selectCommand.Parameters.AddWithValue("@Yazari", entity.Yazari);
                    selectCommand.Parameters.AddWithValue("@SayfaSayisi", entity.SayfaSayisi);
                    selectCommand.Parameters.AddWithValue("@BasimTarihi", entity.BasimTarihi);
                    selectCommand.Parameters.AddWithValue("@Turu", entity.Turu);
                    selectCommand.ExecuteNonQuery();   //çalıştırmak için
                    connection.Close();  //bağlantı kapatıldı.
                }

            }
        }

        public void guncelle(Kitap entity)
        {
            string query = "Update Kitap_tbl set Kitap_adi= @Adi, Kitap_yazari= @Yazari, Kitap_sayfasayisi= @SayfaSayisi, Kitap_basimtarihi=@BasimTarihi, Kitap_turu=@Turu where Kitap_id= @Id";
            // Güncelle sorgusu yazıldı.
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu))  //bağlantı sağlandı.
            {
                using (OleDbCommand selectCommand = new OleDbCommand(query, connection))  //sorgu sağlandı.
                {
                    connection.Open();  // bağlantı açıldı.
                    selectCommand.Parameters.AddWithValue("@Adi", entity.Adi);
                    selectCommand.Parameters.AddWithValue("@Yazari", entity.Yazari);
                    selectCommand.Parameters.AddWithValue("@SayfaSayisi", entity.SayfaSayisi);
                    selectCommand.Parameters.AddWithValue("@BasimTarihi", entity.BasimTarihi);
                    selectCommand.Parameters.AddWithValue("@Turu", entity.Turu);
                    selectCommand.Parameters.AddWithValue("@Id", entity.Id);
                    selectCommand.ExecuteNonQuery();  //çalıştırmak için
                    connection.Close();  // bağlantı kapatıldı.
                }

            }
        }

        public Kitap KitapBul(string Adi)
        {
            string query = "Select * from Kitap_tbl where Kitap_adi Like @Adi ";  // Ogrenci tablosundan adına göre öğrenciyi buldurmak için.
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu))  // bağlantı sağlandı.
            {

                using (OleDbCommand selectCommand = new OleDbCommand(query, connection))  //sorgu sağlandı.
                {
                    connection.Open();  //bağlantı açıldı.
                    DataTable table = new DataTable();
                    selectCommand.Parameters.AddWithValue("@Adi", "%"+ Adi + "%");
                    OleDbDataReader dr = selectCommand.ExecuteReader();   //veritabanından okumak için komut.
                    Kitap kitap = null;
                    while (dr.Read()) // veri listesini çekene kadar kendi içerisinde döndürür.
                    {
                        kitap = new Kitap // kitap adında yeni nesne
                        {
                            Id = Convert.ToInt32(dr["Kitap_id"].ToString()), 
                            Adi = dr["Kitap_adi"].ToString(), 
                            Yazari = dr["Kitap_yazari"].ToString(),
                            SayfaSayisi = dr["Kitap_sayfasayisi"].ToString(),
                            BasimTarihi = Convert.ToDateTime(dr["Kitap_basimtarihi"].ToString()), 
                            Turu = dr["Kitap_turu"].ToString(), 
                        };
                        break;
                    }
                    if (kitap != null)
                    {
                        return kitap;
                    }

                }
                connection.Close();  //bağlantı kapatıldı.

            }
            return null;
        }

        public List<Kitap> listele()
        {
            string query = "Select * from Kitap_tbl";   //listelemek için sorgu
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu))  //bağlantı sağlandı
            {
                using (OleDbCommand selectCommand = new OleDbCommand(query, connection))  //sorgu sağlandı
                {
                    connection.Open();  //bağlandı açıldı
                    DataTable table = new DataTable();
                    OleDbDataReader dr = selectCommand.ExecuteReader();  //veritabanından okumak için komut
                    List<Kitap> kitaplar = new List<Kitap>();    // öğrenciler adında nesne yapıldı.
                    while (dr.Read())   //veri listesini çekene kadar kendi içerisinde döndürür.
                    {

                        kitaplar.Add(new Kitap //eklemeler yapıldı.
                        {
                            Id = Convert.ToInt32(dr["Kitap_id"].ToString()), 
                            Adi = dr["Kitap_adi"].ToString(), 
                            Yazari = dr["Kitap_yazari"].ToString(), 
                            SayfaSayisi = dr["Kitap_sayfasayisi"].ToString(), 
                            BasimTarihi =Convert.ToDateTime( dr["Kitap_basimtarihi"].ToString()), 
                            Turu = dr["Kitap_turu"].ToString(), 
                        });
                    }
                    connection.Close();  //bağlantı kapatıldı
                    return kitaplar;
                }
            }

        }

        public void sil(int id)  
        {
            string query = "delete from Kitap_tbl where Kitap_id = @Id";   // Kitap tablosundaki id'si ile silme sorgusu
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu))  //bağlantı sağlandı
            {
                using (OleDbCommand selectCommand = new OleDbCommand(query, connection))  //sorgu sağlandı
                {
                    connection.Open();  //bağlantı açıldı.
                    selectCommand.Parameters.AddWithValue("@Id", id);
                    selectCommand.ExecuteNonQuery();  //çalıştırmak için
                    connection.Close();  //bağlantı kapatıldı.
                }
            }
        }
    }
}
