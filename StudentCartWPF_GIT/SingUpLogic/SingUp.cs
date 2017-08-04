using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingUpLogic
{
    public interface ISingUp
    {
        bool CreateTeacher();

        bool DeleteTeacher();

        bool ChangePassword();
    }
    public class SingUp : ISingUp
    {
        public bool ChangePassword()
        {
            return false;
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
