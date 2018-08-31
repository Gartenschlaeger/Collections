using System.Collections.Generic;

namespace PureFreak.Collections
{
    /// <summary>
    /// Represents a collection of nodes.
    /// </summary>
    /// <typeparam name="T">Type of node values.</typeparam>
    public interface ITreeNodeCollection<T> : IEnumerable<ITreeNode<T>>
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
        /// Removes the node with the given name from child nodes collection.
        /// </summary>
        /// <param name="name">Name of the node to be remove.</param>
        /// <returns>True if a node was found and removed.</returns>
        bool Remove(string name);

        /// <summary>
        /// Removes the given node from child nodes collection.
        /// </summary>
        /// <param name="node">Node to be remove.</param>
        /// <returns>True if the node was removed.</returns>
        bool Remove(ITreeNode<T> node);

        /// <summary>
        /// Returns the node with the given name or null, if not found.
        /// </summary>
        /// <param name="name">Name if the node to search for.</param>
        /// <returns><see cref="ITreeNode{T}"/> or null if not found.</returns>
        ITreeNode<T> Get(string name);

        /// <summary>
        /// Checks if a child node with given name exists.
        /// </summary>
        /// <param name="name">Name of the node to search for.</param>
        /// <returns>True if node with given name exists.</returns>
        bool Contains(string name);

        /// <summary>
        /// Checks if the given node is added as child node.
        /// </summary>
        /// <param name="node">Node to search for.</param>
        /// <returns>True if the node exists.</returns>
        bool Contains(ITreeNode<T> node);

        /// <summary>
        /// Removes all child nodes.
        /// </summary>
        void Clear();

        #endregion

        #region Properties

        /// <summary>
        /// Returns the child node with given name or null, if not found.
        /// </summary>
        /// <param name="name">Name of the node to search for.</param>
        /// <returns><see cref="ITreeNode{T}"/> if found or null.</returns>
        ITreeNode<T> this[string name] { get; }

        /// <summary>
        /// Contains the cound of child nodes.
        /// </summary>
        int Count { get; }

        #endregion
    }
}