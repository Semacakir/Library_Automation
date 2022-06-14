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
    public class KitapService : IKitapService  // metodları burada impelement ediyor.
    {

        IKitapDAL kitapDAL;  // yeni nesne tanımlandı.
        public KitapService()
        {
            kitapDAL = new KitapDAL();  // yeni metod.
        }
        public void ekle(Kitap entity)  // ekel metodu.
        {
            kitapDAL.ekle(entity);  //eklemeyi çalıştıyor.
        }

        public void guncelle(Kitap entity)  // güncelle metodu.
        {
            kitapDAL.guncelle(entity);  // guncelleyi çalıştırıyor.
        }

        public Kitap KitapBul(string Adi)  // Kitap bul metodunu burda implement ediliyorç
        {
            return kitapDAL.KitapBul(Adi);  
        }

        public List<Kitap> listele()  // Kitapları listelemek için.
        {
            return kitapDAL.listele();
        }

        public void sil(int id)  // Sil metoduç
        {
            kitapDAL.sil(id);  // Silmemizi sağlıyoruz.
        }

       
    }
}
