using System.Diagnostics;

namespace PureFreak.Collections
{
    /// <summary>
    /// Represents a tree with generic values.
    /// </summary>
    /// <typeparam name="T">Typ of node values.</typeparam>
    [DebuggerDisplay("Count = {Count}")]
    public class Tree<T> : ITree<T>
    {
        #region Fields

        private char _pathSeparator;
        private readonly TreeNodeCollection<T> _nodes;

        #endregion

        #region Constructor

        /// <summary>
        /// Represents a tree with generic values.
        /// </summary>
        public Tree()
        {
            _pathSeparator = '/';
            _nodes = new TreeNodeCollection<T>(this, null);
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
        /// Returns or sets the path separator character used for concatination the nodes <see cref="ITreeNode{T}.FullName"/>.
        /// </summary>
        public char PathSeparator
        {
            get { return _pathSeparator; }
            set { _pathSeparator = value; }
        }

        /// <summary>
        /// Contains the list of child nodes for the current level.
        /// </summary>
        public ITreeNodeCollection<T> Nodes
        {
            get { return _nodes; }
        }

        /// <summary>
        /// Contains the count of added child nodes for the current level.
        /// </summary>
        public int Count
        {
            get { return _nodes.Count; }
        }

        #endregion
    }
}