using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozový_park
{
    class NakladyNaUdrzbu
    {
        public int idUkonu;
        public int idAuta;
        public string ukon;
        public DateTime cas;
        public decimal cena;
        public int cisloFaktury;
        public static Dictionary<int, NakladyNaUdrzbu> _naklady = new Dictionary<int, NakladyNaUdrzbu>();
        public static Dictionary<int, NakladyNaUdrzbu> naklady
        {
            get { return _naklady; }
            set { _naklady = value; }
        }
    }
}
