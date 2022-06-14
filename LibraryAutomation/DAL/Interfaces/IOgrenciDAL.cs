using DAL.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOgrenciDAL:IBaseDAL<Ogrenci> //Burada IBaseDAL'den kalıtım alıyoruz.
    {
        Ogrenci TcVeSifreyeGoreBul(string tc, string sifre); //Bunu öğrenciye şifresine bağlı olarak giriş yapabilmesi için tanımladım.
        Ogrenci OgrBul(string adi); // Burada istenilen öğrencinin aratılıp bulunabilmesi için tanımladım.
        void BorcGuncelle(); // Bu da öğrencimizin borcunu güncellemek için tanımladığımız metodumuz. 
    }
}
