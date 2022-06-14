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
    public class EmanetDAL : IEmanetDAL
    {
        private string baglantiSorgusu;  // burada baglantiSorgusu tanımlandı.
        public EmanetDAL()
        {
            baglantiSorgusu = Baglanti.getir();   //  bağlantıyı burada tanımlıyoruz.
        }

        public void ekle(Emanet entity)
        {
            string query = "insert into Emanet_tbl (Ogrenci_Id,Kitap_Id,Kitap_emanet_verilme,Kitap_teslim_edilme,Kitap_borc) VALUES (@Ogrenci_Id,@Kitap_Id,@Kitap_emanet_verilme,@Kitap_teslim_edilme,@Kitap_borc)";
            //eklemek için yazılan sorgu.
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu))  // bağlantı sağlandı.
            {
                using (OleDbCommand selectCommand = new OleDbCommand(query, connection))  //sorgu sağlandı.
                {
                    connection.Open();  //bağlantı açıldı.
                    selectCommand.Parameters.AddWithValue("@Ogrenci_Id", entity.Ogrenci_Id);
                    selectCommand.Parameters.AddWithValue("@Kitap_Id", entity.Kitap_Id);
                    selectCommand.Parameters.AddWithValue("@Kitap_emanet_verilme", entity.Kitap_emanet_verilme);
                    selectCommand.Parameters.AddWithValue("@Kitap_teslim_edilme", entity.Kitap_teslim_edilme);
                    selectCommand.Parameters.AddWithValue("@Kitap_borc", entity.Kitap_borc);
                    selectCommand.ExecuteNonQuery();  //çalıştırmak için
                    connection.Close();  //bağlantı kapatıldı.
                }

            }
        }

        public void guncelle(Emanet entity)
        {
            string query = "Update Emanet_tbl set Ogrenci_Id= @Ogrenci_Id, Kitap_Id= @Kitap_Id, Kitap_emanet_verilme= @Kitap_emanet_verilme, Kitap_teslim_edilme=@Kitap_teslim_edilme, Kitap_teslim_edilen=@Kitap_teslim_edilen, Kitap_borc=@Kitap_borc where Emanet_Id= @Id";
            // Güncelle sorgusu yazıldı.
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu))  // bağlantı sağlandı.
            {
                using (OleDbCommand selectCommand = new OleDbCommand(query, connection))  //sorgu sağlandı.
                {
                    connection.Open();  //bağlantı açıldı.
                    selectCommand.Parameters.AddWithValue("@Ogrenci_Id", entity.Ogrenci_Id);
                    selectCommand.Parameters.AddWithValue("@Kitap_Id", entity.Kitap_Id);
                    selectCommand.Parameters.AddWithValue("@Kitap_emanet_verilme", entity.Kitap_emanet_verilme);
                    selectCommand.Parameters.AddWithValue("@Kitap_teslim_edilme", entity.Kitap_teslim_edilme);
                    selectCommand.Parameters.AddWithValue("@Kitap_teslim_edilen", entity.Kitap_teslim_edilen);
                    selectCommand.Parameters.AddWithValue("@Kitap_borc", entity.Kitap_borc);
                    selectCommand.Parameters.AddWithValue("@Id", entity.Id);
                    selectCommand.ExecuteNonQuery();  //çalıştırmak için
                    connection.Close();   //bağlantı kapatıldı.
                }

            }
        }

        public List<Emanet> listele()
        {
            string query = "Select * from Emanet_tbl";  //listelemek için sorgu
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu))  // bağlantı sağlandı.
            {
                using (OleDbCommand selectCommand = new OleDbCommand(query, connection))  //sorgu sağlandı.
                {
                    connection.Open();  //bağlantı açıldı.
                    DataTable table = new DataTable();
                    OleDbDataReader dr = selectCommand.ExecuteReader();//veritabanı listeyi okumak için komut
                    List<Emanet> emanetler = new List<Emanet>();//listeyi kaydeder.
                    while (dr.Read()) //veri listersi çıkana kadar döngüyü döndürür.
                    {
                       DateTime? teslimverme = null;
                        try  
                        {
                            teslimverme = Convert.ToDateTime(dr["Kitap_teslim_edilen"].ToString());


                        }
                        catch
                        {
                            teslimverme = null;
                        }

                        emanetler.Add(new Emanet //ogrenciDTO daki komutlarla ekleme komutu
                        {
                            Id = Convert.ToInt32(dr["Emanet_Id"].ToString()), 
                            Ogrenci_Id = Convert.ToInt32(dr["Ogrenci_Id"]), 
                            Kitap_Id = Convert.ToInt32(dr["Kitap_Id"]), 
                            Kitap_emanet_verilme = Convert.ToDateTime(dr["Kitap_emanet_verilme"].ToString()), 
                            Kitap_teslim_edilme = Convert.ToDateTime(dr["Kitap_teslim_edilme"].ToString()), 
                            Kitap_teslim_edilen= teslimverme,
                            Kitap_borc = Convert.ToInt32(dr["Kitap_borc"]?.ToString()) 
                        });
                    }
                    connection.Close();   //bağlantı kapatıldı.
                    return emanetler;
                }
            }
        }

        public void sil(int id)
        {
            string query = "delete from Emanet_tbl where Emanet_Id = @Id";  //Emanet tablosundaki Id'si ile silme sorgusu.
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu))  // bağlantı sağlandı.
            {
                using (OleDbCommand selectCommand = new OleDbCommand(query, connection))   //sorgu sağlandı.
                {
                    connection.Open();  //bağlantı açıldı.
                    selectCommand.Parameters.AddWithValue("@Id", id);
                    selectCommand.ExecuteNonQuery();  //çalıştırmak için
                    connection.Close();   //bağlantı kapatıldı.
                }
            }
        }
        public void BorcGuncelle()
        {

            string query = "Update Emanet_tbl set Kitap_borc = DATEDIFF('d',Kitap_teslim_edilme,Date()) WHERE Kitap_teslim_edilen is null and Date() > Kitap_teslim_edilme";//Access veritabanındaki ogrenci_tbl tablosundaki sorgusuyla öğrenci guncellemek için fonksiyon.
            //borç güncellemek için tarihlere bakılarak güncelleme sorgusu.
            using (OleDbConnection connection = new OleDbConnection(baglantiSorgusu))  //bağlantı sağlandı.
            {
                using (OleDbCommand selectCommand = new OleDbCommand(query, connection))  //sorgu sağlandı.
                {
                    connection.Open();  //bağlantı açıldı.
                    selectCommand.ExecuteNonQuery();  //çalıştırmak için
                    connection.Close();  //bağlantı kapatıldı.   
                }

            }

        }
    }
}
