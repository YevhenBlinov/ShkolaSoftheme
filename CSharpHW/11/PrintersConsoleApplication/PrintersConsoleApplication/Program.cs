using System;
using System.Drawing;

namespace PrintersConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringToDisplay = "Some information to display.";

            var printer = new Printer();
            Console.WriteLine("The printer prints information...");
            printer.Print(stringToDisplay);

            var colourPrinter = new ColourPrinter();
            Console.WriteLine("The colour printer prints information...");
            colourPrinter.Print(stringToDisplay, ConsoleColor.Yellow);

            var pathToImage = "C:\\Users\\eugen\\Documents\\ASPdotNET_logo.jpg";
            var image = new Bitmap(pathToImage);
            var photoPrinter = new PhotoPrinter();
            photoPrinter.Print(image);
        }
    }
}
