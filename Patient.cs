using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal class Patient : Person
    {

        private List<Symptoms> _patientSymptoms = new List<Symptoms>();
        private int _numberOfSymptoms = 1;
        private Boolean _hasInsurance;
        private Boolean _isCured;
        private List<SpecialistTypes> _patientNeedsToVisit = new List<SpecialistTypes>();

        public int NumberOfSymptoms
        {
            get { return _numberOfSymptoms; }
            set { _numberOfSymptoms = value; }
        }
        public List<Symptoms> PatientSymptoms
        {
            get { return _patientSymptoms; }
        }
        public Boolean HasInsurance
        {
            get { return _hasInsurance; }
            set { _hasInsurance = value; }
        }
        public Boolean IsCured
        {
            get { return _isCured; }
            set { _isCured = value; }
        }
        public List<SpecialistTypes> PatientNeedsToVisit
        {
            get { return _patientNeedsToVisit; }
}

        public Patient(int id, string firstName, string lastname, int jmbg, DateTime dateBirth, string sex, string phoneNumber, Boolean hasInshurance) :
            base( id,  firstName,  lastname,  jmbg,  dateBirth,  sex,  phoneNumber)
        {
            HasInsurance = hasInshurance;
            IsCured= false;
            NumberOfSymptoms = 1;
            AddSymptoms();

        }

        public override string ToString()
        {
            return $"Patient ID:{ID}\tName: {Firstname} Lastname: {Lastname}, Sex: {Sex}, Age: {Person.}\n Symptoms:\t-"+string.Join(",\n\t\t-", PatientSymptoms);
        }

        public void AddSymptoms() 
        {
            GetNumberSymptoms();
            GenerateSymptoms(NumberOfSymptoms);
        }

        public void AddRandomSymptoms()
        {
            GetNumberSymptoms();
            GenerateRandomSymptoms(NumberOfSymptoms);
        }

        public void GetNumberSymptoms()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Koliko simpotoma ima pacijent");
            } while (!int.TryParse(Console.ReadLine(), out this._numberOfSymptoms));
        }

        private void GenerateSymptoms(int numberOfSymptoms)
        {
            /*  U for petlji iniciramo i=0 i range=100, opseg se postavlja na 100 jer su simptomi i specijalisticke klinike koji ih lijece grupisani 
             *  po indeksima od 100.Opca medicina je indeksa 100 simptome koje lijeci su od 100 do 199. Ovako su postavljeni enum vrijednosti zbog 
             *  lakseg prosirivanja. For petlja se izvrsava dok jos ima ne unesenih simptoma numberOfSymptoms ili dok ne dodje do kraja simptoma.
             *  Gledamo da li je razlika simptominog indeksa i opsega veca od 100. Ako je manja znaci da je simptom u trenutacnom opsegu i dopisujemo 
             *  ga u string za ispisivanje symptomText. Ako je razlika jednaka ili veca od 100 to znaci da smo izasli iz prvobitnog opsega, pa ispisujemo symptomText.
             *  Unosi se input sve dok ne zadovolji potrebne uslove. Indeksni broj se upisuje samo ako vec nije u listi simptoma i ako je definisan u enumu.
             *  Iduci korak povecava se opseg sve dok ne dodje do zadnje vrijednosti u enumi ili dok se ne unesu svi simptomi. Ako je br simptoma odredena ali nije unjet, 
             *  nasumice se unose simptomi */
            List<Symptoms> symptomsList= new List<Symptoms>();      
            Symptoms[] allSymptoms = Enum.GetValues<Symptoms>();        
            string symptomText = "";
            for (int i=0, range=100;i< allSymptoms.Length && numberOfSymptoms!=0;i++)    
            {
                if ((int)allSymptoms[i] - range >= 100)
                {                                       
                    int input=1;
                    while (input != 0 && numberOfSymptoms>0)   
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(symptomText + "\n\nMolim vas da: \tUnesete 0 ako se simptom ne nalazi na listi" +
                                "\n\t\tDa unesete ID simptoma ako se nalazi na listi\n\t\tDa ne ponavljate vec unesene ID");
                        } while (!int.TryParse(Console.ReadLine(), out input));

                        if (input != 0 && Enum.IsDefined(typeof(Symptoms), input) && !symptomsList.Contains((Symptoms)input) && input<(range+range))   
                        {
                            numberOfSymptoms--;                 
                            symptomsList.Add((Symptoms)input);  
                        }
                    }
                    i--;
                    range += 100;       
                    symptomText = "";
                }
                else
                    symptomText += $"ID: {(int)allSymptoms[i]} {allSymptoms[i]} \n";
            }
            this._patientSymptoms = symptomsList;
            if (numberOfSymptoms!=0)
                GenerateRandomSymptoms(numberOfSymptoms);
        }

        public void RemoveSymptoms(SpecialistTypes specialistClinic)
        {
            /*  Kreira listu simptoma koji se mogu izljeciti, tako sto dodjae sve simptome ciji je indeks <= indeksu specijalisticke klinike 
             *  i manji od 2*index spec klinike nasumicno se bira jedan od simptoma iz liste za lijecenje, izabrani simptom se brise iz liste 
             *  liste simpoma od pacijenta*/
            List<Symptoms> possibleToCure = PatientSymptoms.Where(symptom => (int)specialistClinic <= (int)symptom && (int)symptom < ((int)specialistClinic) * 2).ToList();

            if (IsCured)
            {
                Console.WriteLine("Pacijent je izljecen");
            }
            else if (possibleToCure.Count==0)
            {
                GetTreatmentClinics();
            }
            else
            {
                Random r = new Random();
                Symptoms curedSymptom = (Symptoms)possibleToCure[r.Next(possibleToCure.Count)];
                this._patientSymptoms.Remove(curedSymptom);
                possibleToCure.Remove(curedSymptom);
                if (PatientSymptoms.Count > 0 && possibleToCure.Count == 0)
                {
                    GetTreatmentClinics();
                }
                else
                {
                    IsCured=true;
                }
            } 
            
        }

        private void GetTreatmentClinics()
        {
            /*Provjerava se lista simptoma koje pacijent ima i ispisuju se sve klinike gdje pacijent treba da ode
             * int Indeks simptoma djelimo sa 100 da bi dobili 1//2//3//4//5, pa kasnije kad trazimo specijalisticku 
             * kliniku omnozimo sa 100 da dobijemo dogovarajucu
            */
            var symptomGrops = PatientSymptoms
                        .Select((s => (int)s / 100))
                        .Distinct()
                        .ToList();

            Console.WriteLine("Pacijent se treba prebaciti na drugi odjel");
            foreach (var group in symptomGrops)
            {
                var clinic = (SpecialistTypes)(group * 100);
                Console.WriteLine("-" + clinic);
                this._patientNeedsToVisit.Add(clinic);
    }
        }

        private void GenerateRandomSymptoms(int numberOfSymptoms)
        {
            
            Random r = new Random(); 
            Symptoms[] allSymptoms = Enum.GetValues<Symptoms>();
            for (int i = 0; i < numberOfSymptoms; i++)
            {
                Symptoms randomSymptom = (Symptoms)allSymptoms[r.Next(allSymptoms.Length)];
                if (!this._patientSymptoms.Contains(randomSymptom))
                {
                    this._patientSymptoms.Add(randomSymptom);
                }
                else
                {
                    i--;
                }
            }
        }

        public void RemoveSymptoms(SpecialistTypes specialistClinic)
        {
            if (PatientSymptoms.Count == 0)
            {
                Console.WriteLine("Nema simptoma za lijecenje, pacijent je zdrav");
                IsCured = true;
            }
            else
            {
                List<Symptoms> possibleToCure = PatientSymptoms.Where(symptom=> (int)specialistClinic <= (int)symptom && (int)symptom < ((int)specialistClinic) * 2).ToList();
                Random r = new Random();
                Symptoms curedSymptom = (Symptoms)symptom.GetValue(r.Next(possibleToCure.Length));
                this._patientSymptoms.Remove(curedSymptom);
                possibleToCure.Remove(curedSymptom);


                if (PatientSymptoms.Count > 0 && possibleToCure.Count==0) 
                {
                    Console.WriteLine("Treba ga premjestiti na drugu kliniku")
                }
                else
                {
                    IsCured = true;
                }
            }

        }
    }
}