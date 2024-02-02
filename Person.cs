using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    public abstract class Person
    {
        protected int ID { get;  }
        public string Lastname {  get; set; }
        public string Firstname { get; set; }
        protected int JMBG {  get; set; }
        public DateTime DateBirth { get; set; }
        public string Sex { get; set; }
        protected string PhoneNumber {  get; set; }


        public Person(int id, string firstName, string lastname, int jmbg, DateTime dateBirth, string sex, string phoneNumber)
        {
            this.ID = id;
            Lastname = lastname;
            Firstname = firstName;
            JMBG = jmbg;
            DateBirth = dateBirth;
            Sex = sex;
            PhoneNumber = phoneNumber;
        }

        public abstract string ToString();
    }
}
