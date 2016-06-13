﻿using System;

namespace BooksSerializationConsoleApplication
{
    [Serializable]
    public class Book
    {
        public const int MinPopularityIndex = 1;
        public const int MaxPopularityIndex = 10;

        public string Name { get; set; }
        public string Author { get; set; }
        public Genere Genere { get; set; }
        public int YearOfPublication { get; set; }
        public int NumberOfPages { get; set; }
        public int PopularityIndex { get; set; }
        public int Count { get; set; }

        public Book()
        {
        }

        public Book(string name, string author, Genere genere, int yearOfPublication, int numberOfPages, int popularityIndex, int count)
        {
            Name = name;
            Author = author;
            Genere = genere;
            YearOfPublication = yearOfPublication;
            NumberOfPages = numberOfPages;
            PopularityIndex = popularityIndex;
            Count = count;
        }

        public override string ToString()
        {
            return string.Format(
                "Name: {0}, Author: {1}, Genere: {2}, YearOfPublication: {3}, Number of pages: {4}, Popularity index: {5}, Count: {6}",
                Name, Author, Genere, YearOfPublication, NumberOfPages, PopularityIndex, Count);
        }
    }
}
