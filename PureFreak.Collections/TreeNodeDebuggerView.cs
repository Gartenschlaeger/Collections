using System;
using System.Diagnostics;
using System.Linq;

namespace PureFreak.Collections
{
    internal sealed class TreeNodeDebuggerView<T>
    {
        private readonly TreeNode<T> _node;

        public TreeNodeDebuggerView(TreeNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            _node = node;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public ITreeNode<T>[] Items
        {
            get { return _node.Nodes.ToArray(); }
        }
    }
}
