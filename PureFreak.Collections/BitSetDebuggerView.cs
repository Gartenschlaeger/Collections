using System.Diagnostics;

namespace PureFreak.Collections
{
    internal sealed class BitSetDebuggerView
    {
        private readonly BitSet _set;

        public BitSetDebuggerView(BitSet bag)
        {
            _set = bag;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public bool[] Items
        {
            get { return _set.ToArray(); }
        }
    }
}