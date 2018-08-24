namespace System.Collections.Generic
{
    public static class ListExtensions
    {
        #region Methods

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

        public static void Shuffle<T>(this List<T> list, Random random)
        {
            var max = list.Count;
            while (max > 1)
            {
                max--;

                var rndIndex = random.Next(max + 1);
                var rndValue = list[rndIndex];

                list[rndIndex] = list[max];
                list[max] = rndValue;
            }
        }

        #endregion
    }
}