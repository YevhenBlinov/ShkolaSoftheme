using System;

namespace PrintersConsoleApplication
{
    public class Printer
    {
        public virtual void Print(string stringToDisplay)
        {            
            Console.WriteLine(stringToDisplay);
        }
    }
}
