using System;

namespace PureFreak.Collections
{
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

                return _tree.PathSeparator + _name;
            }
        }

        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }

        #endregion
    }
}