using System;

namespace SelectionSortConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayToSort = new[] { 9, 2, 6, 7, 1, 4, 8, 5, 0, 3 };
            Console.WriteLine("The unsorted array:");
            DisplayAnArray(arrayToSort);
            Console.WriteLine();

            arrayToSort.Sort();
            Console.WriteLine("The sorted array:");
            DisplayAnArray(arrayToSort);
            Console.WriteLine();
        }

        private static void DisplayAnArray(int[] array)
        {
            var count = 0;

            foreach (var element in array)
            {
                if (count == 4)
                {
                    Console.Write(element + Environment.NewLine);
                    count = 0;
                }
                else
                {
                    Console.Write(element + " ");
                    count++;
                }
            }
        }
    }
}
