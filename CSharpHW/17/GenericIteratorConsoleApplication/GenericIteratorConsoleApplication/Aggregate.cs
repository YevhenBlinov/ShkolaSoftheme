namespace GenericIteratorConsoleApplication
{
    public abstract class Aggregate<T>
    {
        public abstract Iterator<T> CreateIterator();
    }
}