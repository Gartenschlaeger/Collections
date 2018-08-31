namespace PureFreak.Collections
{
    /// <summary>
    /// Represents a node.
    /// </summary>
    /// <typeparam name="T">Type of the node value.</typeparam>
    public interface ITreeNode<T> : ITreeNodeContainer<T>
    {
        #region Methods
        #endregion

        #region Properties

        /// <summary>
        /// Name of the current node.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Full name (path) of the current node.
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// Level of the current node.
        /// </summary>
        int Level { get; }

        /// <summary>
        /// Value of the node.
        /// </summary>
        T Value { get; set; }

        /// <summary>
        /// <see cref="ITree{T}"/> owner of the node.
        /// </summary>
        ITree<T> Tree { get; }

        /// <summary>
        /// The parent node or null, if node is on root level.
        /// </summary>
        ITreeNode<T> Parent { get; }

        #endregion
    }
}