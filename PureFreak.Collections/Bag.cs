using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PureFreak.Collections
{
    [DebuggerDisplay("Count = {_count}")]
    public class Bag<TValue> : ICollection<TValue>
    {
        #region Fields

        private TValue[] _buffer;
        private int _count;

        #endregion

        #region Constructor

        public Bag(int capacity = 100)
        {
            _buffer = new TValue[capacity];
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
                var newBuffer = new TValue[newCapacity];

                Array.Copy(oldBuffer, 0, newBuffer, 0, oldBuffer.Length);

                _buffer = newBuffer;
            }
        }

        #endregion

        #region Methods

        public void Add(TValue value)
        {
            EnsureCapacity(_count + 1);

            _buffer[_count] = value;
            _count++;
        }

        public void Set(int index, TValue value)
        {
            EnsureCapacity(index + 1);

            _buffer[index] = value;

            if (index + 1 > _count)
                _count = index + 1;
        }

        public TValue Get(int index)
        {
            if (index >= _count)
                return default(TValue);

            return _buffer[index];
        }

        public void Clear()
        {
            for (int i = 0; i < _count; i++)
            {
                _buffer[i] = default(TValue);
            }

            _count = 0;
        }

        public bool Contains(TValue value)
        {
            for (int index = _count - 1; index >= 0; index--)
            {
                if (value.Equals(_buffer[index]))
                    return true;
            }

            return false;
        }

        public bool Remove(TValue value)
        {
            for (int index = _count - 1; index >= 0; index--)
            {
                if (value.Equals(_buffer[index]))
                {
                    _buffer[index] = _buffer[_count - 1];
                    _buffer[_count - 1] = default(TValue);

                    _count--;

                    return true;
                }
            }

            return false;
        }

        public TValue RemoveLastElement()
        {
            if (_count > 0)
            {
                var result = _buffer[_count - 1];

                _buffer[_count - 1] = default(TValue);
                _count--;

                return result;
            }
            else
            {
                return default(TValue);
            }
        }

        public void CopyTo(TValue[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public TValue this[int index]
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