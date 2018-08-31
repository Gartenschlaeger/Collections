using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PureFreak.Collections
{
    /// <summary>
    /// Represents a binary heap (a priority queue).
    /// </summary>
    /// <typeparam name="T">Type of values</typeparam>
    [DebuggerDisplay("Count = {_count}")]
    [DebuggerTypeProxy(typeof(BinaryHeapDebuggerView<>))]
    public sealed class BinaryHeap<T> : IBinaryHeap<T>
    {
        #region Consts

        private const int DefaultCapacity = 8;
        private const SortOrder DefaultSortOrder = SortOrder.Ascending;

        #endregion

        #region Fields

        private T[] _data;
        private int _count = 0;
        private IComparer<T> _comparer;
        private readonly SortOrder _sortOrder;

        #endregion

        #region Constructor

        /// <summary>
        /// Represents a binary heap (priority queue).
        /// </summary>
        /// <param name="capacity">Initial capacity of the heap.</param>
        /// <param name="sortOrder">Sorting direction</param>
        public BinaryHeap(int capacity = DefaultCapacity, SortOrder sortOrder = DefaultSortOrder)
        {
            _data = new T[capacity];
            _comparer = Comparer<T>.Default;
            _sortOrder = sortOrder;
        }

        /// <summary>
        /// Represents a binary heap (priority queue).
        /// </summary>
        /// <param name="comparer">Interface of type <see cref="IComparer{T}" /> for sorting of items.</param>
        /// <param name="capacity">Initial capacity of the heap.</param>
        /// <param name="sortOrder">Sorting direction</param>
        public BinaryHeap(IComparer<T> comparer, int capacity = DefaultCapacity, SortOrder sortOrder = DefaultSortOrder)
        {
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));

            _data = new T[capacity];
            _comparer = comparer;
            _sortOrder = SortOrder;
        }

        #endregion

        #region Helper

        private void IncreaseCapacity()
        {
            T[] resizedData = new T[_data.Length * 2];
            Array.Copy(_data, 0, resizedData, 0, _data.Length);

            _data = resizedData;
        }

        private int Compare(T a, T b)
        {
            var result = _comparer.Compare(a, b);
            if (_sortOrder == SortOrder.Descending)
                return -result;

            return result;
        }

        private void HeapifyUp(int childIdx)
        {
            if (childIdx > 0)
            {
                var parentIdx = (childIdx - 1) / 2;
                if (Compare(_data[childIdx], _data[parentIdx]) < 0)
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

            if (leftChildIdx < _count && Compare(_data[leftChildIdx], _data[largestChildIdx]) < 0)
            {
                largestChildIdx = leftChildIdx;
            }

            if (rightChildIdx < _count && Compare(_data[rightChildIdx], _data[largestChildIdx]) < 0)
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

        /// <summary>
        /// Adds a new item to the heap.
        /// </summary>
        /// <param name="item">Item to be add.</param>
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

        /// <summary>
        /// Returns the top item without removing it.
        /// </summary>
        /// <returns>Top item of the heap.</returns>
        public T Peak()
        {
            if (_count == 0)
                throw new InvalidOperationException("The heap is empty");

            return _data[0];
        }

        /// <summary>
        /// Returns the top item from heap and removes it.
        /// </summary>
        /// <returns>Top item of the heap.</returns>
        public T Pop()
        {
            if (_count == 0)
                throw new InvalidOperationException("The heap is empty");

            T item = _data[0];

            _count--;
            _data[0] = _data[_count];

            HeapifyDown(0);

            return item;
        }

        /// <summary>
        /// Checks if the heap contains the given item.
        /// </summary>
        /// <param name="item">Item to check for existence.</param>
        /// <returns>True if the item is added to the heap.</returns>
        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_comparer.Compare(_data[i], item) == 0)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Tries to find a item by a custom filter.
        /// </summary>
        /// <param name="match">The delegate to match.</param>
        /// <returns>The item matched by given delegate or the default value.</returns>
        public T Find(Func<T, bool> match)
        {
            for (int i = 0; i < _count; i++)
            {
                if (match(_data[i]))
                    return _data[i];
            }

            return default(T);
        }

        /// <summary>
        /// Returns an array containing all added items.
        /// </summary>
        /// <returns>Array containing all added items in internal order.</returns>
        public T[] ToArray()
        {
            T[] result = new T[_count];
            Array.Copy(_data, 0, result, 0, _count);

            return result;
        }

        /// <summary>
        /// Returns the item ad the given index.
        /// </summary>
        /// <param name="index">Index of item to return.</param>
        /// <returns>Item at given index position.</returns>
        public T this[int index]
        {
            get { return _data[index]; }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Contains the current capacity of the heap.
        /// </summary>
        public int Capacity
        {
            get { return _data.Length; }
        }

        /// <summary>
        /// Contains the count of items added to the heap.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Contains the sort order.
        /// </summary>
        public SortOrder SortOrder
        {
            get { return _sortOrder; }
        }

        #endregion
    }
}