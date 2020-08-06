using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class MyQueue<T> : IEnumerable<T>
    {
        public MyQueue()
        {
            _tail = -1;
            _values = new T[16];
        }

        private T[] _values;

        private int _tail;

        public int Count => _tail + 1;

        public T Peek()
        {
            if (_tail == -1) 
                throw new InvalidOperationException("The queue is empty");

            return _values[0];
        }

        public T Dequeue()
        {
            var returnValue = Peek();

            MoveAllLeft();
            _tail--;

            return returnValue;
        }

        public void Enqueue(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _tail++;
            if (_tail >= _values.Length)
                Array.Resize(ref _values, _values.Length * 2);

            _values[_tail] = value;
        }

        public void Clear()
        {
            _tail = -1;
            _values = new T[16];
        }

        public T[] GetValues()
        {
            var returnValues = new T[Count];
            for (var counter = 0; counter < Count; counter++)
            {
                returnValues[counter] = _values[counter];
            }

            return returnValues;
        }

        private void MoveAllLeft()
        {
            for (var i = 0; i < _tail; i++)
                _values[i] = _values[i + 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeratorQueue<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
