using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal interface IStaff:IPerson
    {
        string StaffID { get; set; }
        string Position { get; set; }
        string Department { get; set; }
        DateTime DateOfJointing { get; set; }
        decimal Salary { get; set; }

        void AssignDepartment(string department);
        void UpdateSalary(decimal Salary);
        string GetStaffDetail();
    }
}
