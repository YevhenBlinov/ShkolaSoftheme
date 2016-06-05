using System;
using System.Collections.Generic;

namespace QueueImplementationUsingTwoStacks
{
    public class QueueUsingTwoStacks<T>
    {
        private Stack<T> _tailStack;
        private Stack<T> _headerStack;

        private bool IsEmpty 
        {
            get { return _tailStack.Count == 0 && _headerStack.Count == 0; }
        }

        public QueueUsingTwoStacks()
        {
            _tailStack = new Stack<T>();
            _headerStack= new Stack<T>();
        }

        public void Enqueue(T itemToEnqueue)
        {
            _tailStack.Push(itemToEnqueue);
        }

        public T Dequeue()
        {
            FillHeaderStackIfNeeded();
            return _headerStack.Pop();
        }

        public T Peek()
        {
            FillHeaderStackIfNeeded();
            return _headerStack.Peek();
        }

        private void FillHeaderStackIfNeeded()
        {
            if (_headerStack.Count == 0)
            {
                while (_tailStack.Count != 0)
                {
                    _headerStack.Push(_tailStack.Pop());
                }
            }
        }

        public void Display()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }

            foreach (var item in _tailStack)
            {
                Console.Write(item + " ");
            }

            foreach (var item in _headerStack)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
