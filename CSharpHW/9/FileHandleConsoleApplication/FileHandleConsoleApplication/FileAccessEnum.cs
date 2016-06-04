using System;

namespace FileHandleConsoleApplication
{
    [Flags]
    public enum FileAccessEnum
    {
        Read = 0x1,
        Write = 0x2
    }
}
