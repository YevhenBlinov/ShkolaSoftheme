using System;

namespace UserAndUserValidationInterfacesApp
{
    public class EmailAndPasswordValidator : IValidator
    {
        public void ValidateUser(IUser user, string email, string password)
        {
            if (email == user.Email && password == user.Password)
            {
                Console.WriteLine("Last visit was on {0}", DateTime.Now.AddDays(-1));
            }
            else
            {
                Console.WriteLine("Email or password is wrong.");
            }
        }
    }
}
