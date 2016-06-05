using System;
using System.Drawing;
using PrintersConsoleApplication;

namespace PrintersExtensionConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringsToDisplay = new [] {"Some information to display", "Another information to display"};
            Console.WriteLine("The printer prints information...");
            var printer = new Printer();
            printer.Print(stringsToDisplay);
            Console.WriteLine();

            var colorStrings = new ColorString[]
            {
                new ColorString("Some information to display", ConsoleColor.Yellow),
                new ColorString("Another information to display", ConsoleColor.Red)
            };
            Console.WriteLine("The colour printer prints information...");
            var colorPrinter = new ColourPrinter();
            colorPrinter.Print(colorStrings);
            Console.WriteLine();

            var images = new Bitmap[]
            {
                new Bitmap("C:\\Users\\eugen\\Documents\\ASPdotNET_logo.jpg"),
                new Bitmap("C:\\Users\\eugen\\Documents\\VeriSignLogo.jpg")
            };
            Console.WriteLine("The photo printer prints information...");
            var photoPrinter = new PhotoPrinter();
            photoPrinter.Print(images);
            Console.WriteLine();
        }
    }
}
