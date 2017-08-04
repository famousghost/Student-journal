using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCartWPF_GIT.StudentAddLogic
{
    public class Pesel
    {
        private readonly string peselTextRepresentation;

        private Pesel(string peselText)
        {
            peselTextRepresentation = peselText;
        }

        public static bool TryParse(string peselText, out Pesel pesel)
        {
            pesel = new Pesel(peselText);
            return true;
        }

        public static Pesel Parse(string peselText)
        {
            return new Pesel(peselText);
        }

        public override string ToString()
        {
            return peselTextRepresentation;
        }
    }
}
