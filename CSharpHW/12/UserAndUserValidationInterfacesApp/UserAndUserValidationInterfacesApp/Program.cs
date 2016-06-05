using System;
using System.Collections.Generic;

namespace UserAndUserValidationInterfacesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>
            {
                new User("Yevhen", "qwerty", "yevhen.blinov@gmail.com"),
                new User("Valerii", "12345", "valerii@gmail.com")
            };
            while (true)
            {
                Console.WriteLine("Please, write your name.");
                var name = Console.ReadLine();
                Console.WriteLine("Please, write your email");
                var email = Console.ReadLine();
                Console.WriteLine("Please, write your password");
                var password = Console.ReadLine();

                if (name == "exit" && email == "exit" && password == "exit")
                {
                    break;
                }

                var isUserFounded = false;
                var indexOfTheUser = -1;
                for (int i = 0; i < users.Count; i++)
                {
                    if (name == users[i].Name && email == users[i].Email && password == users[i].Password)
                    {
                        isUserFounded = true;
                        indexOfTheUser = i;
                    }
                }

                if (isUserFounded)
                {
                    Console.WriteLine("How do you want to pass the validation?");
                    Console.WriteLine("1 By the name and the password;");
                    Console.WriteLine("2 By the email and the password");
                    var validationIndex = Console.ReadLine();
                    switch (validationIndex)
                    {
                        case "1":
                            var nameValidator = new NameAndPasswordValidator();
                            nameValidator.ValidateUser(users[indexOfTheUser], name, password);
                            break;
                        case "2":
                            var emailValidator = new EmailAndPasswordValidator();
                            emailValidator.ValidateUser(users[indexOfTheUser], email, password);
                            break;
                        default:
                            Console.WriteLine("Incorrect choossing of validation type!");
                            break;
                    }
                }
                else
                {
                    users.Add(new User(name, password, email));
                    Console.WriteLine("The user was added.");
                }
            }
            
        }
    }
}
