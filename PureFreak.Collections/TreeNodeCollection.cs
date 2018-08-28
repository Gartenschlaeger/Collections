using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PureFreak.Collections
{
    [DebuggerDisplay("Count = {Count}")]
    public class TreeNodeCollection<T> : ITreeNodeCollection<T>
    {
        #region Fields

        private readonly Tree<T> _tree;
        private readonly TreeNode<T> _parent;
        private readonly Dictionary<string, ITreeNode<T>> _nodes;

        #endregion

        #region Constructor

        public TreeNodeCollection(Tree<T> tree, TreeNode<T> parent)
        {
            if (tree == null)
                throw new ArgumentNullException(nameof(tree));

            _nodes = new Dictionary<string, ITreeNode<T>>();
            _tree = tree;
            _parent = parent;
        }

        #endregion

        #region Methods

        public ITreeNode<T> Create(string name)
        {
            return Create(name, default(T));
        }

        public ITreeNode<T> Create(string name, T value)
        {
            var node = new TreeNode<T>(_tree, _parent, name, value);
            _nodes.Add(name, node);

            return node;
        }

        public ITreeNode<T> Get(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (_nodes.TryGetValue(name, out ITreeNode<T> node))
                return node;

            return null;
        }

        public bool Contains(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return _nodes.ContainsKey(name);
        }

        public bool Contains(ITreeNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            return _nodes.ContainsValue(node);
        }

        public bool Remove(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return _nodes.Remove(name);
        }

        public bool Remove(ITreeNode<T> node)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            _nodes.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<ITreeNode<T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Properties

        public int Count
        {
            get { return _nodes.Count; }
        }

        public ITreeNode<T> this[string name]
        {
            get { return Get(name); }
        }

        #endregion
    }
}