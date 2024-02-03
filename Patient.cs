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
            PrintSymptoms(numberOfSymptoms);

        }
        private List<Symptoms> PrintSymptoms(int numberOfSymptoms)
        {
            List<Symptoms> symptomsList= new List<Symptoms>();      //kreiramo listu tipa timptomi
            Symptoms[] symptom = Enum.GetValues<Symptoms>();        //kupimo sve simptome
            string symptomText = "";

            for(int i=0, range=100;i< symptom.Length && numberOfSymptoms!=0;i++)    
            {
                if ((int)symptom[i] - range >= 100)     //gledamo da li je id simptom[i] unutar prvog seta indeksa
                {                                       
                    int input=1;                       //potrebna je inicijalizacija prije while petlje nije
                    while (input != 0 && numberOfSymptoms>0)    //input 0 izlazi se iz opsega indeksa i ide u iduci ako je broj simpotma =0 onda skroz izlazi iz while petlji jer su svi upisani
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(symptomText + "\n\nAko se simptom nalazi na listi unesite njegov ID\nAko nije na listi unesite 0");
                        } while (!int.TryParse(Console.ReadLine(), out input)); //input se unosi , sve dok se pravilo ne unese integer

                        if (input != 0 && Enum.IsDefined(typeof(Symptoms), input) && !symptomsList.Contains((Symptoms)input))   
                        {
                            numberOfSymptoms--;                 //ako input nije 0 ako je definisan kao indeks u enum klasi i ako nije vec unjet 
                            symptomsList.Add((Symptoms)input);  // unosi se u listu simptoma 
                        }
                        else 
                        {
                            Console.Clear();
                            if (input != 0)
                            {
                                Console.WriteLine("Molim vas da : \tUnesete 0 ako se simptom ne nalazi na listi" +
                                "\n\t\tDa unesete ID simptoma ako se nalazi na listi" +
                                "\n\t\tDa ne ponavljate vec unesene ID");
                                Console.ReadKey();
                            }
                            
                        }
                    }
                    i--;
                    range += 100;       //prelazak u iduci opseg
                    symptomText = "";
                }
                else
                    symptomText += $"ID: {(int)symptom[i]} {symptom[i]} \n";
            }
            do 
            {
                Random r=new Random();
                Symptoms randomSymptom=(Symptoms)symptom.GetValue(r.Next(symptom.Length));
                if (!symptomsList.Contains(randomSymptom))
                {
                    symptomsList.Add(randomSymptom);
                    numberOfSymptoms--;
                }
            } while (numberOfSymptoms > 0);
            //Ako se simptomi nisu nalazili na listi, ostatak simpoma se slucajno bira sa liste simptoma
            foreach(Symptoms i in symptomsList)
            {
                Console.WriteLine(i);
            }

            return symptomsList;
        }
    }
}