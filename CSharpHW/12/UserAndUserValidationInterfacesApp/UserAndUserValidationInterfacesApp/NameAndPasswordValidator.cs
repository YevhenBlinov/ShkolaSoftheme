using System;

namespace UserAndUserValidationInterfacesApp
{
    public class NameAndPasswordValidator: IValidator
    {
        public void ValidateUser(IUser user, string name, string password)
        {
            if (name == user.Name && password == user.Password)
            {
                Console.WriteLine("Last visit was on {0}", DateTime.Now.AddDays(-1));
            }
            else
            {
                Console.WriteLine("Name or password is wrong.");
            }
        }
    }
}
