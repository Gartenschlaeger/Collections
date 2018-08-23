using System;
using System.Diagnostics;

namespace PureFreak.Collections
{
    [DebuggerDisplay("Nodes = {_nodes.Count}, FullName = {FullName}")]
    public class TreeNode<TKey, TValue> : Tree<TKey, TValue>
    {
        #region Fields

        private readonly Tree<TKey, TValue> _tree;
        private readonly TreeNode<TKey, TValue> _parent;
        private readonly TKey _key;
        private TValue _value;

        #endregion

        #region Constructor

        public TreeNode(Tree<TKey, TValue> tree, TKey key, TValue value)
            : this(tree, null, key, value)
        {
            _key = key;
        }

        public TreeNode(Tree<TKey, TValue> tree, TreeNode<TKey, TValue> parent, TKey key, TValue value)
        {
            if (tree == null)
                throw new ArgumentNullException(nameof(tree));

            _tree = tree;
            _parent = parent;
            _key = key;
            _value = value;
        }

        #endregion

        #region Methods

        public override TreeNode<TKey, TValue> Create(TKey key, TValue value)
        {
            return CreateNodeInternal(this, key, value);
        }

        #endregion

        #region Properties

        public TreeNode<TKey, TValue> Parent
        {
            get { return _parent; }
        }

        public TKey Key
        {
            get { return _key; }
        }

        public TValue Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Name
        {
            get { return _key.ToString(); }
        }

        public string FullName
        {
            get
            {
                if (_parent != null)
                    return _parent.FullName + _tree.Separator + Name;

                return Name;
            }
        }

        public int Level
        {
            get
            {
                if (_parent != null)
                    return _parent.Level + 1;

                return 1;
            }
        }

        public override string ToString()
        {
            return FullName;
        }

        #endregion
    }
}