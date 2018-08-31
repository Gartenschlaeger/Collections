using System;
using System.Diagnostics;
using System.Linq;

namespace PureFreak.Collections
{
    internal sealed class TreeDebuggerView<T>
    {
        private readonly Tree<T> _tree;

        public TreeDebuggerView(Tree<T> tree)
        {
            if (tree == null)
                throw new ArgumentNullException(nameof(tree));

            _tree = tree;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public ITreeNode<T>[] Items
        {
            get { return _tree.Nodes.ToArray(); }
        }
    }
}