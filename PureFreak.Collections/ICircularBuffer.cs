namespace PureFreak.Collections
{
    public interface ICircularBuffer<T>
    {
        #region Methods

        T Enqueue(T value);

        T Dequeue();

        void Clear();

        T[] ToArray();

        #endregion

        #region Properties

        int Count { get; }

        int Capacity { get; }

        #endregion
    }
}