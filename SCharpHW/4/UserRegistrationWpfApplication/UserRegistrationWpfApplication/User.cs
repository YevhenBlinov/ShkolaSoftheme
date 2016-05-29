using System;

namespace UserRegistrationWpfApplication
{
    public class User
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender Gender { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string AdditionalInformation { get; private set; }

        public User(string firstName, string lastName, DateTime birthDate, Gender gender, string email, string phoneNumber, string additionalInfo)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            Email = email;
            PhoneNumber = phoneNumber;
            AdditionalInformation = additionalInfo;
        }
    }
}
