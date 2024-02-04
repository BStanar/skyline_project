using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal class Doctor:Employee
    {
        private Boolean _isHeadDoctor;
        private SpecialistTypes _specialisation;
        private DepartmentTypes _assignedToDepartment;

        public DepartmentTypes AssignedToDepartment
        {
            get { return _assignedToDepartment; } 
            set { _assignedToDepartment = value; }
        }
        public Boolean IsHeadDoctor 
        { 
            get { return _isHeadDoctor; }
            set { _isHeadDoctor = value; }
        }
        public SpecialistTypes Specialisation
        {
            get { return _specialisation; }
            set { _specialisation = value; }
        }

        public Doctor(int id, string firstName, string lastname, int jmbg, DateTime dateBirth, string sex, string phoneNumber,
           DateTime startOfEmployment, string position, string username, string password, Boolean isheadDoctor, SpecialistTypes specialisation, EmployeeRole role, DepartmentTypes assignedToDepartment)
           : base(id, firstName, lastname, jmbg, dateBirth, sex, phoneNumber, startOfEmployment, position, username, password,role)
        {
            IsHeadDoctor = isheadDoctor;
            Specialisation = specialisation;
            AssignedToDepartment = assignedToDepartment;
        }

        public void InteractWithPatient()
        {
        }

        
    }
}
