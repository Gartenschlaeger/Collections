using System;
using System.Collections.Generic;

namespace PureFreak.Collections
{
    public interface ITreeNodeCollection<T> : IEnumerable<ITreeNode<T>>
    {
        #region Methods

        ITreeNode<T> Create(string name);

        ITreeNode<T> Create(string name, T value);

        bool Remove(string name);

        bool Remove(ITreeNode<T> node);

        ITreeNode<T> Get(string name);

        IEnumerable<ITreeNode<T>> GetDescendantNodes();

        IEnumerable<ITreeNode<T>> GetDescendantNodes(Func<ITreeNode<T>, bool> match);

        bool Contains(string name);

        bool Contains(ITreeNode<T> node);

        void Clear();

        #endregion

        #region Properties

        ITreeNode<T> this[string name] { get; }

        int Count { get; }

        #endregion
    }
}