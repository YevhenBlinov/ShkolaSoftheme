using System;
using System.Collections.Generic;

namespace StackImplementationConsoleApplication
{
    public class Stack<T>
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

        public Stack()
        {
            _itemsList = new List<T>();
        }

        public void Push(T itemToPush)
        {
            _itemsList.Add(itemToPush);
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new IndexOutOfRangeException("The stack is empty, so it's nothing to pop.");
            }

            var itemToPop = _itemsList[_itemsList.Count - 1];
            _itemsList.RemoveAt(_itemsList.Count - 1);
            return itemToPop;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new IndexOutOfRangeException("The stack is empty.");
            }

            return _itemsList[_itemsList.Count - 1];
        }

        public void Display()
        {
            Console.WriteLine("Stack has {0} items.", Count);

            for (int i = _itemsList.Count - 1; i >= 0; i--)
            {
                Console.WriteLine("Item {0} : {1}", (i+1), _itemsList[i]);
            }

            Console.WriteLine();
        }
    }
}
