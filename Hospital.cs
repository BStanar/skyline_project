using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal class Hospital:Department
    {
        private int _numberOfDepartments;
        private Admission admission;
        private List<SpecialistClinic> specialists= new List<SpecialistClinic>();
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
            GenerateSpecialists(adress, buildingNumber);
        }

        public void GenerateSpecialists(string adress, int buildingNumber)
        {
            for (int i = 0; i < Enum.GetNames(typeof(SpecialistTypes)).Length; i++)
            {
                Console.Clear();
                Console.WriteLine($"Unesite podatke o dkotoru koji radi na {(SpecialistTypes)(i * 100)}");
                SpecialistClinic clinic = new SpecialistClinic($"Specijalisticka klinika za {(SpecialistTypes)i}", adress, buildingNumber, 1, DepartmentTypes.Specijalisticka_klinika, (SpecialistTypes)i);
                clinic.AddDoctor();
                specialists.Add(clinic);
            }
        }
        public void TransferOfPatient(Admission admission, List<SpecialistClinic> specialists)
        {
            Patient transferringPatient = ChooseAPatient(admission);
            SpecialistTypes clinicType = WhereIsPatientGoing(transferringPatient);

            SpecialistClinic clinic = specialists.FirstOrDefault(s => s.SpecialistType == clinicType);
            
            clinic.AddPatient(transferringPatient);
            Console.WriteLine($"PAcijent {transferringPatient.ID} premjesten u {clinic.DepartmentName}.");
            
        }
        public Patient ChooseAPatient(Admission admission)
        {
            Console.WriteLine("Pacijenti koji se trebaju slati specijalisti");
            int index, numberOfTransferable = admission.PatientsList.Count;

            for (int i = 0; i < numberOfTransferable; i++)
            {
                Console.WriteLine($"{(i)}. pacijent {admission.PatientsList[i]}");
            }

            Console.WriteLine("Unesite indeks pacijenta, u koji se prebacuje");
            do
            {
                Console.WriteLine("Pogresna vrijednost");

            }while (!int.TryParse(Console.ReadLine(), out index) && (index < 0 || index >= numberOfTransferable));

            return admission.SendForTreatment(index);
        }
        public SpecialistTypes WhereIsPatientGoing(Patient patient)
        {
            Console.WriteLine("Patient needs to go: ");

            int numberOfClinicsNeaded = patient.PatientNeedsToVisit.Count,index;

            for (int i = 0; i < numberOfClinicsNeaded; i++)
            {
                Console.WriteLine($"{(i)}. pacijent {patient.PatientNeedsToVisit[i]}");
            }

            Console.WriteLine("Unesite indeks klinike, u koju  pacijent reba da ide:");
            do
            {
                Console.WriteLine("Pogresna vrijednost");
            } while (int.TryParse(Console.ReadLine(), out index) &&( index < 0 || index > numberOfClinicsNeaded - 1));

            return patient.PatientNeedsToVisit[index];
        }

        public void FromClinicToClinic(SpecialistClinic from)
        {

            if (from.TransferPatientList.Count > 0)
            {
                int toTypeIndex = (int)from.TransferPatientList[0].PatientSymptoms[0] / 100;
                toTypeIndex = toTypeIndex * 100;
                SpecialistTypes types = (SpecialistTypes)toTypeIndex;

                SpecialistClinic clinic = specialists.FirstOrDefault(s => s.SpecialistType == types);

                clinic.AddPatient(from.TransferPatientList[0]);
                from.TransferPatientList.RemoveAt(0);
            }

        }
    }
}
