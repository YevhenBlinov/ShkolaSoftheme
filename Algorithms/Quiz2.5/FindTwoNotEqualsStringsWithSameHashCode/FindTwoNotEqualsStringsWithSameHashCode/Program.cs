using System;
using System.Collections.Generic;

namespace FindTwoNotEqualsStringsWithSameHashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Find();
        }

        private static void Find()
        {
            var number = 0;
            var stringsDictionary = new Dictionary<int, string>();

            while (true)
            {
                number++;
                var numberInStringRepresentation = number.ToString();
                var numberInStringRepresentationHashCode = numberInStringRepresentation.GetHashCode();

                try
                {
                    stringsDictionary.Add(numberInStringRepresentationHashCode, numberInStringRepresentation);
                }
                catch (Exception)
                {
                   
                    Console.WriteLine("The string {0} has HashCode = {1} and the string {2} has the same HashCode = {3}", 
                                      stringsDictionary[numberInStringRepresentationHashCode], 
                                      stringsDictionary[numberInStringRepresentationHashCode].GetHashCode(), 
                                      numberInStringRepresentation, 
                                      numberInStringRepresentationHashCode);
                    break;
                }
            }
        }
    }
}
