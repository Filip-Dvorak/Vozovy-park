using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozový_park
{
    public class User
    {
        public string username;
        public string jmeno;
        public string prijmeni;
        public string heslo;
        public DateTime posledniPrihlaseni;
        public bool isAdmin;
        public bool isActice;
        public bool needsToChangePassword;

        public static Dictionary<string, User> _users = new Dictionary<string, User>();
        public static Dictionary<string, User> users
        {
            get { return _users; }
            set { _users = value; }
        }

        public static string _currentUser;
        public static string currentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

    }
}
