using System.Collections.Generic;
using System.Diagnostics;

namespace PureFreak.Collections
{
    [DebuggerDisplay("Nodes = {_nodes.Count}")]
    public class Tree<TKey, TValue>
    {
        #region Fields

        private char _nameSeparator;
        private readonly Dictionary<TKey, TreeNode<TKey, TValue>> _nodes;

        #endregion

        #region Constructor

        public Tree()
        {
            _nodes = new Dictionary<TKey, TreeNode<TKey, TValue>>();
            _nameSeparator = '/';
        }

        #endregion

        #region Methods

        protected virtual TreeNode<TKey, TValue> CreateNodeInternal(TreeNode<TKey, TValue> parent, TKey key, TValue value)
        {
            var node = new TreeNode<TKey, TValue>(this, parent, key, value);
            node._nameSeparator = _nameSeparator;

            _nodes.Add(key, node);

            return node;
        }

        public virtual TreeNode<TKey, TValue> Create(TKey key, TValue value)
        {
            return CreateNodeInternal(null, key, value);
        }

        public bool Remove(TKey key)
        {
            return _nodes.Remove(key);
        }

        public void Clear()
        {
            _nodes.Clear();
        }

        public TreeNode<TKey, TValue> Get(TKey key)
        {
            if (_nodes.TryGetValue(key, out TreeNode<TKey, TValue> node))
                return node;

            return default(TreeNode<TKey, TValue>);
        }

        public bool Contains(TKey key)
        {
            return _nodes.ContainsKey(key);
        }

        private IEnumerable<TreeNode<TKey, TValue>> GetNodes(TreeNode<TKey, TValue> node)
        {
            yield return node;

            foreach (var childNode in node.Nodes)
            {
                foreach (var childNodeChildNode in GetNodes(childNode))
                {
                    yield return childNodeChildNode;
                }
            }
        }

        private IEnumerable<TreeNode<TKey, TValue>> GetDescendants()
        {
            foreach (var node in _nodes.Values)
            {
                foreach (var childNode in GetNodes(node))
                {
                    yield return childNode;
                }
            }
        }

        public int Count
        {
            get { return _nodes.Count; }
        }

        #endregion

        #region Indexer

        public TreeNode<TKey, TValue> this[TKey key]
        {
            get { return Get(key); }
        }

        #endregion

        #region Properties

        public IEnumerable<TreeNode<TKey, TValue>> Nodes
        {
            get
            {
                foreach (var node in _nodes)
                {
                    yield return node.Value;
                }
            }
        }

        public IEnumerable<TreeNode<TKey, TValue>> Descendants
        {
            get { return GetDescendants(); }
        }

        public char Separator
        {
            get { return _nameSeparator; }
            set { _nameSeparator = value; }
        }

        #endregion
    }
}