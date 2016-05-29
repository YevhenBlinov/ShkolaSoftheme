using System;

namespace PrintFiguresConsoleApplication
{
    public static class Triangle
    {
        public static void Draw(int size)
        {
            var countToPrint = 1;

            for (int i = 0; i < size; i++)
            {
                for (int j = 1; j <= countToPrint; j++)
                {
                    Console.Write("* ");
                }

                Console.Write(Environment.NewLine);
                countToPrint++;
            }

            Console.Write(Environment.NewLine);
        }
    }
}
