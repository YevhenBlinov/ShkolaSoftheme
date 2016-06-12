using System.Collections.Generic;

namespace LibraryConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();
            var wantsToAuthorize = library.DoesUserWantToAuthorize();

            if (wantsToAuthorize)
            {
                library.AuthorizeAUser();
            }

            library.DisplayTheLibraryMenu();

        }

        
    }
}
