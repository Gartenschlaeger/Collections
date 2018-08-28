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
        private bool[] _index;
        private int _count;

        #endregion

        #region Constructor

        public Bag(int capacity = 100)
        {
            _buffer = new T[capacity];
            _index = new bool[capacity];
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
                // resize buffer
                var oldBuffer = _buffer;
                var newBuffer = new T[newCapacity];

                Array.Copy(oldBuffer, 0, newBuffer, 0, oldBuffer.Length);

                _buffer = newBuffer;

                // resize index
                var oldIndex = _index;
                var newIndex = new bool[newCapacity];

                Array.Copy(oldIndex, 0, newIndex, 0, oldIndex.Length);

                _index = newIndex;
            }
        }

        #endregion

        #region Methods

        public void Add(T value)
        {
            EnsureCapacity(_count + 1);

            _index[_count] = true;
            _buffer[_count] = value;

            _count++;
        }

        public void Set(int index, T value)
        {
            EnsureCapacity(index + 1);

            if (!_index[index])
                _count++;

            _index[index] = true;
            _buffer[index] = value;
        }

        public T Get(int index)
        {
            if (index < _index.Length && _index[index])
                return _buffer[index];

            return default(T);
        }

        public void Clear()
        {
            for (int i = 0; i < _count; i++)
            {
                _index[i] = false;
                _buffer[i] = default(T);
            }

            _count = 0;
        }

        public bool Contains(T value)
        {
            return (FindIndex(value) != -1);
        }

        public int FindIndex(T value)
        {
            for (int i = 0; i < _index.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_buffer[i], value))
                    return i;
            }

            return -1;
        }

        public bool Remove(T value)
        {
            var index = FindIndex(value);
            if (index != -1)
                return RemoveAt(index);

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index < _index.Length && _index[index])
            {
                _index[index] = false;
                _buffer[index] = default(T);
                _count--;

                return true;
            }

            return false;
        }

        public T[] ToArray()
        {
            var result = new T[_count];

            if (_count > 0)
            {
                var ip = 0;
                for (int i = 0; i < _index.Length; i++)
                {
                    if (_index[i])
                        result[ip++] = _buffer[i];
                }
            }

            return result;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _index.Length; i++)
            {
                if (_index[i])
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