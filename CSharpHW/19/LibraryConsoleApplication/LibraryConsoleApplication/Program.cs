using System.Collections.Generic;

namespace LibraryConsoleApplication
{
    class Program
    {
        private static List<Book> _booksList;
        private static HashSet<User> _usersList;
        private static bool _wantsToAuthorize;
        private static User _lastUser;

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
