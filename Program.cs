﻿using skyline_project;


namespace skyline_project
{
    class program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital("SkylineCommunications bolnica", "Tesanjska", 24, Enum.GetNames(typeof(SpecialistTypes)).Length + 1);
            
            
            
            
            
            
            
            /*HospitalMenagmentStart();

            void HospitalMenagmentStart()
            {
                bool exit = false;
                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                    Console.WriteLine("SkyLine Bolnica");
                    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\n");

                    Console.WriteLine("1. Log in");
                    Console.WriteLine("0.Exit");

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("111111");
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Pokusajte ponovo");
                            break;
                    }
                }
            }*/

        }
    }
}



