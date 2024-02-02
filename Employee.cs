using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{   /// <summary>
/// Klasa Employee nasljeduje podatke od person. Klasa employee je abstraktna, sto nam omogucuje dodavanje drugih tipova uposlenika 
/// </summary>
    public abstract class Employee : Person
    {
        public EmployeeRole Role { get; set; }
        
        public DateTime StartOfEmployment { get; set; }
        public string Position { get; set; }
        protected string Username {  get; set; }
        protected string Password { get; set; }
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
