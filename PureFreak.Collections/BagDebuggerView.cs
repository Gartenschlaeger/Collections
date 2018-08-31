using System.Diagnostics;

namespace PureFreak.Collections
{
    internal sealed class BagDebuggerView<T>
    {
        private readonly Bag<T> _bag;

        public BagDebuggerView(Bag<T> bag)
        {
            _bag = bag;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public T[] Items
        {
            get { return _bag.ToArray(); }
        }
    }
}