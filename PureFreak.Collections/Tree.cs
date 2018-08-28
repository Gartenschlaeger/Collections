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