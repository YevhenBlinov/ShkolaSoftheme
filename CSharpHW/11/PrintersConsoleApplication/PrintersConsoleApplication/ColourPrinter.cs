using System;

namespace PrintersConsoleApplication
{
    public sealed class ColourPrinter: Printer
    {
        public void Print(string stringToDisplay, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            base.Print(stringToDisplay);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
