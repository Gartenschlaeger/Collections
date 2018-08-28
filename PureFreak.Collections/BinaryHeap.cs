using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PureFreak.Collections
{
    [DebuggerDisplay("Count = {_count}")]
    public sealed class BinaryHeap<T> : IBinaryHeap<T>
    {
        #region Consts

        private const int DefaultCapacity = 8;

        #endregion

        #region Fields

        private T[] _data;
        private int _count = 0;
        private IComparer<T> _comparer;

        #endregion

        #region Constructor

        public BinaryHeap(int capacity = DefaultCapacity)
        {
            _data = new T[capacity];
            _comparer = Comparer<T>.Default;
        }

        public BinaryHeap(IComparer<T> comparer, int capacity = DefaultCapacity)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            _data = new T[capacity];
            _comparer = comparer;
        }

        #endregion

        #region Helper

        private void IncreaseCapacity()
        {
            T[] resizedData = new T[_data.Length * 2];
            Array.Copy(_data, 0, resizedData, 0, _data.Length);

            _data = resizedData;
        }

        private void HeapifyUp(int childIdx)
        {
            if (childIdx > 0)
            {
                int parentIdx = (childIdx - 1) / 2;
                if (_comparer.Compare(_data[childIdx], _data[parentIdx]) > 0)
                {
                    // swap parent and child
                    T tmp = _data[parentIdx];
                    _data[parentIdx] = _data[childIdx];
                    _data[childIdx] = tmp;

                    HeapifyUp(parentIdx);
                }
            }
        }

        private void HeapifyDown(int parentIdx)
        {
            int leftChildIdx = 2 * parentIdx + 1;
            int rightChildIdx = leftChildIdx + 1;
            int largestChildIdx = parentIdx;

            if (leftChildIdx < _count && _comparer.Compare(_data[leftChildIdx], _data[largestChildIdx]) > 0)
            {
                largestChildIdx = leftChildIdx;
            }

            if (rightChildIdx < _count && _comparer.Compare(_data[rightChildIdx], _data[largestChildIdx]) > 0)
            {
                largestChildIdx = rightChildIdx;
            }

            if (largestChildIdx != parentIdx)
            {
                T tmp = _data[parentIdx];
                _data[parentIdx] = _data[largestChildIdx];
                _data[largestChildIdx] = tmp;

                HeapifyDown(largestChildIdx);
            }
        }

        #endregion

        #region Methods

        public void Push(T item)
        {
            if (_count == _data.Length)
            {
                IncreaseCapacity();
            }

            _data[_count] = item;

            HeapifyUp(_count);

            _count++;
        }

        public T Peak()
        {
            return _data[0];
        }

        public T Pop()
        {
            T item = _data[0];

            _count--;
            _data[0] = _data[_count];

            HeapifyDown(0);

            return item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_comparer.Compare(_data[i], item) == 0)
                    return true;
            }

            return false;
        }

        public T Find(Func<T, bool> match)
        {
            for (int i = 0; i < _count; i++)
            {
                if (match(_data[i]))
                    return _data[i];
            }

            return default(T);
        }

        public T[] ToArray()
        {
            T[] result = new T[_count];
            Array.Copy(_data, 0, result, 0, _count);

            return result;
        }

        public T this[int index]
        {
            get { return _data[index]; }
        }

        #endregion

        #region Properties

        public int Capacity
        {
            get { return _data.Length; }
        }

        public int Count
        {
            get { return _count; }
        }

        #endregion
    }
}