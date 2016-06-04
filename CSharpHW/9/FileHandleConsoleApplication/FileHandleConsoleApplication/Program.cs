using System;

namespace FileHandleConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            const string firstFile = "C:\\Users\\Yevhen\\ShkolaSoftheme\\CSharpHW\\FirstFile.txt";
            const string secondFile = "D:\\ShkolaSoftheme\\CSharpHW\\SecondFile.txt";
            const string thirdFile = "E:\\ShkolaSoftheme\\ThirdFile.txt";

            Console.WriteLine("Open a file by a path " + firstFile + " for reading...");
            var readFileHandle = OpenForRead(firstFile);
            Console.WriteLine(readFileHandle.FileName + " was opened for " + readFileHandle.FileAccessEnum +
                              ". Its size is " + readFileHandle.FileSize + " KB.");

            Console.WriteLine("Open a file by a path " + secondFile + " for writing...");
            var writeFileHandle = OpenForWrite(secondFile);
            Console.WriteLine(writeFileHandle.FileName + " was opened for " + writeFileHandle.FileAccessEnum +
                              ". Its size is " + writeFileHandle.FileSize + " KB.");

            Console.WriteLine("Open a file by a path " + thirdFile + " for reading and writing...");
            var readAndWriteFileHandle = OpenFile(thirdFile, FileAccessEnum.Read | FileAccessEnum.Write);
            Console.WriteLine(readAndWriteFileHandle.FileName + " was opened for " + readAndWriteFileHandle.FileAccessEnum +
                              ". Its size is " + readAndWriteFileHandle.FileSize + " KB.");
        }

        private static FileHandle OpenForRead(string filePath)
        {
            return new FileHandle(filePath, FileAccessEnum.Read);
        }

        private static FileHandle OpenForWrite(string filePath)
        {
            return new FileHandle(filePath, FileAccessEnum.Write);
        }

        private static FileHandle OpenFile(string filePath, FileAccessEnum fileAccess)
        {
            return new FileHandle(filePath, fileAccess);
        }
    }
}
