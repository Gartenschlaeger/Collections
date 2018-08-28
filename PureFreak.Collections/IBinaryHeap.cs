namespace PureFreak.Collections
{
    public interface IBinaryHeap<T>
    {
        #region Methods

        void Push(T item);

        T Pop();

        T Peak();

        bool Contains(T item);

        T[] ToArray();

        #endregion

        #region Properties

        T this[int index] { get; }

        int Capacity { get; }

        int Count { get; }

        #endregion
    }
}