using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal class Admission:Department
    {
        private Doctor _doctor;
        private List<Patient> _patientsList = new List<Patient>();
        private int _patientID=0;
        private int _numberOfPatients;

        public Doctor Doctor { get { return _doctor; } set { _doctor = value; } }
        public List<Patient> PatientsList { get { return _patientsList; } }
        public int NumberOfPAtients {  get { return _numberOfPatients; } }

        public Admission(string departmentName, string adress, int buildingNumber, int numberOfStaff, DepartmentTypes departmentType)
            : base(departmentName, adress, buildingNumber, numberOfStaff, DepartmentTypes.Prijem)
        {

            AddPatients();//bilo koji specijalista moze da radi na prijemu;
            Console.Clear();
            Console.WriteLine("Podaci za prijem");
            AddDoctor();
        }

        public void PrintAllPatients()
        {
            Console.WriteLine("Lista pacijenata na prijemu:");
            for (int i = 0; i < PatientsList.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + PatientsList[i].ToString());
            }
        }

        public void AddPatients()
        {
            Console.WriteLine("Koliko pacijenata zelite unjet");
            while (!int.TryParse(Console.ReadLine(), out this._numberOfPatients)) ;
            {
                Console.WriteLine("Pogresno unjeti broj");
            } 

            for(int i=0; i< NumberOfPAtients;i++)
            {
                Console.Clear();
                Console.WriteLine($"Unosite {(i + 1)}. pacijenta");
                AddPatient();
            }
        }
        public void AddPatient()
        {
            
            string firstName, lastName, sex, phoneNumber;
            int jmbg;
            DateTime dateBirth=DateTime.MinValue;
            Boolean hasInshurance;

            Console.WriteLine("Unesite ime pacijenta;");
            firstName = Console.ReadLine();
            Console.WriteLine("Unesite prezime pacijenta;");
            lastName = Console.ReadLine();
            Console.WriteLine("Unesite spol pacijenta;");
            sex = Console.ReadLine();
            Console.WriteLine("Unesite broj telefona pacijenta;");
            phoneNumber = Console.ReadLine();

            int i = 0;
            do
            {
                if (i == 0)
                {
                    i = 1;
                    Console.WriteLine("Unesite jmbg pacijenta;");
                }
            } while (!int.TryParse(Console.ReadLine(), out jmbg));

            int year, month, day;
            bool isValidDate = false;
            while (!isValidDate)
            {
                i = 0;
                Console.WriteLine("Enter the year of bith");
                while (!int.TryParse(Console.ReadLine(), out year) || year < 1900 || year > DateTime.Now.Year)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("Invalid year try again");
                        i = 1;
                    }
                }

                i = 0;
                Console.WriteLine("Enter the month of bith");
                while (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("Invalid month try again");
                        i = 1;
                    }
                }

                i = 0;
                Console.WriteLine("Enter the day of bith");
                while (!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > DateTime.DaysInMonth(year, month))
                {
                    if (i == 0)
                    {
                        Console.WriteLine("Invalid day try again");
                        i = 1;
                    }
                }

                try
                {
                    dateBirth = new DateTime(year, month, day);
                    isValidDate = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Not a valid date"+e);
                }
            }

            Console.WriteLine("Ako pacijent ima osiguranje unesite 1\nAko pacijent nema osiguranje unesite 0;");
            i = 0;
            int input;
            do
            {
                if (i == 0)
                {
                    i = 1;
                    Console.WriteLine("Ako pacijent ima osiguranje unesite 1\nAko pacijent nema osiguranje unesite 0;");
                }
            } while (!int.TryParse(Console.ReadLine(), out input));
            if (input == 0)
            {
                hasInshurance = false;
            }
            else
            {
                hasInshurance = true;
            }
            _patientID++;

            Patient newPatient = new Patient(_patientID,  firstName,  lastName,  jmbg, dateBirth,  sex,  phoneNumber,  hasInshurance);
            this._patientsList.Add(newPatient);
        }

        public void CheckPatients()
        {
            List<Patient> CheckedPatients = new List<Patient>();
            foreach (Patient patient in PatientsList)
            {
                if (patient.PatientSymptoms.Count == 1 && 
                    ((int)patient.PatientSymptoms[0])>=100 && ((int)patient.PatientSymptoms[0]) < 200)
                {
                    Console.WriteLine("Pacijent ima blage simptome koji se mogu izljeciti kod kuce");
                    CheckedPatients.Add(patient);
                    OdpusnoPismo(patient, Doctor);
                }else
                {
                    patient.GetTreatmentClinics();
                    Uputnica( patient, Doctor);
                }
            }
            foreach (var patient in CheckedPatients)
            {
                PatientsList.Remove(patient);
            }//ostaju pacijenti koji se trebaju poslati
        }


        public void OdpusnoPismo(Patient patient, Doctor doctor)
        {
            Console.WriteLine($"Pacijent {patient.Firstname} {patient.Lastname} je izljecen od {patient.PatientSymptoms[0]}, Doktor  DR. {doctor.Firstname} {doctor.Lastname} je odredio terapiju.");
        }

        public void Uputnica(Patient patient, Doctor doctor)
        {
            Console.WriteLine($"Pacijent {patient.Firstname} {patient.Lastname} boluje od tezih simptoma salje se specijalisti {patient.PatientNeedsToVisit}, Doktor  DR. {doctor.Firstname} {doctor.Lastname} je napisao uputnicu.");
        }

        public Patient SendForTreatment(int indeks)
        {
            Patient patientTreatment = PatientsList[indeks];
            PatientsList.Remove(patientTreatment);
            return patientTreatment;
        } 
    }
}

