using skyline_project;

namespace skyline_project
{
    class program
    {
        static void Main(string[] args)
        {
            Patient pacijent = new Patient(0, "Boris", "Stanar", 1231231, new DateTime(1996), "Male", "123123123", true);

            //pacijent.AddSymptoms();

            int i = 323 / 100;
            Console.WriteLine(i);
            Console.ReadKey();

        }
    }
}



