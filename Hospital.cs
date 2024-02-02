using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal class Hospital:Department
    {
        private int _numberOfDepartments;
        public int NumberOfDepartments 
        { 
            get { return _numberOfDepartments; }
            set
            {
                if (value > 1)
                    _numberOfDepartments = value;
                else
                    _numberOfDepartments = 1;
            }
        }
        
        
        /*Trebaju radncii i trebaju Odjeli*/

        public Hospital(string departmentName, string adress, int buildingNumber, int numberOfStaff, DepartmentTypes departmentType, int numberOfDepartments) 
            : base("SkylineCommunications bolnica", "Tesanjska", 24, numberOfStaff, DepartmentTypes.Bolnica)
        {
            NumberOfDepartments = numberOfDepartments;
        }

    }
}
