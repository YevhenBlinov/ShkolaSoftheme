using System;

namespace BottomUpMergeSortlmplementationConsoleApp
{
    public static class BottomUpMergeSort
    {
        public static void Sort(this int[] arrayToSort)
        {
            for (int i = 1; i < arrayToSort.Length; i = i * 2)
            {
                for (int j = 0; j < arrayToSort.Length; j = j + 2 * i)
                {
                    Merge(arrayToSort, j, Math.Min(j + i - 1, arrayToSort.Length - 1),
                          Math.Min(j + 2*i - 1, arrayToSort.Length - 1));
                }
            }
        }

        private static void Merge(int[] array, int left, int middle, int right)
        {
            var tempArray = new int[right + 1];

            for (int i = left; i <= middle; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = middle + 1; i <= right; i++)
            {
                tempArray[i] = array[right - i + middle + 1];
            }

            int leftShift = left, rightShift = right;

            for (int i = left; i <= right; i++)
            {
                array[i] = tempArray[rightShift] < tempArray[leftShift] 
                           ? tempArray[rightShift--]
                           : tempArray[leftShift++];
            }          
        }
    }
}
