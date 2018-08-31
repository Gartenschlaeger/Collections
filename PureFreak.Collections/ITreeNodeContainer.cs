using System;
using System.Collections.Generic;

namespace PureFreak.Collections
{
    public interface ITreeNodeContainer<T>
    {
        #region Methods

        ITreeNode<T> Create(string name);

        ITreeNode<T> Create(string name, T value);

        #endregion

        #region Properties

        ITreeNodeCollection<T> Nodes { get; }

        int Count { get; }

        #endregion
    }
}