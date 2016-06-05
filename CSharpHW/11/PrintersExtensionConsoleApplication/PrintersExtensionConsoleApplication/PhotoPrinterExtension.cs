using System.Drawing;
using PrintersConsoleApplication;

namespace PrintersExtensionConsoleApplication
{
    public static class PhotoPrinterExtension
    {
        public static void Print(this PhotoPrinter photoPrinter, Bitmap[] images)
        {
            foreach (var image in images)
            {
                photoPrinter.Print(image);
            }
        }
    }
}
