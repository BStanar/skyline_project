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

        public Boolean HasInshurance { get; set; }

        
        public Patient(int id, string firstName, string lastname, int jmbg, DateTime dateBirth, string sex, string phoneNumber, Boolean hasInshurance) :
            base( id,  firstName,  lastname,  jmbg,  dateBirth,  sex,  phoneNumber)
        {
            HasInshurance= hasInshurance;
            Symptoms = new List<Symptoms>();
        }

        public override string ToString()
        {
            int age = int.Parse(DateTime.Now.ToString("yyyyMMdd")) - int.Parse(DateBirth.ToString("yyyyMMdd"));
            return $"Patient ID:{ID}\tName: {Firstname} Lastname: {Lastname}, Sex: {Sex}, Age: {age}";
        }
        public string ListPatientWithSymptoms()
        {
            int age = int.Parse(DateTime.Now.ToString("yyyyMMdd")) - int.Parse(DateBirth.ToString("yyyyMMdd"));
            return $"Patient ID:{ID}\tName: {Firstname} Lastname: {Lastname}, Sex: {Sex}, Age: {age}\n Symptoms:\t-"+string.Join(",\n\t\t-",Symptoms);
        }

    }
}
