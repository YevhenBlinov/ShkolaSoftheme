using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XMLLibraryConsoleApplication
{
    public class Library
    {
        private const string PathToBooksFile = "Books.xml";
        private User _lastUser;

        public bool WantsToExit { get; private set; }

        public List<Book> BooksList { get; private set; }

        public HashSet<User> UsersHashSet { get; private set; }



        public Library()
        {
            FillUsersHashSet();
            WantsToExit = false;
        }

        private void FillUsersHashSet()
        {
            UsersHashSet = new HashSet<User>()
            {
                new User("Yevhen", "1111"),
                new User("Katy", "22222"),
                new User("John", "12345")
            };
        }

        public bool DoesUserWantToAuthorize()
        {
            Console.WriteLine("Hello. Do you want to authorize? [y/n]");
            return GetAnAnswer();
        }

        public void AuthorizeAUser()
        {
            Console.Clear();
            Console.WriteLine("Please, type your login");
            var login = Console.ReadLine();
            Console.WriteLine("Please, type your password");
            var password = Console.ReadLine();
            var hasUserWithSameLoginAndPassword = UsersHashSet.Any(user => user.Login == login && user.Password == password);

            if (hasUserWithSameLoginAndPassword)
            {
                Console.WriteLine("Authorization is completed.");
                _lastUser = UsersHashSet.FirstOrDefault(user => user.Login == login && user.Password == password);
            }
            else
            {
                Console.WriteLine("Sorry, but login or password is wrong. Do you want to try again? [y/n]");

                if (GetAnAnswer())
                {
                    AuthorizeAUser();
                }
            }
        }

        private bool GetAnAnswer()
        {
            var isAnswerNormal = false;
            var answer = Console.ReadLine();
            isAnswerNormal = AnswerVerification(answer);

            while (!isAnswerNormal)
            {
                Console.WriteLine("Try one more time, please. You must type 'y' or 'n' as an answer.");
                answer = Console.ReadLine();
                isAnswerNormal = AnswerVerification(answer);
            }

            return answer == "Y" || answer == "y";
        }

        private bool AnswerVerification(string answer)
        {
            return answer == "Y" || answer == "y" || answer == "N" || answer == "n";
        }

        public void DisplayTheLibraryMenu()
        {
            Console.Clear();
            Console.WriteLine("Please, choose a needed information and type a number");
            Console.WriteLine("1. Get information about library");
            Console.WriteLine("2. Find a book");
            Console.WriteLine("3. Get information about the most popular book");

            if (_lastUser != null)
            {
                Console.WriteLine("4. Take a book");
                Console.WriteLine("5. Return a book");
                Console.WriteLine("6. Add a book");
            }

            Console.WriteLine("Please type \"exit\" to close the library application.");
            DoTheNeededOperation(Console.ReadLine());
        }

        private void DoTheNeededOperation(string operationNumber)
        {
            switch (operationNumber.ToLower())
            {
                case "1":
                    DisplayInformationAboutTheLibrary();
                    break;
                case "2":
                    FindABook();
                    break;
                case "3":
                    DisplayInformationAboutTheMostPopularBook();
                    break;
                case "4":
                    TakeABook();
                    break;
                case "5":
                    ReturnABook();
                    break;
                case "6":
                    AddABook();
                    break;
                case "exit":
                    WantsToExit = true;
                    break;
            }
        }
      
        private void DisplayInformationAboutTheLibrary()
        {
            Console.Clear();           

            var xDocument = XDocument.Load(PathToBooksFile);
            var root = xDocument.Element("ArrayOfBook");
            var booksList = root.Elements("Book").ToList();
            Console.WriteLine("The library has {0} books.", booksList.Count);

            foreach (var name in Enum.GetNames(typeof(Genere)))
            {
                Console.WriteLine("These are books in genere {0}", name);

                var booksInGenere = booksList.Where(xElement => xElement.Element("Genere").Value == name);
                foreach (var xElement in booksInGenere)
                {
                    DisplayInformationFromXElement(xElement);
                }
            }

            var theNewestBookYearOfPublication = booksList.Max(xElement => int.Parse(xElement.Element("YearOfPublication").Value));
            var theNewestBooks =
                booksList.Where(
                    xElement => int.Parse(xElement.Element("YearOfPublication").Value) == theNewestBookYearOfPublication);

            Console.WriteLine("The newest books are:");
            foreach (var xElement in theNewestBooks)
            {
                DisplayInformationFromXElement(xElement);
            }

            var theOldestBookYearOfPublication = booksList.Min(xElement => int.Parse(xElement.Element("YearOfPublication").Value));
            var theOldestBooks =
                booksList.Where(
                    xElement => int.Parse(xElement.Element("YearOfPublication").Value) == theOldestBookYearOfPublication);

            Console.WriteLine("The oldest books are:");
            foreach (var xElement in theOldestBooks)
            {
                DisplayInformationFromXElement(xElement);
            }

            var theMostPopularBookIndex = booksList.Max(xElement => int.Parse(xElement.Element("PopularityIndex").Value));
            var theMostPopularBooks = 
                booksList.Where(
                    xElement => int.Parse(xElement.Element("PopularityIndex").Value) == theMostPopularBookIndex);

            Console.WriteLine("The most popular books are:");
            foreach (var xElement in theMostPopularBooks)
            {
                DisplayInformationFromXElement(xElement);
            }

            var theMostUnPopularBookIndex = booksList.Min(xElement => int.Parse(xElement.Element("PopularityIndex").Value));
            var theMostUnPopularBooks =
                booksList.Where(
                    xElement => int.Parse(xElement.Element("PopularityIndex").Value) == theMostUnPopularBookIndex);

            Console.WriteLine("The most unpopular books are:");
            foreach (var xElement in theMostUnPopularBooks)
            {
                DisplayInformationFromXElement(xElement);
            }

            Console.WriteLine("Please, press any key to continue...");
            Console.ReadLine();
        }

        private void FindABook()
        {
            Console.Clear();
            Console.WriteLine("Please, choose in which way do you want to find a book and type a number");
            Console.WriteLine("1. By the name");
            Console.WriteLine("2. By the author");
            Console.WriteLine("3. By the name and the author");

            DoTheNeededFindOperation(Console.ReadLine());

        }

        private void DoTheNeededFindOperation(string operationNumber)
        {
            switch (operationNumber)
            {
                case "1":
                    FindBookByTheName();
                    break;
                case "2":
                    FindBooksByTheAuthor();
                    break;
                case "3":
                    FindTheBookByTheNameAndTheAuthor();
                    break;
            }
        }

        private void FindBookByTheName()
        {
            Console.Clear();
            Console.WriteLine("Please, print the book's name.");
            var name = Console.ReadLine();

            var xDocument = XDocument.Load(PathToBooksFile);
            var root = xDocument.Element("ArrayOfBook");
            var booksList = root.Elements("Book").ToList();

            var isAnyBookWithTheName =
                booksList.Any(
                    xElement => xElement.Element("Name").Value == name && int.Parse(xElement.Element("Count").Value) > 0);

            if (isAnyBookWithTheName)
            {
                var findedBook = booksList.Single(
                                     xElement => xElement.Element("Name").Value == name && int.Parse(xElement.Element("Count").Value) > 0);
                DisplayInformationFromXElement(findedBook);
            }
            else
            {
                Console.WriteLine("There isn't any book with the name.");
            }

            Console.WriteLine("Please, press any key to continue...");
            Console.ReadLine();
        }

        private void FindBooksByTheAuthor()
        {
            Console.Clear();
            Console.WriteLine("Please, print the book's author.");
            var author = Console.ReadLine();

            var xDocument = XDocument.Load(PathToBooksFile);
            var root = xDocument.Element("ArrayOfBook");
            var booksList = root.Elements("Book").ToList();

            var isAnyAuthorBook = booksList.Any(
                                        xElement => xElement.Element("Author").Value == author && int.Parse(xElement.Element("Count").Value) > 0);

            if (isAnyAuthorBook)
            {
                var findedBooks = booksList.Where(
                                        xElement => xElement.Element("Author").Value == author && int.Parse(xElement.Element("Count").Value) > 0);

                foreach (var findedBook in findedBooks)
                {
                    DisplayInformationFromXElement(findedBook);
                }
            }
            else
            {
                Console.WriteLine("There isn't any book of the author.");
            }

            Console.WriteLine("Please, press any key to continue...");
            Console.ReadLine();
        }

        private void FindTheBookByTheNameAndTheAuthor()
        {
            Console.Clear();
            Console.WriteLine("Please, print the book's name.");
            var name = Console.ReadLine();
            Console.WriteLine("Please, print the book's author.");
            var author = Console.ReadLine();

            var xDocument = XDocument.Load(PathToBooksFile);
            var root = xDocument.Element("ArrayOfBook");
            var booksList = root.Elements("Book").ToList();

            var isAnyAuthorBookWithTheName = booksList.Any(
                                                    xElement => xElement.Element("Author").Value == author &&
                                                    xElement.Element("Name").Value == name &&
                                                    int.Parse(xElement.Element("Count").Value) > 0);

            if (isAnyAuthorBookWithTheName)
            {
                var findedBook = booksList.Single(
                                        xElement => xElement.Element("Author").Value == author &&
                                                    xElement.Element("Name").Value == name &&
                                                    int.Parse(xElement.Element("Count").Value) > 0);
                DisplayInformationFromXElement(findedBook);
            }
            else
            {
                Console.WriteLine("There isn't any book with the name of the author.");
            }

            Console.WriteLine("Please, press any key to continue...");
            Console.ReadLine();
        }

        private void DisplayInformationAboutTheMostPopularBook()
        {
            Console.Clear();

            var xDocument = XDocument.Load(PathToBooksFile);
            var root = xDocument.Element("ArrayOfBook");
            var booksList = root.Elements("Book").ToList();
            Console.WriteLine("The library has {0} books.", booksList.Count);

            foreach (var name in Enum.GetNames(typeof(Genere)))
            {               
                var booksInGenere = booksList.Where(xElement => xElement.Element("Genere").Value == name);
                var theMostPopularBookIndex = booksInGenere.Max(xElement => int.Parse(xElement.Element("PopularityIndex").Value));
                var theMostPopularBooks =
                    booksInGenere.Where(
                        xElement => int.Parse(xElement.Element("PopularityIndex").Value) == theMostPopularBookIndex);

                Console.WriteLine("The most popular books in genre {0}", name);

                foreach (var xElement in theMostPopularBooks)
                {
                    DisplayInformationFromXElement(xElement);
                }
            }

            Console.WriteLine("Please, press any key to continue...");
            Console.ReadLine();
        }

        private void DisplayInformationFromXElement(XElement xElement)
        {
            var name = xElement.Element("Name").Value;
            var author = xElement.Element("Author").Value;
            var genere = xElement.Element("Genere").Value;
            var yearOfPublication = xElement.Element("YearOfPublication").Value;
            var numberOfPages = xElement.Element("NumberOfPages").Value;
            var popularityIndex = xElement.Element("PopularityIndex").Value;
            var count = xElement.Element("Count").Value;

            Console.WriteLine("Name: {0}, Author: {1}, Genere: {2}, YearOfPublication: {3}, Number of pages: {4}, Popularity index: {5}, Count: {6}",
                               name, author, genere, yearOfPublication, numberOfPages, popularityIndex, count);
        }

        private void TakeABook()
        {
            Console.Clear();
            var isBookFind = false;

            while (!isBookFind)
            {
                Console.WriteLine("Please, print the book's name.");
                var name = Console.ReadLine();
                Console.WriteLine("Please, print the book's author.");
                var author = Console.ReadLine();

                var xDocument = XDocument.Load(PathToBooksFile);
                var root = xDocument.Element("ArrayOfBook");
                var booksList = root.Elements("Book").ToList();

                var isAnyAuthorBookWithTheName = booksList.Any(
                                                        xElement => xElement.Element("Author").Value == author &&
                                                        xElement.Element("Name").Value == name &&
                                                        int.Parse(xElement.Element("Count").Value) > 0);

                if (isAnyAuthorBookWithTheName)
                {
                    Console.WriteLine("Please, take your book.");

                    var findedBook = booksList.First(
                                            xElement => xElement.Element("Author").Value == author &&
                                                        xElement.Element("Name").Value == name &&
                                                        int.Parse(xElement.Element("Count").Value) > 0);
                    findedBook.SetElementValue("Count", (int.Parse(findedBook.Element("Count").Value) - 1).ToString());


                    if (int.Parse(findedBook.Element("PopularityIndex").Value) < Book.MaxPopularityIndex)
                    {
                        findedBook.SetElementValue("PopularityIndex", (int.Parse(findedBook.Element("PopularityIndex").Value) + 1).ToString());
                    }

                    isBookFind = true;
                    xDocument.Save(PathToBooksFile);
                }
                else
                {
                    Console.WriteLine("There isn't any book with the name of the author. Please, try again.");
                }
            }

            Console.WriteLine("Please, press any key to continue...");
            Console.ReadLine();
        }

        private void ReturnABook()
        {
            Console.Clear();
            var isBookFind = false;

            while (!isBookFind)
            {
                Console.WriteLine("Please, print the book's name.");
                var name = Console.ReadLine();
                Console.WriteLine("Please, print the book's author.");
                var author = Console.ReadLine();

                var xDocument = XDocument.Load(PathToBooksFile);
                var root = xDocument.Element("ArrayOfBook");
                var booksList = root.Elements("Book").ToList();

                var isAnyAuthorBookWithTheName = booksList.Any(
                    xElement => xElement.Element("Author").Value == author &&
                                xElement.Element("Name").Value == name);

                if (isAnyAuthorBookWithTheName)
                {
                    Console.WriteLine("Thank you for returning the book.");

                    var findedBook = booksList.First(
                        xElement => xElement.Element("Author").Value == author &&
                                    xElement.Element("Name").Value == name);
                    findedBook.SetElementValue("Count", (int.Parse(findedBook.Element("Count").Value) + 1).ToString());

                    isBookFind = true;
                    xDocument.Save(PathToBooksFile);
                }
                else
                {
                    Console.WriteLine("There isn't any book with the name of the author. Please, try again.");
                }
            }

            Console.WriteLine("Please, press any key to continue...");
            Console.ReadLine();
        }

        private void AddABook()
        {
            Console.Clear();
            Console.WriteLine("Please, print the book's name.");
            var name = Console.ReadLine();
            Console.WriteLine("Please, print the book's author.");
            var author = Console.ReadLine();

            var xDocument = XDocument.Load(PathToBooksFile);
            var root = xDocument.Element("ArrayOfBook");
            var booksList = root.Elements("Book").ToList();

            var isAnyAuthorBookWithTheName = booksList.Any(
                xElement => xElement.Element("Author").Value == author &&
                            xElement.Element("Name").Value == name);

            if (isAnyAuthorBookWithTheName)
            {
                var findedBook = booksList.First(
                       xElement => xElement.Element("Author").Value == author &&
                                   xElement.Element("Name").Value == name &&
                                   int.Parse(xElement.Element("Count").Value) > 0);
                findedBook.SetElementValue("Count", (int.Parse(findedBook.Element("Count").Value) + 1).ToString());

                Console.WriteLine("Thank you for adding one more exemplar.");
            }
            else
            {
                var generes = Enum.GetNames(typeof(Genere));
                Console.WriteLine("Please, choose the book's genere.");
                for (int i = 0; i < generes.Length; i++)
                {
                    Console.WriteLine("{0} : {1}", (i + 1), generes[i]);
                }

                var genere = Genere.Detective;

                switch (Console.ReadLine())
                {
                    case "1":
                        genere = Genere.Fantasy;
                        break;
                    case "2":
                        genere = Genere.Detective;
                        break;
                    case "3":
                        genere = Genere.Romance;
                        break;
                }

                Console.WriteLine("Please, print the book's year of publication.");
                var yearOfPublication = int.Parse(Console.ReadLine());
                Console.WriteLine("Please, print the book's number of pages.");
                var numberOfPages = int.Parse(Console.ReadLine());

                root.Add(new XElement("Book", new XElement("Name", name), new XElement("Author", author),
                    new XElement("Genere", genere.ToString()), new XElement("YearOfPublication", yearOfPublication),
                    new XElement("NumberOfPages", numberOfPages), new XElement("PopularityIndex", 1.ToString()), 
                    new XElement("Count", 1.ToString())));
            }

            xDocument.Save(PathToBooksFile);
            Console.WriteLine("Thank you for adding the book!");
            Console.WriteLine("Please, press any key to continue...");
            Console.ReadLine();
        }              
    }
}
