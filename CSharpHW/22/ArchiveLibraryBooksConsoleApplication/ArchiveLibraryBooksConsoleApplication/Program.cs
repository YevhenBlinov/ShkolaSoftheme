using System;
using System.IO;

namespace ArchiveLibraryBooksConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var library = new Library();

                var wantsToAuthorize = library.DoesUserWantToAuthorize();

                if (wantsToAuthorize)
                {
                    library.AuthorizeAUser();
                }

                while (!library.WantsToExit)
                {
                    library.DisplayTheLibraryMenu();
                }

                library.SaveCurrentStateOfTheLibrary();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }                      
        }
    }
}
