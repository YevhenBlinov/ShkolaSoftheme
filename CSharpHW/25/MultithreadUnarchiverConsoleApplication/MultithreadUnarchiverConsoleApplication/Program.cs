using System;
using System.IO;

namespace MultithreadUnarchiverConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var unarchiver = new Unarchiver();
            var isDerictoryExists = false;
            var pathToFolder = string.Empty;

            while (!isDerictoryExists)
            {
                Console.WriteLine("Please, enter a path to the folder, which will be archived.");
                var enteredPathToFolder = Console.ReadLine();

                if (!CheckIfFolderExists(enteredPathToFolder))
                {
                    Console.WriteLine("Sorry, but the folder doesn't exist. Please, try again.");
                }
                else
                {
                    isDerictoryExists = true;
                    pathToFolder = enteredPathToFolder;
                }
            }

            unarchiver.UnarchiveTheFolder(pathToFolder);
        }

        private static bool CheckIfFolderExists(string pathToFolder)
        {
            return Directory.Exists(pathToFolder);
        }
    }
}
