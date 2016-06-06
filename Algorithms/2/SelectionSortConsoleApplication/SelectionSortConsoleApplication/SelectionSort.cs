namespace SelectionSortConsoleApplication
{
    public static class SelectionSort
    {
        public static void Sort(this int[] arrayToSort)
        {
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                var minElementIndex = i;

                for (int j = i; j < arrayToSort.Length; j++)
                {
                    if (arrayToSort[j] < arrayToSort[minElementIndex])
                    {
                        minElementIndex = j;
                    }
                }

                Swap(arrayToSort, i, minElementIndex);
            }
        }

        private static void Swap(int[] arrayToSort, int firstIndex, int secondIndex)
        {
            var temp = arrayToSort[firstIndex];
            arrayToSort[firstIndex] = arrayToSort[secondIndex];
            arrayToSort[secondIndex] = temp;
        }
    }
}
