using PrintersConsoleApplication;

namespace PrintersExtensionConsoleApplication
{
    public static class ColourPrinterExtension
    {
        public static void Print(this ColourPrinter colorPrinter, ColorString[] colorStrings)
        {
            foreach (var colorString in colorStrings)
            {
                colorPrinter.Print(colorString.StringToDisplay, colorString.Color);
            }
        }
    }
}
