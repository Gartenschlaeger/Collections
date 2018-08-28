namespace System.Collections.Generic
{
    /// <summary>
    /// Contains extensions for <see cref="List{T}"/>
    /// </summary>
    public static class ListExtensions
    {
        #region Methods

        /// <summary>
        /// Switches two list elements.
        /// </summary>
        /// <typeparam name="T">Typ of the <see cref="List{T}"/>.</typeparam>
        /// <param name="list">The <see cref="List{T}"/> containing the items.</param>
        /// <param name="index1">The first item index of item to switch.</param>
        /// <param name="index2">The second item index of item to switch.</param>
        public static void Switch<T>(this List<T> list, int index1, int index2)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            if (index1 < 0 || index1 >= list.Count)
                throw new ArgumentOutOfRangeException(nameof(index1));
            if (index2 < 0 || index2 >= list.Count)
                throw new ArgumentOutOfRangeException(nameof(index2));
            if (index1 == index2)
                return;

            var tmp = list[index1];

            list[index1] = list[index2];
            list[index2] = tmp;
        }

        /// <summary>
        /// Calls a delegate for each item to each other item. />
        /// </summary>
        /// <typeparam name="T">Typ of the <see cref="List{T}"/>.</typeparam>
        /// <param name="list"><see cref="List{T}"/> containing the items.</param>
        /// <param name="callback">Delegate to call.</param>
        public static void Interact<T>(this List<T> list, Action<T, T> callback)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            for (int index = 0; index < list.Count; index++)
            {
                for (int subIndex = 0; subIndex < list.Count; subIndex++)
                {
                    if (index != subIndex)
                    {
                        callback(list[index], list[subIndex]);
                    }
                }
            }
        }

        /// <summary>
        /// Shuffles all items of a <see cref="List{T}"/> in random order.
        /// </summary>
        /// <typeparam name="T">Typ of the <see cref="List{T}"/>.</typeparam>
        /// <param name="list"><see cref="List{T}"/> containing the items.</param>
        /// <param name="random">Random instance to use.</param>
        public static void Shuffle<T>(this List<T> list, Random random)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            if (random == null)
                throw new ArgumentNullException(nameof(random));

            for (int max = list.Count - 1; max > 1; max--)
            {
                Switch(list, max, random.Next(max + 1));
            }
        }

        #endregion
    }
}