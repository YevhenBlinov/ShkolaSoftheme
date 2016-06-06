namespace InsertionSortConsoleApplication
{
    public static class InsertionSort
    {
        public static void Sort(this int[] arrayToSort)
        {
            for (int i = 1; i < arrayToSort.Length; i++)
            {
                var currentNumber = arrayToSort[i];
                var j = i;

                while (j > 0 && arrayToSort[j - 1] > currentNumber)
                {
                    arrayToSort[j] = arrayToSort[j - 1];
                    j--;
                }

                arrayToSort[j] = currentNumber;
            }
        }
    }
}
