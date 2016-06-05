using System;

namespace PrintersExtensionConsoleApplication
{
    public struct ColorString
    {
        public string StringToDisplay { get; private set; }
        public ConsoleColor Color { get; private set; }

        public ColorString(string stringToDisplay, ConsoleColor color)
            : this()
        {
            StringToDisplay = stringToDisplay;
            Color = color;
        }
    }
}
