using System.Diagnostics;

namespace PureFreak.Collections
{
    internal sealed class CircularBufferDebuggerView<T>
    {
        private readonly CircularBuffer<T> _circularBuffer;

        public CircularBufferDebuggerView(CircularBuffer<T> curcularBuffer)
        {
            _circularBuffer = curcularBuffer;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public T[] Items
        {
            get { return _circularBuffer.ToArray(); }
        }
    }
}