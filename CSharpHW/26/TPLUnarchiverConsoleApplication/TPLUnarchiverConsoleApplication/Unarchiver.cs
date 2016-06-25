using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace TPLUnarchiverConsoleApplication
{
    class Unarchiver
    {
        public void UnarchiveTheFolder(string pathToFolder)
        {
            var subDirectories = Directory.GetDirectories(pathToFolder);
            var files = Directory.GetFiles(pathToFolder);
            var zipFiles = files.Where(file => Path.GetExtension(file) == ".zip").ToList();

            if (zipFiles.Count != 0)
            {
                Parallel.ForEach(zipFiles, UnarchiveTheFile);
            }

            if (subDirectories.Length == 0)
                return;

            Parallel.ForEach(subDirectories, UnarchiveTheFolder);
        }

        private void UnarchiveTheFile(string pathToFile)
        {
            var currentDirectoryName = Directory.GetCurrentDirectory();
            var currentDirectory = new DirectoryInfo(currentDirectoryName);
            var directoryToExtract = Directory.CreateDirectory(currentDirectory + "\\" + "DirectoryToExtract");
            ZipFile.ExtractToDirectory(pathToFile, directoryToExtract.FullName);
        }
    }
}
