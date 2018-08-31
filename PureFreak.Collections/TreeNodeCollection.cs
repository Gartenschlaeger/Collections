using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PureFreak.Collections
{
    /// <summary>
    /// Represents a collection of nodes.
    /// </summary>
    /// <typeparam name="T">Type of node values.</typeparam>
    [DebuggerDisplay("Count = {Count}")]
    public class TreeNodeCollection<T> : ITreeNodeCollection<T>
    {
        #region Fields

        private readonly Tree<T> _tree;
        private readonly TreeNode<T> _parent;
        private readonly Dictionary<string, ITreeNode<T>> _nodes;

        #endregion

        #region Constructor

        internal TreeNodeCollection(Tree<T> tree, TreeNode<T> parent)
        {
            if (tree == null)
                throw new ArgumentNullException(nameof(tree));

            _nodes = new Dictionary<string, ITreeNode<T>>();
            _tree = tree;
            _parent = parent;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new child node and adds it immediately to the node collection.
        /// </summary>
        /// <param name="name">Unique name of the node.</param>
        /// <returns>The created node.</returns>
        public ITreeNode<T> Create(string name)
        {
            return Create(name, default(T));
        }

        /// <summary>
        /// Creates a new child node and adds it immediately to the node collection.
        /// </summary>
        /// <param name="name">Unique name of the node.</param>
        /// <param name="value">Value of the node.</param>
        /// <returns>The created node.</returns>
        public ITreeNode<T> Create(string name, T value)
        {
            var node = new TreeNode<T>(_tree, _parent, name, value);
            _nodes.Add(name, node);

            return node;
        }

        /// <summary>
        /// Returns the node with the given name or null, if not found.
        /// </summary>
        /// <param name="name">Name if the node to search for.</param>
        /// <returns><see cref="ITreeNode{T}"/> or null if not found.</returns>
        public ITreeNode<T> Get(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (_nodes.TryGetValue(name, out ITreeNode<T> node))
                return node;

            return null;
        }

        /// <summary>
        /// Checks if a child node with given name exists.
        /// </summary>
        /// <param name="name">Name of the node to search for.</param>
        /// <returns>True if node with given name exists.</returns>
        public bool Contains(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return _nodes.ContainsKey(name);
        }

        /// <summary>
        /// Checks if the given node is added as child node.
        /// </summary>
        /// <param name="node">Node to search for.</param>
        /// <returns>True if the node exists.</returns>
        public bool Contains(ITreeNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            return _nodes.ContainsValue(node);
        }

        /// <summary>
        /// Removes the node with the given name from child nodes collection.
        /// </summary>
        /// <param name="name">Name of the node to be remove.</param>
        /// <returns>True if a node was found and removed.</returns>
        public bool Remove(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return _nodes.Remove(name);
        }

        /// <summary>
        /// Removes the given node from child nodes collection.
        /// </summary>
        /// <param name="node">Node to be remove.</param>
        /// <returns>True if the node was removed.</returns>
        public bool Remove(ITreeNode<T> node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes all child nodes.
        /// </summary>
        public void Clear()
        {
            _nodes.Clear();
        }

        /// <summary>
        /// Returns an instance of <see cref="IEnumerator"/> to iterate throw all child nodes.
        /// </summary>
        /// <returns>Instance of type <see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns an instance of <see cref="IEnumerator{T}"/> to iterate throw all child nodes.
        /// </summary>
        /// <returns>Instance of type <see cref="IEnumerator{T}"/>.</returns>
        public IEnumerator<ITreeNode<T>> GetEnumerator()
        {
            foreach (var node in _nodes)
            {
                yield return node.Value;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Contains the cound of child nodes.
        /// </summary>
        public int Count
        {
            get { return _nodes.Count; }
        }

        /// <summary>
        /// Returns the child node with given name or null, if not found.
        /// </summary>
        /// <param name="name">Name of the node to search for.</param>
        /// <returns><see cref="ITreeNode{T}"/> if found or null.</returns>
        public ITreeNode<T> this[string name]
        {
            get { return Get(name); }
        }

        #endregion
    }
}