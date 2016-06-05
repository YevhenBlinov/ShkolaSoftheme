using System;
using System.Drawing;

namespace PrintersConsoleApplication
{
    public class PhotoPrinter: Printer
    {
        public void Print(Image image)
        {
            var stringToDisplay = String.Format("The image's size is {0}", image.Size);
            base.Print(stringToDisplay);
        }
    }
}
