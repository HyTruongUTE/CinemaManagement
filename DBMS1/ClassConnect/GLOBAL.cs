using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.Class
{
    public class GLOBAL
    {
        private static string username;
        private static string password;

        public GLOBAL()
        {
        }

        public static string Username { get => username; set => username = value; }
        public static string Password { get => password; set => password = value; }
    }
}
