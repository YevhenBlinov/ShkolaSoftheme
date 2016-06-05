using System;

namespace FindNumbersWhichOccureOddTimesInAnArray
{
    public static class NumberThatOccuresOddTimesInAnArrayFinder
    {
        public static void FindANumberThatOccuresOddTimes(this int[] array)
        {
            array.Sort();

            var count = 1;
            var number = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    count++;
                    if (i != array.Length - 1)
                        continue;

                    if (!IsCountAnEvenNumber(count))
                    {
                        DisplayANumberThatOccuresOddTimes(number, count);
                    }
                    else
                    {
                        Console.WriteLine("All numbers occure even times in array.");
                    }
                }
                else
                {
                    if (!IsCountAnEvenNumber(count))
                    {
                        DisplayANumberThatOccuresOddTimes(number, count);
                        break;
                    }
                    number = array[i];
                    count = 1;
                }
            }
        }

        private static bool IsCountAnEvenNumber(int count)
        {
            return count % 2 == 0;
        }

        private static void DisplayANumberThatOccuresOddTimes(int number, int count)
        {
            Console.WriteLine("Number {0} occures {1} times.", number, count);
        }
    }
}
