using System;

namespace LotteryConsoleApplication
{
    public class LotteryNumberChecker
    {
        private Random _random;

        public LotteryNumberChecker()
        {
            _random = new Random();
        }

        public void CheckTheEnteredNumbers(LotteryNumber lotteryNumber)
        {
            var isAllNumbersGuessed = true;

            for (int i = 0; i < lotteryNumber.Length; i++)
            {
                if (_random.Next(1, 9) == lotteryNumber[i]) 
                    continue;
                Console.WriteLine("Sorry, but you didn't win.");
                isAllNumbersGuessed = false;
                break;
            }

            if (isAllNumbersGuessed)
            {
                Console.WriteLine("Congratulations! You won the prize!");
            }
        }
    }
}
