using System;

namespace QueueImplplementationConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();

            try
            {
                var dequeuedItem = queue.Dequeue();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            try
            {
                var peekItem = queue.Peek();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            for (int i = 0; i < 4; i++)
            {
                queue.Enqueue(i + 2);
            }
            queue.Display();

            for (int i = 0; i < 4; i++)
            {
                var dequeuedItem = queue.Dequeue();
                Console.WriteLine("Item {0} was dequeued from queue.", dequeuedItem);
                queue.Display();
            }
        }
    }
}
