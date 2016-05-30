using System;

namespace HumanConsoleApplication
{
    public class Human
    {
        private readonly int _age;

        public DateTime BirthDate { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age 
        {
            get { return _age; }
        }

        public Human(DateTime birthDate, int age)
                    : this(birthDate, "John", "Doe", age)
        {
        }

        public Human(DateTime birthDate, string firstName, string lastName, int age)
        {
            BirthDate = birthDate;
            FirstName = firstName;
            LastName = lastName;
            _age = age;
        }

        public Human()
        {
            BirthDate = default(DateTime);
            FirstName = default(string);
            LastName = default(string);
            _age = default(int);
        }

        public override bool Equals(object obj)
        {
            var anotherHuman = obj as Human;
            return FirstName.Equals(anotherHuman.FirstName) &&
                   LastName.Equals(anotherHuman.LastName) &&
                   BirthDate.Equals(anotherHuman.BirthDate) &&
                   Age == anotherHuman.Age;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode() + BirthDate.GetHashCode() + Age.GetHashCode();
        }
    }
}
