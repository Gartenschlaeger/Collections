using System.Collections;
using System.Diagnostics;
using System.Text;

namespace PureFreak.Collections
{
    [DebuggerDisplay("Capacity = {_array.Length}")]
    public class BitSet
    {
        #region Fields

        private readonly BitArray _array;

        #endregion

        #region Constructor

        public BitSet(int capacity = 32)
        {
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

        public void Set(int index, bool value)
        {
            EnsureCapacity(index + 1);

            _array.Set(index, value);
        }

        public void SetAll(bool value)
        {
            _array.SetAll(value);
        }

        public bool IsSet(int index)
        {
            if (index < _array.Length)
                return _array.Get(index);

            return false;
        }

        public void Invert()
        {
            _array.Not();
        }

        #endregion

        #region Properties

        public int Capacity
        {
            get { return _array.Length; }
        }

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