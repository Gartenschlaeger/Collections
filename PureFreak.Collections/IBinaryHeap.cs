using System;

namespace PureFreak.Collections
{
    /// <summary>
    /// Represents a binary heap (a priority queue).
    /// </summary>
    /// <typeparam name="T">Type of values</typeparam>
    public interface IBinaryHeap<T>
    {
        #region Methods

        /// <summary>
        /// Adds a new item to the heap.
        /// </summary>
        /// <param name="item">Item to be add.</param>
        void Push(T item);

        /// <summary>
        /// Returns the top item from heap and removes it.
        /// </summary>
        /// <returns>Top item of the heap.</returns>
        T Pop();

        /// <summary>
        /// Returns the top item without removing it.
        /// </summary>
        /// <returns>Top item of the heap.</returns>
        T Peak();

        /// <summary>
        /// Checks if the heap contains the given item.
        /// </summary>
        /// <param name="item">Item to check for existence.</param>
        /// <returns>True if the item is added to the heap.</returns>
        bool Contains(T item);

        /// <summary>
        /// Tries to find a item by a custom filter.
        /// </summary>
        /// <param name="match">The delegate to match.</param>
        /// <returns>The item matched by given delegate or the default value.</returns>
        T Find(Func<T, bool> match);

        /// <summary>
        /// Returns an array containing all added items.
        /// </summary>
        /// <returns>Array containing all added items in internal order.</returns>
        T[] ToArray();

        #endregion

        #region Properties

        /// <summary>
        /// Returns the item ad the given index.
        /// </summary>
        /// <param name="index">Index of item to return.</param>
        /// <returns>Item at given index position.</returns>
        T this[int index] { get; }

        /// <summary>
        /// Contains the current capacity of the heap.
        /// </summary>
        int Capacity { get; }

        /// <summary>
        /// Contains the count of items added to the heap.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Contains the sort order.
        /// </summary>
        SortOrder SortOrder { get; }

        #endregion
    }
}