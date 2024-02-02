using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    public abstract class Employee : Person
    {
        private EmployeeRole _role;

        private DateTime _startOfEmployment;
        private string _position;
        private string _username;
        private string _password;
        public EmployeeRole Role 
        {
            get { return _role; }
            set {  _role=value; }
        }
        public DateTime StartOfEmployment
        {
            get { return _startOfEmployment; }
            set { _role = _startOfEmployment; }
        }
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public Employee(int id, string firstName, string lastname, int jmbg, DateTime dateBirth, string sex, string phoneNumber,
            DateTime startOfEmployment,string position,string username, string password,EmployeeRole role) 
            : base(id, firstName, lastname, jmbg, dateBirth, sex, phoneNumber)
        {
            StartOfEmployment=startOfEmployment; 
            Position=position; 
            Username=username;
            Password=password;
            Role = role;
        }

        
        public override string ToString()
        {
            return $"Name: {Firstname}/tLastname: {Lastname}, Position {Position}, Years employed{DateTime.Now.Year - StartOfEmployment.Year}";
        }


    }
}
