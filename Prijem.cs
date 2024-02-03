using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal class Prijem : Department
    {
        public Prijem(string departmentName, string adress, int buildingNumber, int numberOfStaff, DepartmentTypes departmentType) 
            : base(departmentName, adress, buildingNumber, numberOfStaff, DepartmentTypes.Prijem)
        {
        }
    }
}
