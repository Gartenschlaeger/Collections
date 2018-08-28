using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PureFreak.Collections
{
    [DebuggerDisplay("Count = {_count}")]
    public class Bag<T> : IBag<T>
    {
        #region Fields

        private T[] _buffer;
        private int _count;

        #endregion

        #region Constructor

        public Bag(int capacity = 100)
        {
            _buffer = new T[capacity];
            _count = 0;
        }

        #endregion

        #region Helper

        private void EnsureCapacity(int capacity)
        {
            var newCapacity = _buffer.Length;
            while (newCapacity < capacity)
                newCapacity *= 2;

            if (_buffer.Length != newCapacity)
            {
                var oldBuffer = _buffer;
                var newBuffer = new T[newCapacity];

                Array.Copy(oldBuffer, 0, newBuffer, 0, oldBuffer.Length);

                _buffer = newBuffer;
            }
        }

        #endregion

        #region Methods

        public void Add(T value)
        {
            EnsureCapacity(_count + 1);

            _buffer[_count] = value;
            _count++;
        }

        public void Set(int index, T value)
        {
            EnsureCapacity(index + 1);

            _buffer[index] = value;

            if (index + 1 > _count)
                _count = index + 1;
        }

        public T Get(int index)
        {
            if (index >= _count)
                return default(T);

            return _buffer[index];
        }

        public void Clear()
        {
            for (int i = 0; i < _count; i++)
            {
                _buffer[i] = default(T);
            }

            _count = 0;
        }

        public bool Contains(T value)
        {
            for (int index = _count - 1; index >= 0; index--)
            {
                if (value.Equals(_buffer[index]))
                    return true;
            }

            return false;
        }

        public bool Remove(T value)
        {
            for (int index = _count - 1; index >= 0; index--)
            {
                if (value.Equals(_buffer[index]))
                {
                    _buffer[index] = _buffer[_count - 1];
                    _buffer[_count - 1] = default(T);

                    _count--;

                    return true;
                }
            }

            return false;
        }

        public T RemoveLastElement()
        {
            if (_count > 0)
            {
                var result = _buffer[_count - 1];

                _buffer[_count - 1] = default(T);
                _count--;

                return result;
            }
            else
            {
                return default(T);
            }
        }

        public T[] ToArray()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                if (_buffer[i] == null)
                    continue;

                yield return _buffer[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get { return Get(index); }
            set { Set(index, value); }
        }

        #endregion

        #region Properties

        public int Count
        {
            get { return _count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion
    }
}