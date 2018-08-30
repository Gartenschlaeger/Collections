namespace PureFreak.Collections
{
    public interface ITreeNode<T> : ITreeNodeContainer<T>
    {
        #region Methods
        #endregion

        #region Properties

        string Name { get; set; }

        string FullName { get; }

        int Level { get; }

        T Value { get; set; }

        ITree<T> Tree { get; }

        ITreeNode<T> Parent { get; }

        #endregion
    }
}