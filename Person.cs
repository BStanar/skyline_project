using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    public abstract class Person
    {
        private int _id;
        private string _lastname;
        private string _firstname;
        private int _jmbg;
        private DateTime _dateBirth;
        private string _sex;
        private string _phoneNumber;
        public int ID 
        { 
            get { return _id; } 
        }
        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public int JMBG
        {
            get { return _jmbg; }
            set { _jmbg = value; }
        }

        public DateTime DateBirth
        {
            get { return _dateBirth; }
            set { _dateBirth = value; }
        }

        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }


        public Person(int id, string firstName, string lastname, int jmbg, DateTime dateBirth, string sex, string phoneNumber)
        {
            this._id = id;
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
