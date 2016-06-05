using PrintersConsoleApplication;

namespace PrintersExtensionConsoleApplication
{
    public static class PrinterExtension
    {
        public static void Print(this Printer printer, string[] stringsToDisplay)
        {
            foreach (var stringToDisplay in stringsToDisplay)
            {
                printer.Print(stringToDisplay);
            }
        }
    }
}
