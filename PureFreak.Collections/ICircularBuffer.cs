namespace PureFreak.Collections
{
    /// <summary>
    /// Represents a cirular buffer.
    /// </summary>
    /// <typeparam name="T">Typ of values.</typeparam>
    public interface ICircularBuffer<T>
    {
        #region Methods

        /// <summary>
        /// Adds a new value to the buffer.
        /// </summary>
        /// <param name="value">Value to be add.</param>
        /// <returns>The added value.</returns>
        T Enqueue(T value);

        /// <summary>
        /// Returns the next available value from buffer.
        /// </summary>
        /// <returns>The next available value.</returns>
        T Dequeue();

        /// <summary>
        /// Clears the buffer.
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns an array of all added values.
        /// </summary>
        /// <returns>Array containing the added values.</returns>
        T[] ToArray();

        #endregion

        #region Properties

        /// <summary>
        /// Count of added values.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Maximum values the buffer can have.
        /// </summary>
        int Capacity { get; }

        #endregion
    }
}