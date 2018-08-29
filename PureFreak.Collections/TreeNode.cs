using System;
using System.Diagnostics;

namespace PureFreak.Collections
{
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

        public TreeNode(Tree<T> tree, TreeNode<T> parent, string name, T value)
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

        public ITreeNode<T> Create(string name)
        {
            return _nodes.Create(name);
        }

        public ITreeNode<T> Create(string name, T value)
        {
            return _nodes.Create(name, value);
        }

        #endregion

        #region Properties

        public ITree<T> Tree
        {
            get { return _tree; }
        }

        public ITreeNode<T> Parent
        {
            get { return _parent; }
        }

        public ITreeNodeCollection<T> Nodes
        {
            get { return _nodes; }
        }

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

        public string FullName
        {
            get
            {
                if (_parent != null)
                    return _parent.FullName + _tree.PathSeparator + _name;

                return _name;
            }
        }

        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public int Count
        {
            get { return _nodes.Count; }
        }

        #endregion
    }
}