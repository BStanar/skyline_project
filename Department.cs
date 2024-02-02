using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    abstract class Department
    {
        public DepartmentTypes DepartmentType { get; set; }
        public string DepartmentName {  get; set; }
        public string Adress {  get; set; }
        public int BuildingNumber { get; set; }
        protected int NumberOfStaff {  get; set; }
        public List<Doctor> Doctors { get; set; }

        public Department(string departmentName,string adress, int buildingNumber, int numberOfStaff) 
        {   
            DepartmentName = departmentName;
            Adress = adress;
            NumberOfStaff = numberOfStaff;
            Doctors = new List<Doctor>();
        }
    }
}
/*Bolnica 
****************************************
Naziv
adresu
Zgrada
broj specijalistickih klinika
Broj zaposlenih
ListaOdjela[]
ListaZaposlenih[]
****************************************


Specijalisticki odjel
****************************************
Specijalizaciju
Lista simptoma koje moze lijeciti
Br kreveta
Br zauzetih kreveta
Pacijenti koji su na lezanju []*/
