using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal class Doctor:Employee
    {
        public Boolean IsHeadDoctor { get; set; }
        public string Specialisation { get; set; }

        public Doctor(int id, string firstName, string lastname, int jmbg, DateTime dateBirth, string sex, string phoneNumber,
           DateTime startOfEmployment, string position, string username, string password, Boolean isheadDoctor, string specialisation, EmployeeRole role)
           : base(id, firstName, lastname, jmbg, dateBirth, sex, phoneNumber, startOfEmployment, position, username, password,role)
        {
            IsHeadDoctor = isheadDoctor;
            Specialisation = specialisation;
        }

        
    }
}
