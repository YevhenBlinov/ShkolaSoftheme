﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSerializationLibraryConsoleApp
{
    public class Library
    {
        private const string PathToBooksFile = "Books.txt";
        private User _lastUser;

        public bool WantsToExit { get; private set; }

        public List<Book> BooksList { get; private set; }

        public HashSet<User> UsersHashSet { get; private set; }

        public List<Tuple<Book, User>> Journal { get; private set; }

        public Library()
        {
            FillBooksList();
            FillUsersHashSet();
            Journal = new List<Tuple<Book, User>>();
            WantsToExit = false;
        }

        private void FillBooksList()
        {
            BooksList = new List<Book>();

            try
            {
                using (var streamReader = new StreamReader(PathToBooksFile))
                {
                    var fileInfo = streamReader.ReadToEnd().Split(';');

                    for (int i = 0; i < fileInfo.Length - 1; i++)
                    {
                        var bookInfo = fileInfo[i].Split(',');
                        var bookToAdd = new Book(bookInfo[0].TrimStart('\r', '\n'),
                                                 bookInfo[1],
                                                 (Genere)Enum.Parse(typeof(Genere), bookInfo[2]),
                                                 int.Parse(bookInfo[3]),
                                                 int.Parse(bookInfo[4]),
                                                 int.Parse(bookInfo[5]),
                                                 int.Parse(bookInfo[6]));
                        BooksList.Add(bookToAdd);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                throw e;               
            }          
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
            Console.WriteLine("The library has {0} books.", BooksList.Count);
            var groupedBooksByGenre = BooksList.GroupBy(book => book.Genere);

            foreach (var group in groupedBooksByGenre)
            {
                Console.WriteLine("There are {0} in genere {1}", group.Count(), group.Key);

                foreach (var book in group)
                {
                    Console.WriteLine(book);
                }
            }

            var theNewestBookYearOfPublication = BooksList.Max(book => book.YearOfPublication);
            var theNewestBooks = BooksList.Where(book => book.YearOfPublication == theNewestBookYearOfPublication);
            Console.WriteLine("The newest books are:");

            foreach (var book in theNewestBooks)
            {
                Console.WriteLine(book);
            }

            var theOldestBookYearOfPublication = BooksList.Min(book => book.YearOfPublication);
            var theOldestBooks = BooksList.Where(book => book.YearOfPublication == theOldestBookYearOfPublication);
            Console.WriteLine("The oldest books are:");

            foreach (var book in theOldestBooks)
            {
                Console.WriteLine(book);
            }

            var theMostPopularBookIndex = BooksList.Max(book => book.PopularityIndex);
            var theMostPopularBooks = BooksList.Where(book => book.PopularityIndex == theMostPopularBookIndex);
            Console.WriteLine("The most popular books are:");

            foreach (var book in theMostPopularBooks)
            {
                Console.WriteLine(book);
            }

            var theMostUnPopularBookIndex = BooksList.Min(book => book.PopularityIndex);
            var theMostUnPopularBooks = BooksList.Where(book => book.PopularityIndex == theMostUnPopularBookIndex);
            Console.WriteLine("The most unpopular books are:");

            foreach (var book in theMostUnPopularBooks)
            {
                Console.WriteLine(book);
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
            var isAnyBookWithTheName = BooksList.Any(book => book.Name == name && book.Count > 0);

            if (isAnyBookWithTheName)
            {
                var findedBook = BooksList.Single(book => book.Name == name && book.Count > 0);
                Console.WriteLine(findedBook);
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
            var isAnyAuthorBook = BooksList.Any(book => book.Author == author && book.Count > 0);

            if (isAnyAuthorBook)
            {
                var findedBooks = BooksList.Where(book => book.Author == author && book.Count > 0);

                foreach (var findedBook in findedBooks)
                {
                    Console.WriteLine(findedBook);
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
            var isAnyAuthorBookWithTheName = BooksList.Any(book => book.Name == name && book.Author == author && book.Count > 0);

            if (isAnyAuthorBookWithTheName)
            {
                var findedBook = BooksList.Single(book => book.Name == name && book.Author == author && book.Count > 0);
                Console.WriteLine(findedBook);
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
            var groupedBooksByGenre = BooksList.GroupBy(book => book.Genere);

            foreach (var group in groupedBooksByGenre)
            {
                var theMostPopularBookIndex = group.Max(book => book.PopularityIndex);
                var theMostPopularBooks = BooksList.Where(book => book.PopularityIndex == theMostPopularBookIndex);
                Console.WriteLine("The most popular books in genre {0} are:", group.Key);

                foreach (var book in theMostPopularBooks)
                {
                    Console.WriteLine(book);
                }
            }

            Console.WriteLine("Please, press any key to continue...");
            Console.ReadLine();
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
                var isAnyAuthorBookWithTheName =
                    BooksList.Any(book => book.Name == name && book.Author == author && book.Count > 0);

                if (isAnyAuthorBookWithTheName)
                {
                    Console.WriteLine("Please, take your book.");
                    var bookIndex =
                        BooksList.FindIndex(book => book.Name == name && book.Author == author && book.Count > 0);
                    BooksList[bookIndex].Count--;

                    if (BooksList[bookIndex].PopularityIndex <= Book.MaxPopularityIndex)
                    {
                        BooksList[bookIndex].PopularityIndex++;
                    }

                    isBookFind = true;
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
            Console.WriteLine("Please, print the book's name.");
            var name = Console.ReadLine();
            Console.WriteLine("Please, print the book's author.");
            var author = Console.ReadLine();
            Console.WriteLine("Thank you for returning the book.");
            var bookIndex = BooksList.FindIndex(book => book.Name == name && book.Author == author);
            BooksList[bookIndex].Count++;
            Journal.Add(new Tuple<Book, User>(BooksList[bookIndex], _lastUser));

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

            var isAnyAuthorBookWithTheName = BooksList.Any(book => book.Name == name && book.Author == author);

            if (isAnyAuthorBookWithTheName)
            {
                var bookIndex = BooksList.FindIndex(book => book.Name == name && book.Author == author);
                BooksList[bookIndex].Count++;
                Console.WriteLine("Thank you for adding one more exemplar.");
            }
            else
            {
                var generes = Enum.GetNames(typeof (Genere));
                Console.WriteLine("Please, choose the book's genere.");
                for (int i = 0; i < generes.Length; i++)
                {
                    Console.WriteLine("{0} : {1}", (i+1), generes[i]);
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

                var newBook= new Book(name, author, genere, yearOfPublication, numberOfPages, 1, 1);
                BooksList.Add(newBook);
            }

            Console.WriteLine("Thank you for adding the book!");
            Console.WriteLine("Please, press any key to continue...");
            Console.ReadLine();
        }

        public void SaveCurrentStateOfTheLibrary()
        {
            var booksSerializationArray = new string[BooksList.Count+1];

            for (int i = 0; i < booksSerializationArray.Length - 1; i++)
            {
                if (i > 0)
                {
                    booksSerializationArray[i] = "\r\n";
                }

                booksSerializationArray[i] = BooksList[i].Name + "," +
                                             BooksList[i].Author + "," +
                                             ((int)BooksList[i].Genere) + "," +
                                             BooksList[i].YearOfPublication + "," +
                                             BooksList[i].NumberOfPages + "," +
                                             BooksList[i].PopularityIndex + "," + 
                                             BooksList[i].Count + ";" ;
            }

            booksSerializationArray[booksSerializationArray.Length-1] = String.Empty;

            try
            {
                File.WriteAllLines(PathToBooksFile, booksSerializationArray);
            }
            catch (FileNotFoundException e)
            {
                throw e;
            }
            
        }
    }
}
