using System;

namespace ArrayExtensionConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var myArray = new ExtendedArray(new[] {1, 2, 3, 4, 5});
            Console.WriteLine("Array of ints was created: ");
            myArray.Display();
            Console.WriteLine("Let's add 6, 7, 8, 9 to the array.");
            myArray.AddRange(6, 7, 8, 9);
            myArray.Display();
            Console.WriteLine();
            Console.WriteLine("Let's get a number from the array by index 3");
            var number = myArray.GetByIndex(3);
            Console.WriteLine("It's {0}", number);
            Console.WriteLine();
            Console.WriteLine("Let's check if the array contains a number 5");
            Console.WriteLine("Answer: {0}", myArray.Contains(5));
            Console.WriteLine();
            Console.WriteLine("Let's check if the array contains a number 10");
            Console.WriteLine("Answer: {0}", myArray.Contains(10));
            Console.WriteLine();
        }    
    }
}
