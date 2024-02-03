using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal class Patient : Person
    {

        private List<Symptoms> _patientSymptoms=new List<Symptoms>();

        public List<Symptoms> PatientSymptoms
        {
            get { return _patientSymptoms; }
        }

        private Boolean _hasInshurance;
        private Boolean _isCured;
        public Boolean HasInshurance
        {
            get { return _hasInshurance; }
            set { _hasInshurance = value; }
        }
        public Boolean IsCured
        {
            get { return _isCured; }
            set { _isCured = value; }
        }

        public Patient(int id, string firstName, string lastname, int jmbg, DateTime dateBirth, string sex, string phoneNumber, Boolean hasInshurance) :
            base( id,  firstName,  lastname,  jmbg,  dateBirth,  sex,  phoneNumber)
        {
            HasInshurance= hasInshurance;
            IsCured= false;
        }

        public override string ToString()
        {
            return $"Patient ID:{ID}\tName: {Firstname} Lastname: {Lastname}, Sex: {Sex}, Age: {DateBirth}\n Symptoms:\t-"+string.Join(",\n\t\t-", PatientSymptoms);
        }

        public void AddSymptoms() 
        {
            //Unosenje broja simptoma koje pacijent ima
            int numberOfSymptoms = 1;
            Console.WriteLine("Koliko simpotoma ima pacijent");
            numberOfSymptoms=Convert.ToInt16( Console.ReadLine());

            Console.WriteLine(numberOfSymptoms);
            this._patientSymptoms = PrintSymptoms(numberOfSymptoms);

        }
        private List<Symptoms> PrintSymptoms(int numberOfSymptoms)
        {
            List<Symptoms> symptomsList= new List<Symptoms>();      
            Symptoms[] symptom = Enum.GetValues<Symptoms>();        
            string symptomText = "";
            /*  U for petlji iniciramo i=0 i range=100, opseg se postavlja na 100 jer su simptomi i specijalisticke klinike koji ih lijece grupisani 
             *  po indeksima od 100.Opca medicina je indeksa 100 simptome koje lijeci su od 100 do 199. Ovako su postavljeni enum vrijednosti zbog 
             *  lakseg prosirivanja. For petlja se izvrsava dok jos ima ne unesenih simptoma numberOfSymptoms ili dok ne dodje do kraja simptoma.
             *  Gledamo da li je razlika simptominog indeksa i opsega veca od 100. Ako je manja znaci da je simptom u trenutacnom opsegu i dopisujemo 
             *  ga u string za ispisivanje symptomText. Ako je razlika jednaka ili veca od 100 to znaci da smo izasli iz prvobitnog opsega, pa ispisujemo symptomText.
             *  Unosi se input sve dok ne zadovolji potrebne uslove. Indeksni broj se upisuje samo ako vec nije u listi simptoma i ako je definisan u enumu.
             *  Iduci korak povecava se opseg sve dok ne dodje do zadnje vrijednosti u enumi ili dok se ne unesu svi simptomi. Ako je br simptoma odredena ali nije unjet, 
             *  nasumice se unose simptomi */
            for (int i=0, range=100;i< symptom.Length && numberOfSymptoms!=0;i++)    
            {
                if ((int)symptom[i] - range >= 100)
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

                        if (input != 0 && Enum.IsDefined(typeof(Symptoms), input) && !symptomsList.Contains((Symptoms)input))   
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
                    symptomText += $"ID: {(int)symptom[i]} {symptom[i]} \n";
            }

            for (int i = 0; i < numberOfSymptoms; i++)
            {
                Random r = new Random();
                Symptoms randomSymptom = (Symptoms)symptom[r.Next(symptom.Length)];
                if (!symptomsList.Contains(randomSymptom))
                {
                    symptomsList.Add(randomSymptom);
                }
                else 
                {
                    i--;
                }
            }
            return symptomsList;
        }

        public void RemoveSymptoms(SpecialistTypes specialistClinic)
        {
            /*  Kreira listu simptoma koji se mogu izljeciti, tako sto dodjae sve simptome ciji je indeks <= indeksu specijalisticke klinike 
             *  i manji od 2*index spec klinike nasumicno se bira jedan od simptoma iz liste za lijecenje, izabrani simptom se brise iz liste 
             *  liste simpoma od pacijenta*/
            if(IsCured)
            {
                Console.WriteLine("Pacijent je izljecen");
            }
            else if (!PatientSymptoms.Any(symptom => (int)specialistClinic <= (int)symptom && (int)symptom < ((int)specialistClinic) * 2))
            {
                Console.WriteLine("Ne postoje simptomi koji se mogu izlijeciti na ovoj klinici");
            }
            else
            {
                List<Symptoms> possibleToCure = PatientSymptoms.Where(symptom => (int)specialistClinic <= (int)symptom && (int)symptom < ((int)specialistClinic) * 2).ToList();
                Random r = new Random();
                Symptoms curedSymptom = (Symptoms)possibleToCure[r.Next(possibleToCure.Count)];
                this._patientSymptoms.Remove(curedSymptom);
                possibleToCure.Remove(curedSymptom);
                if (PatientSymptoms.Count > 0 && possibleToCure.Count == 0)
                {
                    Console.WriteLine("Pacijent se treba prebaciti u drugi odjel");
                    List<int> symptomGrops = PatientSymptoms.Select((int)s => (int)s / 100);
                    symptomGrops=symptomGrops.Distinct().ToList();
                    foreach (var i in symptomGrops)
                    {
                        Console.WriteLine("-" + (SpecialistTypes)i);
                    }
                }
            } 
            
        }
    }
}