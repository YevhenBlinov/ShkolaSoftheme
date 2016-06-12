namespace GenericIteratorConsoleApplication
{
    public class GenericIterator<T> : Iterator<T>
    {
        private GenericAggregate<T> _aggregate;
        private int _current;

        public GenericIterator(GenericAggregate<T> aggregate)
        {
            _aggregate = aggregate;
        }

        public override T First()
        {
            return _aggregate[0];
        }

        public override T Next()
        {
            T ret = default(T);

            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }

        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }

        public override T CurrentItem()
        {
            return _aggregate[_current];
        }
    }
}
