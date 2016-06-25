using System.IO;
using System.IO.Compression;
using System.Threading;

namespace MultithreadUnarchiverConsoleApplication
{
    class Unarchiver
    {
        public void UnarchiveTheFolder(object pathToFolderObject)
        {
            var pathToFolder = pathToFolderObject as string;
            if(pathToFolder == null)
                return;

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
                var newThread = new Thread(UnarchiveTheFolder);
                newThread.Start(subDirectory);
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
