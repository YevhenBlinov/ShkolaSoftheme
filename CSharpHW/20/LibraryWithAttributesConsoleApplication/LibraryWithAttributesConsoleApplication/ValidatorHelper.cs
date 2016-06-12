using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryWithAttributesConsoleApplication
{
    public class ValidatorHelper
    {
        public static bool ValidateUser(User user)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return false;
            }
            else
            {
                Console.WriteLine("User '{0}' is Valid", user.Login);
                return true;
            }
        }

        public static bool ValidateBook(Book book)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(book);
            if (!Validator.TryValidateObject(book, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return false;
            }
            else
            {
                Console.WriteLine("Book '{0}' is Valid", book.Name);
                return true;
            }
        }
    }
}
