using System;
using System.Collections;
using System.Diagnostics;
using System.Text;

namespace PureFreak.Collections
{
    /// <summary>
    /// Represents an dynamic array of bits.
    /// </summary>
    [DebuggerDisplay("Capacity = {Capacity}")]
    public class BitSet : IBitSet
    {
        #region Fields

        private readonly BitArray _array;

        #endregion

        #region Constructor

        /// <summary>
        /// Represents an dynamic array of bits.
        /// </summary>
        /// <param name="capacity">Initial capacity of the array.</param>
        public BitSet(int capacity = 32)
        {
            if (capacity < 1)
                throw new ArgumentOutOfRangeException("", "Must have a positive value.");

            _array = new BitArray(capacity);
        }

        #endregion

        #region Helper

        private void EnsureCapacity(int capacity)
        {
            var newLength = _array.Length;
            if (newLength < capacity)
                newLength *= 2;

            if (newLength > _array.Length)
                _array.Length = newLength;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the status of the given bit index.
        /// </summary>
        /// <param name="index">Index of bit to set.</param>
        /// <param name="status">Status of bit.</param>
        public void Set(int index, bool status)
        {
            EnsureCapacity(index + 1);

            _array.Set(index, status);
        }

        /// <summary>
        /// Sets all bits to the given status.
        /// </summary>
        /// <param name="status">Status to set.</param>
        public void SetAll(bool status)
        {
            _array.SetAll(status);
        }

        /// <summary>
        /// Checks if the bit at the given index is set.
        /// </summary>
        /// <param name="index">Index of the bit to check.</param>
        /// <returns>True if the bit is set.</returns>
        public bool IsSet(int index)
        {
            if (index < _array.Length)
                return _array.Get(index);

            return false;
        }

        /// <summary>
        /// Inverts the status of all bits. 
        /// True to False and False to True.
        /// </summary>
        public void Invert()
        {
            _array.Not();
        }

        /// <summary>
        /// Returns an boolean array representing the bit array.
        /// </summary>
        /// <returns>Array of boleans.</returns>
        public bool[] ToArray()
        {
            var result = new bool[_array.Length];
            for (int i = 0; i < _array.Length; i++)
            {
                result[i] = _array.Get(i);
            }

            return result;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The current capacity of the buffer.
        /// </summary>
        public int Capacity
        {
            get { return _array.Length; }
        }

        /// <summary>
        /// Returns an string representing the current binary representation of the bits.
        /// </summary>
        /// <returns>String representation of the current status of the bits.</returns>
        public override string ToString()
        {
            var buffer = new StringBuilder();
            for (int index = 0; index < _array.Length; index++)
            {
                if (_array.Get(index))
                    buffer.Append("1");
                else
                    buffer.Append("0");

                if (index + 1 < _array.Length && ((index + 1) % 8) == 0)
                    buffer.Append(" ");
            }

            return buffer.ToString();
        }

        #endregion
    }
}