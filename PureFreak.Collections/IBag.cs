using System.Collections.Generic;

namespace PureFreak.Collections
{
    /// <summary>
    /// Represents a bag.
    /// </summary>
    /// <typeparam name="T">Type of the values.</typeparam>
    public interface IBag<T> : ICollection<T>
    {
        #region Methods

        /// <summary>
        /// Sets the value at the given index.
        /// </summary>
        /// <param name="index">Index of item to change.</param>
        /// <param name="value">Value to be set.</param>
        void Set(int index, T value);

        /// <summary>
        /// Returns the value at the given index.
        /// If the index is out of range the default value will be returned.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Item at given index or the default value.</returns>
        T Get(int index);

        /// <summary>
        /// Removes the item at the given index.
        /// </summary>
        /// <param name="index">Index of the item to be remove.</param>
        /// <returns>True if the item has been removed.</returns>
        bool RemoveAt(int index);

        /// <summary>
        /// Tries to find the index of the item value matching the given value.
        /// </summary>
        /// <param name="value">Value to search for.</param>
        /// <returns>True if a matching item has been found.</returns>
        int FindIndex(T value);

        /// <summary>
        /// Returns an array representing all items currently added to the bag.
        /// </summary>
        /// <returns>An array containing all added items.</returns>
        T[] ToArray();

        #endregion
    }
}