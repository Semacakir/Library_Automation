using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Ogrenci // öğrenciye ait verileri çekip bu sınıfa aktarıcaz.
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tel { get; set; }
        public string Eposta { get; set; }
        public string Adres { get; set; }
        public string Sifre { get; set; }
        public string Tc { get; set; }
        public int Borc { get; set; }
    }
}
