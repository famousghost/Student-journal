using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginLogic
{
    public interface ISingInLogic
    {
        bool SingIn(string login, string password);

        bool SingOut();

        bool ChangePassword();

        bool CreateTeacher();

        bool DeleteTeacher();
    }

    public class SingInLogic : ISingInLogic
    {
        string login { get; set; }

        string password { get; set; }

        public SingInLogic(string login,string password)
        {
            this.login = login;
            this.password = password;
        }

        public bool SingIn(string login, string password)
        {
            if(this.login.Equals(login) && this.password.Equals(password))
            {
                return true;
            }
            return false;
        }



        public bool SingOut()
        {
            return true;
        }

        public bool ChangePassword()
        {
            return true;
        }

        public bool CreateTeacher()
        {
            return false;
        }

        public bool DeleteTeacher()
        {
            return false;
        }
    }
}
