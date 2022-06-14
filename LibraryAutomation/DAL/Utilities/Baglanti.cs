using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utilities
{
    public class Baglanti
    {
        public static string getir() // Burada veritabanıyla aramızdaki bağlantıyı sağlıyoruz.
        {
            return "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=library.mdb";
        }
        
    }
}
