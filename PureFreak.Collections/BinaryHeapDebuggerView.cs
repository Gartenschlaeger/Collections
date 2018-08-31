using System.Diagnostics;

namespace PureFreak.Collections
{
    internal sealed class BinaryHeapDebuggerView<T>
    {
        private readonly BinaryHeap<T> _heap;

        public BinaryHeapDebuggerView(BinaryHeap<T> bag)
        {
            _heap = bag;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public T[] Items
        {
            get { return _heap.ToArray(); }
        }
    }
}