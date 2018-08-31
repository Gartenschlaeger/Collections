using System;
using System.Collections.Generic;

namespace PureFreak.Collections.Extensions
{
    /// <summary>
    /// Contains extension methods for <see cref="Stack{T}"/>.
    /// </summary>
    public static class StackExtensions
    {
        #region Extension methods

        /// <summary>
        /// Pushes all items from source to the stack.
        /// </summary>
        /// <typeparam name="T">Value type of items.</typeparam>
        /// <param name="stack">Stack to push the items to.</param>
        /// <param name="source">Items source to push.</param>
        public static void PushRange<T>(this Stack<T> stack, IEnumerable<T> source)
        {
            if (stack == null)
                throw new ArgumentNullException(nameof(stack));
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            foreach (var item in source)
            {
                stack.Push(item);
            }
        }

        #endregion
    }
}