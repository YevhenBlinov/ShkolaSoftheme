using System;

namespace CopyOfValueAndReferenceTypeApplication
{
    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }

        public User(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

    }
}
