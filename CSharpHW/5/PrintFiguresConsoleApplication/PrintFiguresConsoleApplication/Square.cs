using System;

namespace PrintFiguresConsoleApplication
{
    public static class Square
    {
        public static void Draw(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("* ");
                }
                Console.Write(Environment.NewLine);
            }

            Console.Write(Environment.NewLine);
        }
    }
}
