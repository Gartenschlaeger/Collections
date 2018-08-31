namespace PureFreak.Collections
{
    /// <summary>
    /// Represents a tree with generic values.
    /// </summary>
    /// <typeparam name="T">Typ of node values.</typeparam>
    public interface ITree<T> : ITreeNodeContainer<T>
    {
        #region Methods
        #endregion

        #region Properties

        /// <summary>
        /// Returns or sets the path separator character used for concatination the nodes <see cref="ITreeNode{T}.FullName"/>.
        /// </summary>
        char PathSeparator { get; set; }

        #endregion
    }
}