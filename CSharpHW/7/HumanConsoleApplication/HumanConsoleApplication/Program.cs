using System;

namespace HumanConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create first human...");
            var firstHuman = new Human(new DateTime(1993, 04, 28), "Yevhen", "Blinov", 23);
            Console.WriteLine("Created human with properties: First name " + firstHuman.FirstName + ", Last name " +
                              firstHuman.LastName + ", Birth date " + firstHuman.BirthDate + ", Age " + firstHuman.Age);
            Console.WriteLine("Create second human with unknown first and last names...");
            var secondHuman = new Human(new DateTime(1993, 04, 28), 23);
            Console.WriteLine("Created human with properties: First name " + secondHuman.FirstName + ", Last name " +
                              secondHuman.LastName + ", Birth date " + secondHuman.BirthDate + ", Age " + secondHuman.Age);
            Console.WriteLine("Create third human with default properties...");
            var thirdHuman = new Human();
            Console.WriteLine("Created human with properties: First name " + thirdHuman.FirstName + ", Last name " +
                              thirdHuman.LastName + ", Birth date " + thirdHuman.BirthDate + ", Age " + thirdHuman.Age);
            Console.WriteLine("Create forth human with same properties of first human...");
            var forthHuman = new Human(new DateTime(1993, 04, 28), "Yevhen", "Blinov", 23);
            Console.WriteLine("Created human with properties: First name " + forthHuman.FirstName + ", Last name " +
                              forthHuman.LastName + ", Birth date " + forthHuman.BirthDate + ", Age " + forthHuman.Age);
            Console.WriteLine();

            Console.WriteLine("Check if the first human equals to the second human");
            Console.WriteLine(firstHuman.Equals(secondHuman)
                              ? "The first human equals to the second human"
                              : "The first human doesn't equal to the second human");
            Console.WriteLine();

            Console.WriteLine("Check if the first human equals to the forth human");
            Console.WriteLine(firstHuman.Equals(forthHuman)
                              ? "The first human equals to the forth human"
                              : "The first human doesn't equal to the forth human");
        }
    }
}
