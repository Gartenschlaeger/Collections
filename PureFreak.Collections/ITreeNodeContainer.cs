namespace PureFreak.Collections
{
    public interface ITreeNodeContainer<T>
    {
        #region Methods

        #endregion

        #region Properties

        ITreeNodeCollection<T> Nodes { get; }

        #endregion
    }
}