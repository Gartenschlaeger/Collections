using System;
using System.Collections.Generic;

namespace PureFreak.Collections
{
    /// <summary>
    /// Represents a node collection container.
    /// </summary>
    /// <typeparam name="T">Type of node values.</typeparam>
    public interface ITreeNodeContainer<T>
    {
        #region Methods

        /// <summary>
        /// Creates a new child node and adds it immediately to the node collection.
        /// </summary>
        /// <param name="name">Unique name of the node.</param>
        /// <returns>The created node.</returns>
        ITreeNode<T> Create(string name);

        /// <summary>
        /// Creates a new child node and adds it immediately to the node collection.
        /// </summary>
        /// <param name="name">Unique name of the node.</param>
        /// <param name="value">Value of the node.</param>
        /// <returns>The created node.</returns>
        ITreeNode<T> Create(string name, T value);

        /// <summary>
        /// Returns the descendant nodes. 
        /// </summary>
        /// <returns>Descendant nodes</returns>
        IEnumerable<ITreeNode<T>> GetDescendantNodes();

        /// <summary>
        /// Returns the descendant nodes matching the given filter delegate. 
        /// </summary>
        /// <param name="filter">Filter delegate</param>
        /// <returns>Descendant nodes</returns>
        IEnumerable<ITreeNode<T>> GetDescendantNodes(Func<ITreeNode<T>, bool> filter);

        #endregion

        #region Properties

        /// <summary>
        /// Contains the list of child nodes for the current level.
        /// </summary>
        ITreeNodeCollection<T> Nodes { get; }

        /// <summary>
        /// Contains the count of added child nodes for the current level.
        /// </summary>
        int Count { get; }

        #endregion
    }
}