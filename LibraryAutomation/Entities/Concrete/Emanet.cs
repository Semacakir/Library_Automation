using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Emanet  // Emanete ait verileri çekip sınıfa aktarıcaz.
    {
        public int Id { get; set; }
        public int Ogrenci_Id { get; set; }
        public int Kitap_Id { get; set; }
        public DateTime Kitap_emanet_verilme { get; set; }
        public DateTime Kitap_teslim_edilme { get; set; }
        public DateTime? Kitap_teslim_edilen { get; set; }
        public int Kitap_borc { get; set; }

       
    }
}
