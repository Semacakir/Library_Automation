using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBaseService<T>  //Temel interface tanımladık.
    {
        List<T> listele();  //Listeleme metodumuz.
        void ekle(T entity);  //Ekleme metodumuz.
        void sil(int id);  //Sil metodumuz.
        void guncelle(T entity);  //Güncelleme metodumuz.
    }
}
