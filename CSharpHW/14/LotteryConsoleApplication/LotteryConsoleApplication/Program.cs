using System;

namespace LotteryConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var lotteryNumber = new LotteryNumber();

            Console.WriteLine("Please, enter 6 integer numbers in range from 1 to 9.");
            for (int i = 0; i < lotteryNumber.Length; i++)
            {
                int enteredNumber;

                if (!int.TryParse(Console.ReadLine(), out enteredNumber))
                {
                    Console.WriteLine("The number must be an integer. Please, try again.");
                    i--;
                    continue;
                }

                if (enteredNumber < 1 || enteredNumber > 9)
                {
                    Console.WriteLine("The number must be in range from 1 to 9. Please, try again.");
                    i--;
                    continue;
                }
                
                lotteryNumber[i] = enteredNumber;
            }

            var lotteryNumberChecker = new LotteryNumberChecker();
            lotteryNumberChecker.CheckTheEnteredNumbers(lotteryNumber);
        }
    }
}
