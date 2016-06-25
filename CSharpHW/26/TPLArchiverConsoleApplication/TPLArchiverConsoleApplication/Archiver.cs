using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace TPLArchiverConsoleApplication
{
    public class Archiver
    {
        public void ArchivateTheFolder(string pathToFolder)
        {
            var subDirectories = Directory.GetDirectories(pathToFolder);
            var files = Directory.GetFiles(pathToFolder);

            Parallel.ForEach(files, ArchivateTheFile);
 
            if (subDirectories.Length == 0) 
                return;

            Parallel.ForEach(subDirectories, ArchivateTheFolder);
        }

        private void ArchivateTheFile(string pathToFile)
        {
            var pathToFolder = Path.GetDirectoryName(pathToFile);
            var currentDirectoryName = Directory.GetCurrentDirectory();
            var currentDirectory = new DirectoryInfo(currentDirectoryName);
            var directoryWithFile = new DirectoryInfo(pathToFolder);            
            var fileToArchiveNameWithoutExtension = Path.GetFileNameWithoutExtension(pathToFile);
            var fileToArchiveFullName = Path.GetFileName(pathToFile);
            var directoryWithArchives = Directory.CreateDirectory(currentDirectory + "\\" + "DirectoryWithArchives");
            var createdSubDirectory = directoryWithFile.CreateSubdirectory(fileToArchiveNameWithoutExtension);
            File.Copy(pathToFile, createdSubDirectory.FullName + "\\" + fileToArchiveFullName);
            ZipFile.CreateFromDirectory(createdSubDirectory.FullName, directoryWithArchives.FullName + "\\" + fileToArchiveNameWithoutExtension + ".zip");
            DeleteCreatedSubDirectoryWithIncludedFile(createdSubDirectory.FullName, fileToArchiveFullName);
        }

        private void DeleteCreatedSubDirectoryWithIncludedFile(string pathToDirectory, string includedFileName)
        {
            File.Delete(pathToDirectory + "\\" + includedFileName);
            Directory.Delete(pathToDirectory);
        }
    }
}
