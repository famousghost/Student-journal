using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCartWPF_GIT
{
    public class Student
    {
        //Variables
        public String Pesel { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string City { get; private set; }

        //constructor
        public Student(String Pesel, string Name, string Surname, DateTime BirthDate, string City)
        {
            this.Pesel = Pesel;
            this.Name = Name;
            this.Surname = Surname;
            this.BirthDate = BirthDate;
            this.City = City;
        }

        //override Equals method from Object class
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Student student = obj as Student;

            var eq = (Pesel == student.Pesel);

            return eq;
        }


        //HashCode must be override if we override Equals method
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        //check This student by Pesel I use it in ERepository class
        public bool checkThisStudent(string Pesel)
        {
            if (this.Pesel == Pesel)
            {
                return true;
            }
            return false;
        }

    }
}
