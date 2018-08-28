namespace PureFreak.Collections
{
    public class Tree<T> : ITree<T>
    {
        #region Fields

        private char _pathSeparator;
        private readonly TreeNodeCollection<T> _nodes;

        #endregion

        #region Constructor

        public Tree()
        {
            _pathSeparator = '/';
            _nodes = new TreeNodeCollection<T>(this, null);
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

        public char PathSeparator
        {
            get { return _pathSeparator; }
            set { _pathSeparator = value; }
        }

        public ITreeNodeCollection<T> Nodes
        {
            get { return _nodes; }
        }

        #endregion
    }
}