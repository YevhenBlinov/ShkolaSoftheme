namespace QuickSortImplementationConsoleApplication
{
    public static class QuickSort
    {
        public static void Sort(this int[] arrayToSort, int left, int right)
        {
            if(left >= right)
                return;

            var middle = left;

            for (int i = left + 1; i <= right; i++)
            {
                if (arrayToSort[i] < arrayToSort[left])
                {
                    Swap(arrayToSort, ++middle, i);
                }
            }

            Swap(arrayToSort, left, middle);
            arrayToSort.Sort(left, middle - 1);
            arrayToSort.Sort(middle + 1, right);
        }

        private static void Swap(int[] array, int firstIndex, int secondIndex)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}
