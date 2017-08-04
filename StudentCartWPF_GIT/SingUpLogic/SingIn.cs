using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingUpLogic
{
    public interface ISingIn
    {
        bool LogIn(string login,string password);

        bool LogOut();
    }

    public class SingIn : ISingIn
    {
        string login { get; set;}
        string password { get; set; }

        public SingIn(string login,string password)
        {
            this.login = login;
            this.password = password;
        }

        public bool LogIn(string login, string password)
        {
            bool correctLoginAndPassword = this.login.Equals(login) && this.password.Equals(password);
            if(correctLoginAndPassword)
            {
                return true;
            }
            return false;
        }

        public bool LogOut()
        {
            return false;
        }
    }
}
