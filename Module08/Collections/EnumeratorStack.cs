using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class EnumeratorStack<T> : IEnumerator<T>
    {
        private readonly T[] _values;

        private int _position;

        public EnumeratorStack(MyStack<T> collection)
        {
            _values = new T[collection.Count];
            _values = collection.GetValues();
            _position = -1;
        }

        public bool MoveNext()
        {
            _position++;

            return _position < _values.Length;
        }

        public void Reset()
        {
            _position = 0;
        }

        public T Current => _values[_position];

        object? IEnumerator.Current => Current;

        public void Dispose() { }
    }
}
