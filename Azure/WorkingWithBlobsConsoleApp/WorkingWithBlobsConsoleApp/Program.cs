namespace WorkingWithBlobsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var blobService = new BlobService();
            blobService.UploadBlobIntoContainer();
            blobService.DisplayBlobList();
            blobService.DownloadBlobFromContainer();
            //blobService.DeleteBlobFromContainer();
        }
    }
}
