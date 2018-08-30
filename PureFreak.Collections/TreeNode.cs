using System;
using System.Diagnostics;

namespace PureFreak.Collections
{
    /// <summary>
    /// Represents a node.
    /// </summary>
    /// <typeparam name="T">Type of the node value.</typeparam>
    [DebuggerDisplay("Count = {Count}")]
    public class TreeNode<T> : ITreeNode<T>
    {
        #region Fields

        private readonly Tree<T> _tree;
        private readonly TreeNode<T> _parent;

        private string _name;
        private T _value;

        private readonly TreeNodeCollection<T> _nodes;

        #endregion

        #region Constructor

        internal TreeNode(Tree<T> tree, TreeNode<T> parent, string name, T value)
        {
            if (tree == null)
                throw new ArgumentNullException(nameof(tree));
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Cannot be empty", nameof(name));

            _tree = tree;
            _parent = parent;
            _name = name;
            _value = value;
            _nodes = new TreeNodeCollection<T>(tree, this);
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
            return _nodes.Create(name);
        }

        /// <summary>
        /// Creates a new child node and adds it immediately to the node collection.
        /// </summary>
        /// <param name="name">Unique name of the node.</param>
        /// <param name="value">Value of the node.</param>
        /// <returns>The created node.</returns>
        public ITreeNode<T> Create(string name, T value)
        {
            return _nodes.Create(name, value);
        }

        #endregion

        #region Properties

        /// <summary>
        /// <see cref="ITree{T}"/> owner of the node.
        /// </summary>
        public ITree<T> Tree
        {
            get { return _tree; }
        }

        /// <summary>
        /// The parent node or null, if node is on root level.
        /// </summary>
        public ITreeNode<T> Parent
        {
            get { return _parent; }
        }

        /// <summary>
        /// Contains child nodes of the current node.
        /// </summary>
        public ITreeNodeCollection<T> Nodes
        {
            get { return _nodes; }
        }

        /// <summary>
        /// Name of the current node.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"Cannot be empty", nameof(Name));

                _name = value;
            }
        }

        /// <summary>
        /// Full name (path) of the current node.
        /// </summary>
        public string FullName
        {
            get
            {
                if (_parent != null)
                    return _parent.FullName + _tree.PathSeparator + _name;

                return _name;
            }
        }

        /// <summary>
        /// Level of the current node.
        /// </summary>
        public int Level
        {
            get
            {
                if (_parent != null)
                    return _parent.Level + 1;

                return 1;
            }
        }

        /// <summary>
        /// Value of the node.
        /// </summary>
        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// Count of child nodes for the current node.
        /// </summary>
        public int Count
        {
            get { return _nodes.Count; }
        }

        #endregion
    }
}