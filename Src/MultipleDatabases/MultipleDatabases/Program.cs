using System;
using MultiDatabase.DbOneRepository;
using MultiDatabase.DbOneRepository.Interfaces;
using MultiDatabase.DbTwoRepository;
using MultiDatabase.DbTwoRepository.Interfaces;

namespace MultipleDatabases
{
   class Program
   {
      private const string SqlConnDbOne = "Data Source=localhost\\sqlexpress;Initial Catalog=DemoDbOne;Integrated Security=True;MultipleActiveResultSets=True";
      private const string SqlConnDbTwo = "Data Source=localhost\\sqlexpress;Initial Catalog=DemoDbTwo;Integrated Security=True;MultipleActiveResultSets=True";

      static void Main(string[] args)
      {
         string menuInput;
         string dbInput;
         BusinessLogic businessLogic = new BusinessLogic(SqlConnDbOne, SqlConnDbTwo);

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

            switch (menuInput?.ToLower())
            {
               case "1":
                  businessLogic.ReadDbOne();
                  break;
               case "2":
                  businessLogic.ReadDbTwo();
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
   }
}
