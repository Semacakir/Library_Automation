using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEmanetDAL:IBaseDAL<Emanet> //Temel interface'ten kalıtım alıyoruz.
    {
        void BorcGuncelle();  // Borç güncellemek için metod tanımlıyoruz.
    }
}
