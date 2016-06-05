using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueImplementationUsingTwoStacks
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new QueueUsingTwoStacks<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine("Queue: ");
            queue.Display();
            Console.WriteLine("A peek element of the queue is {0}", queue.Peek());
            var item = queue.Dequeue();
            Console.WriteLine("The item {0} was removed from the queue.", item);
            Console.WriteLine("Queue: ");
            queue.Display();
            item = queue.Dequeue();
            Console.WriteLine("The item {0} was removed from the queue.", item);
            Console.WriteLine("Queue: ");
            queue.Display();
            item = queue.Dequeue();
            Console.WriteLine("The item {0} was removed from the queue.", item);
            Console.WriteLine("Queue: ");
            queue.Display();
            item = queue.Dequeue();
            Console.WriteLine("The item {0} was removed from the queue.", item);
            queue.Display();
        }
    }
}
