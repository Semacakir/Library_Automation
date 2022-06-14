using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBaseDAL<T> // Burda temel metodlarımızı çağırdığımızı interface'imizi tanımlıyoruz. 
    {
        List<T> listele(); //  Listele metodumuz çağırıyoruz.
        void ekle(T entity); // Ekle metodumuz.
        void guncelle(T entity); //Güncelle metodumuz.
        void sil(int id); //Sil metodumuz.
    }
}
