using System;

namespace DoublyLinkedListConsoleApplication
{
    public class DoublyLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public int Count { get; private set; }

        public DoublyLinkedList()
        {
            _head = null;
            Count = 0;
        }

        public void Add(T nodeContent)
        {
            var node = new Node<T>(){NodeContent = nodeContent};

            if (_head == null)
            {
                _head = node;
                _tail = _head;
            }
            else
            {
                _tail.Next = node;
                _tail.Next.Previous = _tail;
                _tail = _tail.Next;
            }

            Count++;
        }

        public void Delete(int index)
        {
            if (index < 1 || index > Count)
            {
                Console.WriteLine("There is not a node with the index.");
                return;
            }

            if (index == 1)
            {
                _head = _head.Next;
                _head.Previous = null;
            }

            if (index == Count)
            {
                _tail = _tail.Previous;
                _tail.Next = null;
            }

            if (index > 1 && index < Count)
            {
                var temp = _head;

                for (int i = 1; i < index; i++)
                {
                    temp = temp.Next;
                }

                temp.Previous.Next = temp.Next;
                temp.Next.Previous = temp.Previous;
            }

            Count--;
        }

        public bool Contains(T content)
        {
            var temp = _head;

            for (int i = 0; i < Count; i++)
            {
                if (temp.NodeContent.Equals(content))
                {
                    Console.WriteLine("The doubly linked list contains {0} at {1} node.", content, i+1);
                    return true;
                }
                temp = temp.Next;
            }

            Console.WriteLine("The doubly linked list doesn't contain {0}.", content);
            return false;
        }

        public T[] ToArray()
        {
            var arrayToReturn = new T[Count];
            var temp = _head;

            for (int i = 0; i < Count; i++)
            {
                arrayToReturn[i] = temp.NodeContent;
                temp = temp.Next;
            }

            return arrayToReturn;
        }

        public void Display()
        {
            var temp = _head;

            for (int i = 0; i < Count; i++)
            {
                Console.Write(temp.NodeContent + " ");
                temp = temp.Next;
            }

            Console.WriteLine();
        }
    }
}
