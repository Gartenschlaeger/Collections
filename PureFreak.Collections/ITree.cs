namespace PureFreak.Collections
{
    public interface ITree<T> : ITreeNodeContainer<T>
    {
        #region Methods

        ITreeNode<T> Create(string name);

        ITreeNode<T> Create(string name, T value);

        #endregion

        #region Properties

        char PathSeparator { get; set; }

        #endregion
    }
}