using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class MyStack<T> : IEnumerable<T>
    {
        public MyStack()
        {
            _head = -1;
            _values = new T[16];
        }

        private T[] _values;

        private int _head;

        public int Count => _head + 1;

        public T Peek()
        {
            if (_head == -1) 
                throw new InvalidOperationException("The stack is empty");
            
            return _values[_head];
        }

        public T Pop()
        {
            var returnValue = Peek();

            _values[_head] = default;
            _head--;

            return returnValue;
        }

        public void Push(T value)
        {
            if (value == null) 
                throw new ArgumentNullException(nameof(value));
            
            _head++;
            if (_head >= _values.Length) 
                Array.Resize(ref _values, _values.Length * 2);

            _values[_head] = value;
        }

        public void Clear()
        {
            _head = -1;
            _values = new T[16];
        }

        public T[] GetValues()
        {
            var returnValues = new T[_head + 1]; 
            for (var counter = 0; counter <= _head; counter++)
            {
                returnValues[counter] = _values[counter];
            }

            return returnValues;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeratorStack<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
