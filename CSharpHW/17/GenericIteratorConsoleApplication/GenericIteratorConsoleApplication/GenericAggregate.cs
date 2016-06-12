using System.Collections.Generic;

namespace GenericIteratorConsoleApplication
{
    public class GenericAggregate<T> : Aggregate<T>
    {
        private List<T> _items = new List<T>(); 
        public override Iterator<T> CreateIterator()
        {
            return new GenericIterator<T>(this);
        }

        public int Count 
        {
            get { return _items.Count; }
        }

        public T this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value);}
        }
    }
}
