using System;

namespace UserAndUserValidationInterfacesApp
{
    class User : IUser
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public User(string name, string password, string email)
        {
            Name = name;
            Password = password;
            Email = email;
        }

        public string GetFullInfo()
        {
            return String.Format("Name {0}; Email {1}", Name, Email);
        }
    }
}
