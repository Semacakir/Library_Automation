using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IKitapService:IBaseService<Kitap> //BaseService'ten kalıtım alıyoruz
    {
        Kitap KitapBul(string Adi); //kitap bulmak için metod tanımlıyoruz.
    }
}
