using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS1.Class
{
    internal class Account
    {
        private string userName;
        private string passWord;
        private bool isAdmin;

        public Account(string userName, string passWord, bool isAdmin)
        {
            this.UserName = userName;
            this.PassWord = passWord;
            this.IsAdmin = isAdmin;
        }

        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
    }
}
