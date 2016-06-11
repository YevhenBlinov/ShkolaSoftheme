using System;

namespace DoublyLinkedListConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var doublyLinkedList = new DoublyLinkedList<int>();

            doublyLinkedList.Add(1);
            doublyLinkedList.Add(3);
            doublyLinkedList.Add(5);
            doublyLinkedList.Add(7);
            doublyLinkedList.Display();

            doublyLinkedList.Contains(5);
            doublyLinkedList.Contains(4);

            doublyLinkedList.Delete(3);
            doublyLinkedList.Display();

            var returnedArray = doublyLinkedList.ToArray();
            foreach (var i in returnedArray)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            doublyLinkedList.Delete(1);
            doublyLinkedList.Display();
        }
    }
}
