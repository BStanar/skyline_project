using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    abstract class Department
    {
        private DepartmentTypes _departmentType;
        private string _departmentName;
        private string _adress;
        private int _buildingNumber;
        private int _numberOfStaff;
        private List<Doctor> _doctors = new List<Doctor>();
        public DepartmentTypes DepartmentType
        {
            get { return _departmentType; }
            set { _departmentType = value; }
        }
        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }
        public string Adress
        {
            get { return _adress; }
            set { _adress = value; }
        }
        public int BuildingNumber
        {
            get { return _buildingNumber; }
            set { _buildingNumber = value; }
        }
        public int NumberOfStaff
        {
            get { return _numberOfStaff; }
            set { _numberOfStaff = value; }
        }

        public void AddDoctor(Doctor value)
        {
            this._doctors.Add(value);
        }

        public Department(string departmentName, string adress, int buildingNumber, int numberOfStaff, DepartmentTypes departmentType)
        {   
            DepartmentName = departmentName;
            Adress = adress;
            NumberOfStaff = numberOfStaff;
            DepartmentType = departmentType;
        }

    }
}
