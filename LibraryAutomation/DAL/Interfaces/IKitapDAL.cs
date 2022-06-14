using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IKitapDAL : IBaseDAL<Kitap>  //Burda Temel interface'imizden kalıtım alıyoruz.
    {
        Kitap KitapBul(string Adi);  // Burada kitap bulmak için metod tanımlıyoruz.
       
    }
}
