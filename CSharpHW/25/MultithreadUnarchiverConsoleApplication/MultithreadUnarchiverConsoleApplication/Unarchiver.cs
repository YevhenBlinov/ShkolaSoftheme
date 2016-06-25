using System.IO;
using System.IO.Compression;
using System.Threading;

namespace MultithreadUnarchiverConsoleApplication
{
    class Unarchiver
    {
        public void UnarchiveTheFolder(string pathToFolder)
        {
            var subDirectories = Directory.GetDirectories(pathToFolder);
            var files = Directory.GetFiles(pathToFolder);

            foreach (var file in files)
            {
                var fileExtension = Path.GetExtension(file);
                if(! string.Equals(fileExtension, ".zip"))
                    continue;

                var newThread = new Thread(UnarchiveTheFile);
                newThread.Start(file);
            }

            if (subDirectories.Length == 0)
                return;

            foreach (var subDirectory in subDirectories)
            {
                UnarchiveTheFolder(subDirectory);
            }
        }

        private void UnarchiveTheFile(object pathToFileObject)
        {
            var pathToFile = pathToFileObject as string;
            if (pathToFile == null)
                return;

            var currentDirectoryName = Directory.GetCurrentDirectory();
            var currentDirectory = new DirectoryInfo(currentDirectoryName);
            var directoryToExtract = Directory.CreateDirectory(currentDirectory + "\\" + "DirectoryToExtract");
            ZipFile.ExtractToDirectory(pathToFile, directoryToExtract.FullName);
        }
    }
}
