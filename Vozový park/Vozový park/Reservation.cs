using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozový_park
{
    class Reservation
    {
        public int idReservation;
        public int idAuto;
        public string idUser;
        public DateTime from;
        public DateTime to;
        public static Dictionary<int, Reservation> _reservations = new Dictionary<int, Reservation>();
        public static Dictionary<int, Reservation> reservations
        {
            get { return _reservations; }
            set { _reservations = value; }
        }
    }
}
