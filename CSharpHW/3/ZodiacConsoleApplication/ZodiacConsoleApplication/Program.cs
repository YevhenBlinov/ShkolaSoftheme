using System;

namespace ZodiacConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, write your birth date in this way: DD/MM/YYYY");
            var birthdayCalculator = new BirthdayCalculator(Console.ReadLine());
            birthdayCalculator.DisplayAgeAndZodiacSign();
        }
    }
}
