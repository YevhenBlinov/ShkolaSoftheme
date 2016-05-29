using System;
using System.Collections.Generic;
using System.Linq;

namespace ZodiacConsoleApplication
{
    public class BirthdayCalculator
    {
        private const int MinDay = 1;
        private const int MaxDay = 31;
        private const int MinMonth = 0;
        private const int MaxMonth = 12;
        private const int MinYear = 1;
        private const int DayAndMonthDigitsCount = 2;
        private const int YearDigitsCount = 4;

        private Dictionary<string, Tuple<DateTime, DateTime>> _zodiacSignsDictionary =
            new Dictionary<string, Tuple<DateTime, DateTime>>();
        private int _day;
        private int _month;
        private int _year;

        public BirthdayCalculator(string date)
        {
            SetBirthDate(date);
            FillZodiacSignsDictionary();
        }

        private void SetBirthDate(string date)
        {
            var birthDate = date.Split('/');

            int day = 0, month = 0, year = 0;
            if (birthDate.Length != 3 ||
                GetDigitsCount(birthDate[0]) != DayAndMonthDigitsCount ||
                !int.TryParse(birthDate[0], out day) ||
                GetDigitsCount(birthDate[1]) != DayAndMonthDigitsCount ||
                !int.TryParse(birthDate[1], out month) ||
                GetDigitsCount(birthDate[2]) != YearDigitsCount ||
                !int.TryParse(birthDate[2], out year) ||
                day < MinDay ||
                day > MaxDay || 
                month < MinMonth ||
                month > MaxMonth ||
                year < MinYear)
            {
                Console.WriteLine("Incorrect data format...Please, try again.");
                SetBirthDate(Console.ReadLine());
            }

            _day = day;
            _month = month;
            _year = year;
        }

        private static int GetDigitsCount(string number)
        {
            return number.Length;
        }

        private void FillZodiacSignsDictionary()
        {
            _zodiacSignsDictionary.Add("Aquarius", Tuple.Create(new DateTime(1, 1, 20), new DateTime(1, 2, 18)));
            _zodiacSignsDictionary.Add("Pisces", Tuple.Create(new DateTime(1, 2, 19), new DateTime(1, 3, 20)));
            _zodiacSignsDictionary.Add("Aries", Tuple.Create(new DateTime(1, 3, 21), new DateTime(1, 4, 19)));
            _zodiacSignsDictionary.Add("Taurus", Tuple.Create(new DateTime(1, 4, 20), new DateTime(1, 5, 20)));
            _zodiacSignsDictionary.Add("Gemini", Tuple.Create(new DateTime(1, 5, 21), new DateTime(1, 6, 20)));
            _zodiacSignsDictionary.Add("Cancer", Tuple.Create(new DateTime(1, 6, 21), new DateTime(1, 7, 22)));
            _zodiacSignsDictionary.Add("Leo", Tuple.Create(new DateTime(1, 7, 23), new DateTime(1, 8, 22)));
            _zodiacSignsDictionary.Add("Virgo", Tuple.Create(new DateTime(1, 8, 23), new DateTime(1, 9, 22)));
            _zodiacSignsDictionary.Add("Libra", Tuple.Create(new DateTime(1, 9, 23), new DateTime(1, 10, 22)));
            _zodiacSignsDictionary.Add("Scorpio", Tuple.Create(new DateTime(1, 10, 23), new DateTime(1, 11, 21)));
            _zodiacSignsDictionary.Add("Saggitarius", Tuple.Create(new DateTime(1, 11, 22), new DateTime(1, 12, 21)));
            _zodiacSignsDictionary.Add("Capricorn", Tuple.Create(new DateTime(1, 12, 22), new DateTime(2, 1, 19)));
        }

        public void DisplayAgeAndZodiacSign()
        {
            var age = CalculateAge();
            var zodiacSign = GetZodiacSign();
            Console.WriteLine("You're {0} years old. Your zodiac sign is {1}", age, zodiacSign);
        }

        private int CalculateAge()
        {
            return DateTime.Now.Year - _year;
        }

        private string GetZodiacSign()
        {
            var date = (_month == 1 && _day <= 19) ? new DateTime(2, _month, _day) : new DateTime(1, _month, _day);
            var sign = _zodiacSignsDictionary.Single(zodiacSign => date >= zodiacSign.Value.Item1 && date <= zodiacSign.Value.Item2);
            return sign.Key;
        }

    }
}
