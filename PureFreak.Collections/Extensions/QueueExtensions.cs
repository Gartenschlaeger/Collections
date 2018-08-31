namespace System.Collections.Generic
{
    /// <summary>
    /// Contains extension methods for <see cref="Queue{T}"/>.
    /// </summary>
    public static class QueueExtensions
    {
        #region Extension methods

        /// <summary>
        /// Enqueues all items from source to the queue.
        /// </summary>
        /// <typeparam name="T">Value type of queue.</typeparam>
        /// <param name="queue">Queue to enqueue the items to.</param>
        /// <param name="source">Source items to enqueue.</param>
        public static void EnqueueRange<T>(this Queue<T> queue, IEnumerable<T> source)
        {
            if (queue == null)
                throw new ArgumentNullException(nameof(queue));
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            foreach (var item in source)
            {
                queue.Enqueue(item);
            }
        }

        #endregion
    }
}