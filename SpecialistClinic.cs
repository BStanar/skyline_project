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
        private List<Patient> _patientsList = new List<Patient>();
        private List<Patient> _transferPatientList = new List<Patient>();

        public SpecialistTypes SpecialistType { get { return _type; } }
        public List<Patient> PatientsList { get { return _patientsList; } }
        public List<Patient> TransferPatientList { get { return _transferPatientList; } }
        public int IdSpecialistClinic
        {
            get { return _idSpecialistClinic; }
            set { _idSpecialistClinic = value; }
        }

        public SpecialistClinic(string departmentName, string adress, int buildingNumber, int numberOfStaff, DepartmentTypes departmentType, SpecialistTypes specialistType)
            : base(departmentName, adress, buildingNumber, numberOfStaff, DepartmentTypes.Specijalisticka_klinika)
        {
            this._type = specialistType;
            IdSpecialistClinic = (int)specialistType;//Promjeniti da pogleda u xml fajl i odatle izvlaci id
            AddDoctor();
        }

        public void AddPatient(Patient patient)
        {
            this._patientsList.Add(patient);
        }

        public void TreatPatient()
        {
            Console.WriteLine("Pacijenti koji se trebaju lijeciti specijalisti");
            int index, NumberOFTreatabels = PatientsList.Count;

            for (int i = 0; i < NumberOFTreatabels; i++)
            {
                Console.WriteLine($"{(i)}. pacijent {PatientsList[i]}");
            }

            Console.WriteLine("Unesite indeks pacijenta, kojeg zelite ljeciti");
            do
            {
                Console.WriteLine("Pogresna vrijednost");

            } while (!int.TryParse(Console.ReadLine(), out index) && (index < 0 || index >= NumberOFTreatabels));


            PatientsList[index].RemoveSymptoms(SpecialistType);
            

            if (PatientsList[index].IsCured==false && PatientsList[index].PatientSymptoms.Any(symptom => (int)symptom >= (int)SpecialistType && (int)symptom < (int)SpecialistType + 100));
            {
                Patient patient = PatientsList[index];
                PatientsList.RemoveAt(index);
                this._transferPatientList.Add(patient);
            }
        }
    }
}
