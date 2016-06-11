using System;
using System.Collections.Generic;

namespace QueueImplplementationConsoleApplication
{
    public class Queue<T>
    {
        private readonly List<T> _itemsList;

        public int Count 
        {
            get { return _itemsList.Count; }
        }

        public bool IsEmpty 
        {
            get { return _itemsList.Count == 0; }
        }

        public Queue()
        {
            _itemsList = new List<T>();
        }

        public void Enqueue(T itemToEnqueue)
        {
            _itemsList.Add(itemToEnqueue);
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new IndexOutOfRangeException("The queue is empty, so it's nothing to dequeue.");
            }

            var itemToDequeue = _itemsList[0];
            _itemsList.RemoveAt(0);
            return itemToDequeue;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new IndexOutOfRangeException("The queue is empty.");
            }

            return _itemsList[0];
        }

        public void Display()
        {
            Console.WriteLine("Queue has {0} items.", Count);

            for (int i = 0; i < _itemsList.Count; i++)
            {
                Console.WriteLine("Item {0} : {1}", (i+1), _itemsList[i]);
            }

            Console.WriteLine();
        }
    }
}
