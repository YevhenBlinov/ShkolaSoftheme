using System;

namespace CopyOfValueAndReferenceTypeApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating an object type of int with value 1");
            var number = 1;
            Console.WriteLine("Trying to copy the object...");
            var anotherNumber = number;
            Console.WriteLine("Another object is {0}", anotherNumber);
            Console.WriteLine("Let's change the value of first object, another object must be still 1");
            number = 2;
            Console.WriteLine("First object has value {0}, and second one is {1}", number, anotherNumber);
            Console.WriteLine("It is well-copied!");
            Console.WriteLine("Creating an object of custom type User with values: first name Yevhen, last name Blinov, birth date 28.04.1993"); 
            var user = new User("Yevhen", "Blinov", new DateTime(1993, 04, 28));
            Console.WriteLine("Trying to copy it...");
            var anotherUser = user;
            Console.WriteLine("Another object has these parameters: first name {0}, last name {1}, birth date {2}",
                               anotherUser.FirstName, anotherUser.LastName, anotherUser.BirthDate);
            Console.WriteLine("Let's change the first name of first object, another object has to have first name Yevhen");
            user.FirstName = "Valerii";
            Console.WriteLine("First object's first name is {0}, and the another's one {1}", user.FirstName, anotherUser.FirstName);
            Console.WriteLine("They must be different! Another object refers to first object! We need to create a new object with first object's properties!");
            var secondAnotherUser = new User(user.FirstName, user.LastName, user.BirthDate);
            Console.WriteLine("Second another object has these parameters: first name {0}, last name {1}, birth date {2}",
                               secondAnotherUser.FirstName, secondAnotherUser.LastName, secondAnotherUser.BirthDate);
            Console.WriteLine("Let's change the first name of first object back to Yevhen, second another object has to have first name Valerii");
            user.FirstName = "Yevhen";
            Console.WriteLine("First object's first name is {0}, and the second's one {1}", user.FirstName, secondAnotherUser.FirstName);
            Console.WriteLine("Well done. It is well-copied");
        }
    }
}
