using System;

namespace XIV.DataStructures.Extentions
{
    public static class ArrayUtils
    {
        public static T[] Add<T>(this T[] values, T item)
        {
            Array.Resize(ref values, values.Length + 1);

            values[^1] = item;
            return values;
        }

        public static bool Contains<T>(this T[] values, T item)
        {
            var length = values.Length;
            for (int i = 0; i < length; i++)
            {
                if (values[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public static int IndexOf<T>(this T[] values, T item)
        {
            var length = values.Length;
            for (int i = 0; i < length; i++)
            {
                if (values[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public static T[] Insert<T>(this T[] values, int index, T item)
        {
            var length = values.Length;
            Array.Resize(ref values, values.Length + 1);

            for (int i = length; i >= index; i--)
            {
                values[i] = values[i - 1];
            }
            values[index] = item;
            return values;
        }

        public static T[] RemoveAt<T>(this T[] values, int index)
        {
            var length = values.Length;
            for (int i = index; i < length - 1; i++)
            {
                values[i] = values[i + 1];
            }
            Array.Resize(ref values, values.Length - 1);
            return values;
        }
    }
}
