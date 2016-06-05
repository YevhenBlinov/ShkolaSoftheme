using System;
using System.Linq;

namespace ArrayExtensionConsoleApplication
{
    public class ExtendedArray
    {
        private int[] _internalArray;

        public ExtendedArray(int[] array)
        {
            _internalArray = array;
        }

        public void AddRange(params int[] rangeOfInts)
        {
            var lengthOfAnOldArray = _internalArray.Length;
            var lenthOfParams = rangeOfInts.Length;
            var lengthOfANewArray = lengthOfAnOldArray + lenthOfParams;
            var newArray = new int[lengthOfANewArray];

            for (int i = 0; i < lengthOfAnOldArray; i++)
            {
                newArray[i] = _internalArray[i];
            }

            for (int i = lengthOfAnOldArray; i < lengthOfANewArray; i++)
            {
                newArray[i] = rangeOfInts[i - lengthOfAnOldArray];
            }

            _internalArray = newArray;
        }

        public int GetByIndex(int index)
        {
            return _internalArray[index];
        }

        public bool Contains(int number)
        {
            return _internalArray.Any(element => element == number);
        }

        public void Display()
        {
            var count = 0;

            foreach (var element in _internalArray)
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
            Console.WriteLine();
        }
    }
}
