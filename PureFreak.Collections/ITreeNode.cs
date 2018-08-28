namespace PureFreak.Collections
{
    public interface ITreeNode<T> : ITreeNodeContainer<T>
    {
        #region Methods

        ITreeNode<T> Create(string name);

        ITreeNode<T> Create(string name, T value);

        #endregion

        #region Properties

        string Name { get; set; }

        string FullName { get; }

        T Value { get; set; }

        ITree<T> Tree { get; }

        ITreeNode<T> Parent { get; }

        #endregion
    }
}