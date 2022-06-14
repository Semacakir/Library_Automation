using DAL.Concrete;
using DAL.Interfaces;
using Entities.Concrete;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class OgrenciService : IOgrenciService  // metodları burada implement ediyor.
    {
        IOgrenciDAL ogrenciDAL;  //ogrencDAL adında yeni nesne tanımlandı
        IEmanetDAL emanetDAL;  //emanetDAL adında yeni nesne tanımlandı.
        public OgrenciService()
        {
            ogrenciDAL = new OgrenciDAL();  // yeni nesne tanımlıyor.
            emanetDAL = new EmanetDAL();  //yeni nesne tanımlıyor.
        }

        public void ekle(Ogrenci entity) //Ekle metodu.
        {
            ogrenciDAL.ekle(entity);  //nesnemizle ekle metodunu çalıştırıyor. Bununla yeni öğrenci çalıştırabiliyor.
        }

        public void guncelle(Ogrenci entity)  //Güncelleme metodu.
        {
            emanetDAL.BorcGuncelle();   //yeni nesneden borc guncelleyi çalıştırıyor.
            ogrenciDAL.guncelle(entity);  //yeni nesneden guncelle metodunu çağırıyor bununla öğrenci bilgilerini güncelleyebiliyor.
        }

        public List<Ogrenci> listele()  //Listele metodu.
        {
            List<Ogrenci> ogrenciler = ogrenciDAL.listele();  //Burada öğrenciler adında yeni nesne tanımlandı.
            foreach (var ogrenci in ogrenciler)  // döngü sağlandı.
            {
                int toplamBorc =  emanetDAL.listele().Where(x => x.Ogrenci_Id == ogrenci.Id).Sum(x => x.Kitap_borc);  // öğrencide borç işlemini yaptırabilmek için toplamborc adında yeni bir değer tanımlandı. Öğrencinin birden fazla kitaba borcu olabileceği için toplam borcu hesaplatıldı..
                ogrenci.Borc = toplamBorc;  // toplamBorc'u ogrenci.Borc'a atıyor.
                ogrenciDAL.guncelle(ogrenci);  // ogrenciyi güncelledi
            }
            return ogrenciDAL.listele();  
        }

        public Ogrenci OgrBul(string adi)  //OgrenciBul metodunu burada implement ettim.
        {
            return ogrenciDAL.OgrBul(adi);  
        }

        
        public void sil(int id)  // Sil metodu
        {
            ogrenciDAL.sil(id);  // öğrenciyi silebilmek için kullanıldı.
        }

        public Ogrenci TcVeSifreyeGoreBul(string tc, string sifre)  // Şifreyle giriş yapabilmek için tanımladığımız metodumuzu buraya implement ettim.
        {
            return ogrenciDAL.TcVeSifreyeGoreBul(tc,sifre);
        }
       
        void IOgrenciService.BorcGuncelle()  //Borc güncellemek için tanımladığımız metomuduzu burada implement ettim.
        {
            emanetDAL.BorcGuncelle();  //Borc güncelledim.
        }
    }
}
