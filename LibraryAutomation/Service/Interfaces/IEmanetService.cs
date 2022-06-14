using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEmanetService:IBaseService<Emanet>  //BaseService'ten kalıtım alıyoruz.
    {
        void BorcGuncelle();  //Boc güncellemek için metod tanımlıyoruz.
    }
}
