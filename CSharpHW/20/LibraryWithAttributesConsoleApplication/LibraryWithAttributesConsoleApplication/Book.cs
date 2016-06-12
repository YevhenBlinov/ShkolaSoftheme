using System.ComponentModel.DataAnnotations;

namespace LibraryWithAttributesConsoleApplication
{
    public class Book
    {
        public const int MinPopularityIndex = 1;
        public const int MaxPopularityIndex = 10;

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Name must have at least 1 symbol and 20 symbol max.")]
        public string Name { get; private set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Author must have at least 1 symbol and 20 symbol max.")]
        public string Author { get; private set; }

        [Required]
        public Genere Genere { get; private set; }

        [Required]
        [Range(1, 2016)]
        public int YearOfPublication { get; private set; }

        [Required]
        public int NumberOfPages { get; private set; }

        [Required]
        [Range(1, 10)]
        public int PopularityIndex { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Count { get; set; }

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
