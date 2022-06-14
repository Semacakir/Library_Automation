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
    public class EmanetService : IEmanetService  // metodlar burada implement edildi.
    {
        IEmanetDAL emanetDAL; //yeni nesne tanımlanıyor.
        public EmanetService()
        {
            emanetDAL = new EmanetDAL();  //yeni nesne tanımlıyoruz.
        }
        public void ekle(Emanet entity)  //ekle metodu 
        {
            emanetDAL.ekle(entity);  // ekleme işlemi için.
        }

        public void guncelle(Emanet entity)  // güncelle metodu
        {
            emanetDAL.BorcGuncelle();  // borcu güncellemek için
            emanetDAL.guncelle(entity);  //emaneti güncelleyebilmek için
        } 

        public List<Emanet> listele()  //  Listele metodu.
        {
            emanetDAL.BorcGuncelle();  // Listelenince borcu güncelleyebilmek için.
            return emanetDAL.listele();  // emaneti listeledi.
        }

        public void sil(int id)  // sil metdou.
        {
            emanetDAL.sil(id);  //emanet geri iade için
        }

        void IEmanetService.BorcGuncelle()  // borc güncelle metodumuzu burada implement ediyoruz.
        {
            emanetDAL.BorcGuncelle();
        }
    }
}
