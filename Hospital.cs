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
        private Admission admission;
        private List<SpecialistClinic> specialists;
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
        public Admission Admission { get { return admission; } }
        /*Trebaju radncii i trebaju Odjeli*/

        public Hospital(string departmentName, string adress, int buildingNumber, int numberOfStaff) 
            : base(departmentName, adress, buildingNumber, numberOfStaff, DepartmentTypes.Bolnica)
        {
            NumberOfDepartments = Enum.GetNames(typeof(SpecialistTypes)).Length+1; 

            this.admission = new Admission(departmentName, adress, buildingNumber, 1, DepartmentTypes.Prijem);

            for(int i=0;i< Enum.GetNames(typeof(SpecialistTypes)).Length;i++)
            {
                Console.Clear();
                Console.WriteLine($"Unesite podatke o dkotoru koji radi na {(SpecialistTypes)i}");
                SpecialistClinic clinic = new SpecialistClinic($"Specijalisticka klinika za {(SpecialistTypes)i}",adress,buildingNumber,1,DepartmentTypes.Specijalisticka_klinika,(SpecialistTypes)i);
                clinic.AddDoctor();
                specialists.Add(clinic);
            }
        }



        

    }
}
