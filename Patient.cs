using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    internal class Patient : Person
    {

        public List<Symptoms> Symptoms=new List<Symptoms>();

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
        {return $"Patient ID:{ID}\tName: {Firstname} Lastname: {Lastname}, Sex: {Sex}, Age: {DateBirth}\n Symptoms:\t-"+string.Join(",\n\t\t-",Symptoms);
        }

        public void AddSymptoms() 
        {
            //Unosenje broja simptoma koje pacijent ima
            int numberOfSymptoms=1;
            Console.WriteLine("Koliko simpotoma ima pacijent");
            numberOfSymptoms=Convert.ToInt16( Console.ReadLine());

            //Pokupit sve simptome u niz
            Symptoms[] symptomsList = Enum.GetValues<Symptoms>();
            int symptomRange = 100;

            //prikazivanje simptoma po specijalizaciji 
            Console.WriteLine("Prikazat ce vam se lista mogucih simptoma");
            for(int i=0; i < numberOfSymptoms; i++)
            {
                while (true) 
                {
                    Console.WriteLine($"Ispisuje se {symptomRange / 100}. grupa simptoma");
                    foreach(Symptoms symptom in symptomsList)
                    {
                        int symptomIDValue = (int)symptom;
                        if(symptomIDValue>=symptomRange && symptomIDValue < symptomRange + 100)
                        {
                            Console.WriteLine($"ID:{symptomIDValue}\t{symptom}");
                        }
                    }
                    Console.WriteLine($"Ako je vas simptom na listi unesite njegov id");

                }
            }
        }
    }
}
