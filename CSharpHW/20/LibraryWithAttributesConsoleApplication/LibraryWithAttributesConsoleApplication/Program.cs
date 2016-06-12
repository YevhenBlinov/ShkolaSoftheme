namespace LibraryWithAttributesConsoleApplication
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
