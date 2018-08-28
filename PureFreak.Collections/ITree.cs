namespace PureFreak.Collections
{
    public interface ITree<T> : ITreeNodeContainer<T>
    {
        #region Methods

        #endregion

        #region Properties

        char PathSeparator { get; set; }

        #endregion
    }
}