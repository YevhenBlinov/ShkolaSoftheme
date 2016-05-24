using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintNameWithYelllowColor
{
    class Program
    {
        static void Main(string[] args)
        {
            var fullName = "Yevhen Blinov";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(fullName);
        }
    }
}
