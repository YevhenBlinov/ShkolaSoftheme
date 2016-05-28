using System;
using System.Collections.Generic;
using System.Linq;

namespace ZodiacWpfApplication
{
    public class BirthdayCalculator
    {
        private Dictionary<string, Tuple<DateTime, DateTime>> _zodiacSignsDictionary =
            new Dictionary<string, Tuple<DateTime, DateTime>>();
        private int _day;
        private int _month;
        private int _year;

        public int Age { get; private set; }
        public string ZodiacSignName { get; private set; }

        public BirthdayCalculator(int day, int month, int year)
        {
            _day = day;
            _month = month;
            _year = year;
            FillZodiacSignsDictionary();
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

        public void CalculateAgeAndZodiacSign()
        {
            Age = CalculateAge();
            ZodiacSignName = GetZodiacSign();
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
