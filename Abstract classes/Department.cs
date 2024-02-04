using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace skyline_project
{
    abstract class Department
    {
        private DepartmentTypes _departmentType;
        private string? _departmentName;
        private string? _adress;
        private int _buildingNumber;
        private int _numberOfStaff;
        private List<Doctor> _doctors = new List<Doctor>();
        private int _doctorID = 0;


        public DepartmentTypes DepartmentType
        {
            get { return _departmentType; }
            set { _departmentType = value; }
        }
        public string? DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }
        public string? Adress
        {
            get { return _adress; }
            set { _adress = value; }
        }
        public int BuildingNumber
        {
            get { return _buildingNumber; }
            set { _buildingNumber = value; }
        }
        public int NumberOfStaff
        {
            get { return _numberOfStaff; }
            set { _numberOfStaff = value; }
        }

        public int DoctorID 
        { 
            get { return _doctorID; }
        }

        public void AddDoctor(Doctor value)
        {
            this._doctors.Add(value);
        }

        public Department(string departmentName, string adress, int buildingNumber, int numberOfStaff, DepartmentTypes departmentType)
        {   
            DepartmentName = departmentName;
            Adress = adress;
            NumberOfStaff = numberOfStaff;
            DepartmentType = departmentType;
        }

        public void AddDoctor()
        {
            string? firstName ="", lastName = "", sex = "", phoneNumber = "", username = "", password = "";
            int jmbg;
            DateTime startOfEmployment = DateTime.MinValue,dateBirth= DateTime.MinValue;
            Boolean isheadDoctor=false;
            Console.WriteLine("Unesite podatke o doktoru :");

            Console.WriteLine("Unesite ime doktora :");
            firstName = Console.ReadLine();
            Console.WriteLine("Unesite prezime doktora :");
            lastName = Console.ReadLine();
            Console.WriteLine("Unesite spol doktora :");
            sex = Console.ReadLine();
            Console.WriteLine("Unesite broj telefona doktora :");
            phoneNumber = Console.ReadLine();

            jmbg = GetJMBG();

            Console.WriteLine("Unesite rodjenje doktora :");
            dateBirth = GetDate();

            Console.WriteLine("Unesite pocetak rada doktora :");
            startOfEmployment = GetDate();
            Console.WriteLine("Unesite korisnicko ime  doktora :");
            username = Console.ReadLine();
            Console.WriteLine("Unesite sifru  doktora :");
            password = Console.ReadLine();

            isheadDoctor = IsHead();
            SpecialistTypes specialistTypes = GetSpecialistTypes();

            _doctorID++;
            Doctor NewDoctor = new Doctor(_doctorID, firstName, lastName, jmbg, dateBirth,sex,phoneNumber,startOfEmployment,username,password,isheadDoctor, specialistTypes, EmployeeRole.Doktor,DepartmentType);
            this._doctors.Add(NewDoctor);
            Console.WriteLine(NewDoctor.ToString());
            Console.ReadKey();
        }

        public DateTime GetDate()
        {
            DateTime date = DateTime.Now;
            int year, month, day,i=0;
            bool isValidDate = false;
            while (!isValidDate)
            {
                i = 0;
                Console.WriteLine("Unesite godinu ");
                while (!int.TryParse(Console.ReadLine(), out year) || year < 1900 || year > DateTime.Now.Year)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("Lose unjet podatak");
                        i = 1;
                    }
                }

                i = 0;
                Console.WriteLine("Unesite mjesec ");
                while (!int.TryParse(Console.ReadLine(), out month) || month < 1 || month > 12)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("Lose unjet podatak");
                        i = 1;
                    }
                }

                i = 0;
                Console.WriteLine("Unesite dan ");
                while (!int.TryParse(Console.ReadLine(), out day) || day < 1 || day > DateTime.DaysInMonth(year, month))
                {
                    if (i == 0)
                    {
                        Console.WriteLine("Lose unjet podatak");
                        i = 1;
                    }
                }

                try
                {
                    date = new DateTime(year, month, day);
                    isValidDate = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Lose unjet podatak");
                }
            }
            return date;
        }
        public Boolean IsHead()
        {
            bool isHead = false;
            Console.WriteLine("Ako je doktor glavni doktor  1\nAko doktor nije glavni 0;");
            int i = 0;
            int input;
            do
            {
                if (i == 0)
                {
                    i = 1;
                    Console.WriteLine("Ako je doktor glavni doktor  1\nAko doktor nije glavni 0;");
                }
            } while (!int.TryParse(Console.ReadLine(), out input));
            if (input == 0)
            {
                isHead = false;
            }
            else
            {
                isHead = true;
            }
            return isHead;
        }
    
        public int GetJMBG()
        {
            int i = 0,input;
            do
            {
                if (i == 0)
                {
                    i = 1;
                    Console.WriteLine("Unesite jmbg doktora;");
                }
            } while (!int.TryParse(Console.ReadLine(), out input));
            return input;
        }
    
        public SpecialistTypes GetSpecialistTypes()
        {
            Console.WriteLine("Izaberite koja je specijalizacija"); 
            var types = Enum.GetValues(typeof(SpecialistTypes));
            foreach (var type in types)
            {
                Console.WriteLine($"{(int)type}. {type}");
            }
            int i = 0, input;
            do
            {
                if (i == 0)
                {
                    i = 1;
                    Console.WriteLine("Unesite jmbg doktora;");
                }
            } while (!int.TryParse(Console.ReadLine(), out input)  && Enum.IsDefined(typeof(SpecialistTypes), input));
            return (SpecialistTypes)input;

        }
    }
}
