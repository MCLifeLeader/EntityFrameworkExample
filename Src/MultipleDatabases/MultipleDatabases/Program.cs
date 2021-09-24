using System;

namespace MultipleDatabases
{
    // ReSharper disable once ArrangeTypeModifiers
    // ReSharper disable once InconsistentNaming
    class Program
    {
        private const string SqlConnDbOne = "Data Source=localhost\\sqlexpress;Initial Catalog=DemoDbOne;Integrated Security=True;MultipleActiveResultSets=True";
        private const string SqlConnDbTwo = "Data Source=localhost\\sqlexpress;Initial Catalog=DemoDbTwo;Integrated Security=True;MultipleActiveResultSets=True";

        static void Main(string[] args)
        {
            string menuInput;
            BusinessLogic businessLogic = new(SqlConnDbOne, SqlConnDbTwo);

            do
            {
                Console.WriteLine("");
                Console.WriteLine("1. Read Records from First Database");
                Console.WriteLine("2. Read Records from Second Database");
                Console.WriteLine("3. Write Record to First Database");
                Console.WriteLine("4. Write Record to Second Database");
                Console.WriteLine("Q. Quit");
                Console.Write("Enter Option: ");
                menuInput = Console.ReadLine();

                string dbInput;
                switch (menuInput?.ToLower())
                {
                    case "1":
                        PrintStarBreak("\n");
                        businessLogic.ReadDbOne();
                        PrintStarBreak();
                        break;
                    case "2":
                        PrintStarBreak("\n");
                        businessLogic.ReadDbTwo();
                        PrintStarBreak();
                        break;
                    case "3":
                        Console.Write("Enter Some Text into the DB: ");
                        dbInput = Console.ReadLine();
                        businessLogic.WriteDbOne(dbInput);
                        break;
                    case "4":
                        Console.Write("Enter Some Text into the DB: ");
                        dbInput = Console.ReadLine();
                        businessLogic.WriteDbTwo(dbInput);
                        break;
                }

            } while (menuInput != null && !menuInput.ToLower().Contains("q"));
        }

        private static void PrintStarBreak(string input = "")
        {
            Console.WriteLine($"{input}*******************************");
        }
    }
}
