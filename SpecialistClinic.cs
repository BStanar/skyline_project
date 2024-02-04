using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal class SpecialistClinic : Department
    {
        private SpecialistTypes _type;
        private int _idSpecialistClinic;
        private Doctor _doctor;

        public Doctor Doctor { get { return _doctor; } }
        public SpecialistTypes SpecialistTypes { get { return _type; } }
        public int IdSpecialistClinic { get { return _idSpecialistClinic; } }
        public SpecialistClinic(string departmentName, string adress, int buildingNumber, int numberOfStaff, DepartmentTypes departmentType, SpecialistTypes specialistType)
            : base(departmentName, adress, buildingNumber, numberOfStaff, DepartmentTypes.Specijalisticka_klinika)
        {
            this._type = specialistType;
            this._idSpecialistClinic = IdSpecialistClinic;//Promjeniti da pogleda u xml fajl i odatle izvlaci id
            this._doctor = new Doctor(0, "Ime doktora", "Prezime doktora", 102312, DateTime.Now, "M", "12312312", DateTime.MinValue, "doktor1", "password", true, specialistType, EmployeeRole.Doktor, DepartmentTypes.Specijalisticka_klinika);
        }
    }
}
