using skyline_project;

namespace skyline_project
{
    class program
    {
        static void Main(string[] args)
        {
            Patient pacijent = new Patient(0, "Boris", "Stanar", 1231231, new DateTime(1996,02,26), "Male", "123123123", true);

            Console.WriteLine(pacijent.ToString());
            Console.ReadKey();
            pacijent.RemoveSymptoms(SpecialistTypes.Opća_Medicina);
            Console.WriteLine(pacijent.ToString());

            Console.ReadKey();

        }
    }
}



