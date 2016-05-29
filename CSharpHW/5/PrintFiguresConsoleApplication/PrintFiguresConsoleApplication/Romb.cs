using System;

namespace PrintFiguresConsoleApplication
{
    public static class Romb
    {
        public static void Draw(int size)
        {
            var middle = size % 2 == 0 ? size / 2 : size / 2 + 1;
            var shift = 0;

            do
            {
                for (int j = 1; j <= size; j++)
                {

                    if (j >= middle - shift && j <= middle + shift)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                }

                shift++;
                Console.Write(Environment.NewLine);
            } while (shift != middle);

            shift = shift -2;

            do
            {
                for (int j = 1; j <= size; j++)
                {

                    if (j >= middle - shift && j <= middle + shift)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                }

                shift--;
                Console.Write(Environment.NewLine);
            } while (shift != -1);

            Console.Write(Environment.NewLine);
        }
    }
}
