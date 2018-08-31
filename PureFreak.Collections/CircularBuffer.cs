using System;
using System.Diagnostics;

namespace PureFreak.Collections
{
    /// <summary>
    /// Represents a cirular buffer.
    /// </summary>
    /// <typeparam name="T">Typ of values.</typeparam>
    [DebuggerDisplay("Count = {_count}")]
    [DebuggerTypeProxy(typeof(CircularBufferDebuggerView<>))]
    public class CircularBuffer<T> : ICircularBuffer<T>
    {
        #region Fields

        private readonly T[] _buffer;
        private int _writePos;
        private int _readPos;
        private int _count;

        #endregion

        #region Constructor

        /// <summary>
        /// Represents a circular buffer.
        /// </summary>
        /// <param name="capacity">Maximum values the buffer can have.</param>
        public CircularBuffer(int capacity = 100)
        {
            if (capacity < 1)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Must have a positive value.");

            _buffer = new T[capacity];

            _writePos = 0;
            _readPos = 0;
            _count = 0;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new value to the buffer.
        /// </summary>
        /// <param name="value">Value to be add.</param>
        /// <exception cref="OverflowException">Raises if the buffer is full.</exception>
        /// <returns>The added value.</returns>
        public T Enqueue(T value)
        {
            if (_count + 1 > _buffer.Length)
                throw new OverflowException();

            _buffer[_writePos] = value;

            _writePos = (_writePos + 1) % _buffer.Length;
            ++_count;

            return value;
        }

        /// <summary>
        /// Returns the next available value from buffer.
        /// </summary>
        /// <exception cref="InvalidOperationException">Raised if the buffer is empty.</exception>
        /// <returns>The next available value.</returns>
        public T Dequeue()
        {
            if (_count < 1)
                throw new InvalidOperationException("The buffer is empty.");

            var result = _buffer[_readPos];

            _readPos = (_readPos + 1) % _buffer.Length;
            --_count;

            return result;
        }

        /// <summary>
        /// Clears the buffer.
        /// </summary>
        public void Clear()
        {
            _writePos = 0;
            _readPos = 0;
            _count = 0;
        }

        /// <summary>
        /// Returns an array of all added values.
        /// </summary>
        /// <returns>Array containing the added values.</returns>
        public T[] ToArray()
        {
            if (_count == 0)
                return new T[0];

            var result = new T[_count];

            var rp = _readPos;
            for (int i = 0; i < _count; i++)
            {
                result[i] = _buffer[rp];
                rp = (rp + 1) % _buffer.Length;
            }

            return result;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Count of added values.
        /// </summary>
        public int Count
        {
            get { return _count; }
        }

        /// <summary>
        /// Maximum values the buffer can have.
        /// </summary>
        public int Capacity
        {
            get { return _buffer.Length; }
        }

        #endregion
    }
}