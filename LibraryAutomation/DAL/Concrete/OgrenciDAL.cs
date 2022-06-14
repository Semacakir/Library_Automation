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
    public class OgrenciDAL : IOgrenciDAL
    {
        private string baglantiSorgusu;  // burada baglantiSorgusu tanımlandı.
        public OgrenciDAL()
        {
            baglantiSorgusu = Baglanti.getir();  //  bağlantıyı burada tanımlıyoruz.
        }

      
        public void ekle(Ogrenci entity)
        {
            string query = "insert into Ogrenci_tbl (Ogrenci_adi,Ogrenci_soyadi,Ogrenci_tel,Ogrenci_eposta,Ogrenci_adres,Ogrenci_sifre, Ogrenci_tc, Ogrenci_borc) VALUES (@Ad,@Soyad,@Tel,@Eposta,@Adres,@Sifre,@Tc,@Borc)";
            //eklemek için yazılan sorgu.
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu)) // bağlantıyı sağlandı.
            {
                using (OleDbCommand selectCommand = new OleDbCommand(query, connection)) //sorgu sağlandı.
                {
                    connection.Open();  // bağlantı açıldı. 
                    selectCommand.Parameters.AddWithValue("@Ad", entity.Ad);  // Bundan sonrasında veriler çekildi.
                    selectCommand.Parameters.AddWithValue("@Soyad", entity.Soyad);
                    selectCommand.Parameters.AddWithValue("@Tel", entity.Tel);
                    selectCommand.Parameters.AddWithValue("@Eposta", entity.Eposta);
                    selectCommand.Parameters.AddWithValue("@Adres", entity.Adres);
                    selectCommand.Parameters.AddWithValue("@Sifre", entity.Sifre);
                    selectCommand.Parameters.AddWithValue("@Tc", entity.Tc);
                    selectCommand.Parameters.AddWithValue("@Borc", entity.Borc);
                    selectCommand.ExecuteNonQuery();  //çalıştırmak için
                    connection.Close();  //bağlantı kapatıldı.
                }

            }
        }

        

        public void guncelle(Ogrenci entity)
        {
            string query = "Update Ogrenci_tbl set Ogrenci_adi= @Ad, Ogrenci_soyadi= @Soyad, Ogrenci_tel= @Tel, Ogrenci_eposta=@Eposta, Ogrenci_adres=@Adres, Ogrenci_sifre= @Sifre, Ogrenci_tc=@TC, Ogrenci_borc=@Borc where Ogrenci_id= @Id";
            // Güncelle sorgusu yazıldı.
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu))    // bağlantıyı sağlandı.
            {
                using (OleDbCommand selectCommand = new OleDbCommand(query, connection))   //sorgu sağlandı.
                {
                    connection.Open();   // bağlantı açıldı. 
                    selectCommand.Parameters.AddWithValue("@Ad", entity.Ad);   // Bundan sonrasında veriler çekildi.
                    selectCommand.Parameters.AddWithValue("@Soyad", entity.Soyad);
                    selectCommand.Parameters.AddWithValue("@Tel", entity.Tel);
                    selectCommand.Parameters.AddWithValue("@Eposta", entity.Eposta);
                    selectCommand.Parameters.AddWithValue("@Adres", entity.Adres);
                    selectCommand.Parameters.AddWithValue("@Sifre", entity.Sifre);
                    selectCommand.Parameters.AddWithValue("@Tc", entity.Tc);
                    selectCommand.Parameters.AddWithValue("@Borc", entity.Borc);
                    selectCommand.Parameters.AddWithValue("@Id", entity.Id);
                    selectCommand.ExecuteNonQuery();  //çalıştırmak için
                    connection.Close();   //bağlantı kapatıldı.
                }

            }
        }

        public List<Ogrenci> listele()
        {
            string query = "Select * from Ogrenci_tbl";  //listelemek için sorgu
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu))  // bağlantıyı sağlandı.
            {
                using (OleDbCommand selectCommand = new OleDbCommand(query, connection))  //sorgu sağlandı.
                {
                    connection.Open();  // bağlantı açıldı.
                    DataTable table = new DataTable();  //yeni nesne
                    OleDbDataReader dr = selectCommand.ExecuteReader(); //veritabanından okumak için komut
                    List<Ogrenci> ogrenciler = new List<Ogrenci>(); // öğrenciler adında nesne yapıldı.
                    while (dr.Read()) //veri listesini çekene kadar kendi içerisinde döndürür.
                    {

                        ogrenciler.Add(new Ogrenci  //eklemeler yapıldı.
                        {
                            Id = Convert.ToInt32(dr["Ogrenci_id"].ToString()), 
                            Ad = dr["Ogrenci_Adi"].ToString(), 
                            Soyad = dr["Ogrenci_soyadi"].ToString(), 
                            Tel = dr["Ogrenci_tel"].ToString(), 
                            Eposta = dr["Ogrenci_eposta"].ToString(), 
                            Adres = dr["Ogrenci_adres"].ToString(), 
                            Sifre = dr["Ogrenci_sifre"].ToString(), 
                            Tc = dr["Ogrenci_tc"].ToString(), 
                            Borc = Convert.ToInt32(dr["Ogrenci_borc"].ToString()),
                        });
                    }
                    connection.Close();  //bağlantı kapatıldı.
                    return ogrenciler;
                }
            }
        }

        public Ogrenci OgrBul(string Ad)
        {
            string query = "Select * from Ogrenci_tbl where Ogrenci_adi Like @Ad";  // Ogrenci tablosundan adına göre öğrenciyi buldurmak için.
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu)) // bağlantıyı sağlandı.
            {
                    using (OleDbCommand selectCommand = new OleDbCommand(query, connection))  //sorgu sağlandı.
                    {
                    connection.Open(); // bağlantı açıldı.
                    DataTable table = new DataTable();
                    selectCommand.Parameters.AddWithValue("@Ad", Ad);
                    OleDbDataReader dr = selectCommand.ExecuteReader(); //veritabanından okumak için komut.
                    Ogrenci ogrenci = null;
                    while (dr.Read()) // veri listesini çekene kadar kendi içerisinde döndürür.
                    {
                        ogrenci = new Ogrenci // ogrenci adında yeni nesne
                        {
                            Id = Convert.ToInt32(dr["Ogrenci_id"].ToString()), 
                            Ad = dr["Ogrenci_Adi"].ToString(), 
                            Soyad = dr["Ogrenci_soyadi"].ToString(), 
                            Tel = dr["Ogrenci_tel"].ToString(), 
                            Eposta = dr["Ogrenci_eposta"].ToString(), 
                            Adres = dr["Ogrenci_adres"].ToString(), 
                            Sifre = dr["Ogrenci_sifre"].ToString(), 
                            Tc = dr["Ogrenci_tc"].ToString(), 
                            Borc = Convert.ToInt32(dr["Ogrenci_borc"].ToString()), 
                        };
                    }
                    if (ogrenci != null) 
                    {
                        return ogrenci;
                    }
                }
                connection.Close();  //bağlantı kapatıldı.
            }
                return null;
            }


        public void sil(int id)
        {
            string query = "delete from Ogrenci_tbl where Ogrenci_id = @Id"; // Ogrenci tablosundaki id'si ile öğrenci silme sorgusu
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu))  //bağlantı sağlandı.
            {
                using (OleDbCommand selectCommand = new OleDbCommand(query, connection))  //sorgu sağlandı.
                {
                    connection.Open();  // bağlantı açıldı.
                    selectCommand.Parameters.AddWithValue("@Id", id);  
                    selectCommand.ExecuteNonQuery();  //çalıştırmak için
                    connection.Close();  //bağlantı kapatıldı.
                }
            }
        }

        public Ogrenci TcVeSifreyeGoreBul(string tc,string sifre)  
        {
            string query = "SELECT * FROM Ogrenci_tbl where Ogrenci_tc =@Tc AND Ogrenci_sifre=@Sifre"; // Öğrenci tablosundan tc ve şifreyi kontrol ettiren sorgu
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu))  //bağlantı sağlandı
            {
                using (OleDbCommand selectCommand = new OleDbCommand(query, connection))  //sorgu sağlandı.
                {
                    connection.Open();  // bağlantı açıldı.
                    DataTable table = new DataTable();
                    selectCommand.Parameters.AddWithValue("@Tc",tc);
                    selectCommand.Parameters.AddWithValue("@Sifre", sifre);
                    OleDbDataReader dr = selectCommand.ExecuteReader(); //veritabanından okumak için komut.
                    Ogrenci ogrenci = null;
                    while (dr.Read())   // veri listesini çekene kadar kendi içerisinde döndürür
                    {
                        ogrenci = new Ogrenci //yeni nesne 
                        {
                            Id = Convert.ToInt32(dr["Ogrenci_id"].ToString()), 
                            Ad = dr["Ogrenci_Adi"].ToString(),
                            Soyad = dr["Ogrenci_soyadi"].ToString(),
                            Tel = dr["Ogrenci_tel"].ToString(), 
                            Eposta = dr["Ogrenci_eposta"].ToString(), 
                            Adres = dr["Ogrenci_adres"].ToString(),
                            Sifre = dr["Ogrenci_sifre"].ToString(), 
                            Tc = dr["Ogrenci_tc"].ToString(), 
                            Borc =Convert.ToInt32(dr["Ogrenci_borc"].ToString()),
                        };
                    }
                    if (ogrenci != null)
                    {
                        return ogrenci;
                    }
                   
                }
                connection.Close();  //bağlantı kapatıldı.

            }
            return null;
        }

        public void BorcGuncelle()
        {
            string query = "Update Ogrenci_tbl set Ogrenci_borc = DATEDIFF('d',Kitap_teslim_edilme,Date()) WHERE Kitap_teslim_edilen is null and Date() > Kitap_teslim_edilme";
            // borcu güncellemek için tarihlere bakılarak güncelleme sorgusu
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu))  //bağlantı sağlandı.
            {
                using (OleDbCommand selectCommand = new OleDbCommand(query, connection))  //sorgu sağlandı.
                {
                    connection.Open();  //bağlantı açıldı.
                    selectCommand.ExecuteNonQuery();  //çalıştırmak için
                    connection.Close();   //bağlantı kapatıldı.
                }

            }
        }


    }
}
