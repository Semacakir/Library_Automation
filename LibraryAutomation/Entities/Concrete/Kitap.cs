using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Kitap //Kitaba ait verileri çekip sınıfa aktarıcaz.
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Yazari { get; set; }
        public string SayfaSayisi { get; set; }
        public DateTime BasimTarihi { get; set; }
        public string Turu { get; set; }
        
    }
}
