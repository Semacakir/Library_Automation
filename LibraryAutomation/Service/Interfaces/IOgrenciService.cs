using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IOgrenciService : IBaseService<Ogrenci>  // Burda BaseService'ten kalıtım alıyoruz.
    {
        Ogrenci TcVeSifreyeGoreBul(string tc,string sifre);  // Şifre ile giriş için metod tanımlıyoruz.
        Ogrenci OgrBul(string adi); // Öğrenci bulmak için metod tanımlıyoruz.
        void BorcGuncelle();  // Borc güncellemek için tanımlıyoruz.

    }
}
