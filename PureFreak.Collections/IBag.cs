using System.Collections.Generic;

namespace PureFreak.Collections
{
    public interface IBag<T> : ICollection<T>
    {
        #region Methods

        void Set(int index, T value);

        T Get(int index);

        bool RemoveAt(int index);

        int FindIndex(T value);

        T[] ToArray();

        #endregion
    }
}