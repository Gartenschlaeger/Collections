using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PureFreak.Collections
{
    /// <summary>
    /// Represents a bag.
    /// </summary>
    /// <typeparam name="T">Type of the values.</typeparam>
    [DebuggerDisplay("Count = {_count}")]
    public class Bag<T> : IBag<T>
    {
        #region Fields

        private T[] _buffer;
        private bool[] _index;
        private int _count;

        #endregion

        #region Constructor

        /// <summary>
        /// Represents a bag.
        /// </summary>
        /// <param name="capacity">Initial capacity of the buffer.</param>
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

        /// <summary>
        /// Added a new value.
        /// </summary>
        /// <param name="value">Value to be add.</param>
        public void Add(T value)
        {
            EnsureCapacity(_count + 1);

            _index[_count] = true;
            _buffer[_count] = value;

            _count++;
        }

        /// <summary>
        /// Sets the value at the given index.
        /// </summary>
        /// <param name="index">Index of item to change.</param>
        /// <param name="value">Value to be set.</param>
        public void Set(int index, T value)
        {
            EnsureCapacity(index + 1);

            if (!_index[index])
                _count++;

            _index[index] = true;
            _buffer[index] = value;
        }

        /// <summary>
        /// Returns the value at the given index.
        /// If the index is out of range the default value will be returned.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Item at given index or the default value.</returns>
        public T Get(int index)
        {
            if (index < _index.Length && _index[index])
                return _buffer[index];

            return default(T);
        }

        /// <summary>
        /// Removes all items.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < _count; i++)
            {
                _index[i] = false;
                _buffer[i] = default(T);
            }

            _count = 0;
        }

        /// <summary>
        /// Checks if the given value is present in the bag.
        /// </summary>
        /// <param name="value">Value to check for existence.</param>
        /// <returns>True if the value is present in the bag.</returns>
        public bool Contains(T value)
        {
            return (FindIndex(value) != -1);
        }

        /// <summary>
        /// Tries to find the index of the item value matching the given value.
        /// </summary>
        /// <param name="value">Value to search for.</param>
        /// <returns>True if a matching item has been found.</returns>
        public int FindIndex(T value)
        {
            for (int i = 0; i < _index.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(_buffer[i], value))
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Removes the item matching the given value.
        /// </summary>
        /// <param name="value">Value to match</param>
        /// <returns>True if the item has been removed.</returns>
        public bool Remove(T value)
        {
            var index = FindIndex(value);
            if (index != -1)
                return RemoveAt(index);

            return false;
        }

        /// <summary>
        /// Removes the item at the given index.
        /// </summary>
        /// <param name="index">Index of the item to be remove.</param>
        /// <returns>True if the item has been removed.</returns>
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

        /// <summary>
        /// Returns an array representing all items currently added to the bag.
        /// </summary>
        /// <returns>An array containing all added items.</returns>
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

        /// <summary>
        /// Copies the added items to the given array.
        /// </summary>
        /// <param name="array">Destination array to copy the items to.</param>
        /// <param name="arrayIndex">Start index in the destination array.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an instance of type <see cref="IEnumerator{T}"/> to iterare the items.
        /// </summary>
        /// <returns>Instance of type <see cref="IEnumerator{T}"/>.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _index.Length; i++)
            {
                if (_index[i])
                    yield return _buffer[i];
            }
        }

        /// <summary>
        /// Returns an instance of type <see cref="IEnumerator"/> to iterare the items.
        /// </summary>
        /// <returns>Instance of type <see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns the value at the given index.
        /// If the index is out of range the default value will be returned.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Item at given index or the default value.</returns>
        public T this[int index]
        {
            get { return Get(index); }
            set { Set(index, value); }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Contains the count of added items.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Returns True if the bag is in readonly mode.
        /// For <see cref="Bag{T}"/> the result is always False.
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion
    }
}