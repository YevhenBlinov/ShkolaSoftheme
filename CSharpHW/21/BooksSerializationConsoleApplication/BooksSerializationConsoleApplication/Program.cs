using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace BooksSerializationConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var booksList = new List<Book>()
            {
                new Book("Harry Potter and the Philosopher's Stone", "J. K. Rowling", Genere.Fantasy, 1997, 415, 5, 10),
                new Book("Harry Potter and the Chamber of Secrets", "J. K. Rowling", Genere.Fantasy, 1998, 610, 6, 10),
                new Book("Harry Potter and the Prisoner of Azkaban", "J. K. Rowling", Genere.Fantasy, 1999, 625, 4, 8),
                new Book("Harry Potter and the Goblet of Fire", "J. K. Rowling", Genere.Fantasy, 2000, 650, 6, 10),
                new Book("Harry Potter and the Order of the Phoenix", "J. K. Rowling", Genere.Fantasy, 2003, 640, 6, 9),
                new Book("Harry Potter and the Half-Blood Prince", "J. K. Rowling", Genere.Fantasy, 2005, 690, 8, 3),
                new Book("Harry Potter and the Deathly Hallows", "J. K. Rowling", Genere.Fantasy, 2007, 780, 8, 3),
                new Book("The Lord of the Rings: The Fellowship of the Ring", "J. R. R. Tolkien", Genere.Fantasy, 1954, 980, 10, 3),
                new Book("The Sign of Four", "Arthur Conan Doyle", Genere.Detective, 1890, 189, 7, 4),
                new Book("A Study in Scarlet", "Arthur Conan Doyle", Genere.Detective, 1887, 108, 6, 5),
                new Book("Murder on the Orient Express", " Agatha Christie", Genere.Detective, 1934, 322, 7, 5),
                new Book("Misery", "Stephen King", Genere.Detective, 1987, 312, 7, 5),
                new Book("Fifty Shades of Grey", "E. L. James", Genere.Romance, 2011, 514, 1, 1)               
            };

            var stopWatch = new Stopwatch();

            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = new FileStream("books.dat", FileMode.OpenOrCreate))
            {
                stopWatch.Start();
                binaryFormatter.Serialize(fileStream, booksList);
                stopWatch.Stop();
            }

            var fileInfo = new FileInfo("books.dat");

            Console.WriteLine("The books list was serialized by BinaryFormatter.");
            Console.WriteLine("Total seconds elapsed : {0}", stopWatch.Elapsed);
            Console.WriteLine("The created file's size is {0} bytes.", fileInfo.Length);
            Console.WriteLine();

            stopWatch.Reset();

            var xmlSerializer = new XmlSerializer(typeof(List<Book>));
            using (var fileStream = new FileStream("books.xml", FileMode.OpenOrCreate))
            {
                stopWatch.Start();
                xmlSerializer.Serialize(fileStream, booksList);
                stopWatch.Stop();
            }

            fileInfo = new FileInfo("books.xml");

            Console.WriteLine("The books list was serialized by XmlSerializer.");
            Console.WriteLine("Total seconds elapsed : {0}", stopWatch.Elapsed);
            Console.WriteLine("The created file's size is {0} bytes.", fileInfo.Length);
            Console.WriteLine();

            stopWatch.Reset();

            var jsonSerializer = new DataContractJsonSerializer(typeof(List<Book>));
            using (var fileStream = new FileStream("books.json", FileMode.OpenOrCreate))
            {
                stopWatch.Start();
                jsonSerializer.WriteObject(fileStream, booksList);
                stopWatch.Stop();
            }

            fileInfo = new FileInfo("books.json");

            Console.WriteLine("The books list was serialized by DataContractJsonSerializer.");
            Console.WriteLine("Total seconds elapsed : {0}", stopWatch.Elapsed);
            Console.WriteLine("The created file's size is {0} bytes.", fileInfo.Length);
            Console.WriteLine();
        }
    }
}
