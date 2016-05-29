using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintFiguresConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangleSize = GetSize("triangle");
            var squareSize = GetSize("square");
            var rombSize = GetSize("romb");
            
            Triangle.Draw(triangleSize);
            Square.Draw(squareSize);            
            Romb.Draw(rombSize);
            
        }

        private static int GetSize(string shapeName)
        {
            var shapeSize = 0;

            while (true)
            {
                Console.WriteLine("Please, enter size for " + shapeName);
                if (int.TryParse(Console.ReadLine(), out shapeSize) && shapeSize > 0)
                {
                    Console.Write(Environment.NewLine);
                    break;
                }
                Console.WriteLine("Incorrect size value. Size must be positive integer.");
            }
            return shapeSize;
        }
    }
}
