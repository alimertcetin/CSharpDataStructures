using System;
using System.Collections;
using System.Collections.Generic;

namespace XIV.DataStructures
{
    public class CustomStack<T> : IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, ICollection
    {
        T[] values;
        int length;

        public int Count => length;
        public bool IsReadOnly => values.IsReadOnly;
        public bool IsSynchronized => values.IsSynchronized;
        public object SyncRoot => values.SyncRoot;

        public CustomStack()
        {
            values = new T[8];
        }

        public CustomStack(int count)
        {
            values = new T[count];
        }

        public void Clear()
        {
            Array.Clear(values, 0, values.Length);
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < length; i++)
            {
                if (values[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            values.CopyTo(array, arrayIndex);
        }

        public void Push(T item)
        {
        	if (length == values.Length)
            {
                Array.Resize(ref values, values.Length * 2);
            }

            values[length++] = item;
        }

        public T Pop()
        {
            var item = values[--length];
            // https://github.com/microsoft/referencesource/blob/master/System/compmod/system/collections/generic/stack.cs - 227
            values[length] = default(T); // Free memory quicker.
            return item;
        }

        public T Peek() => values[length];

        public void TrimExcess()
        {
            var valueArray = new T[length];
            for (int i = 0; i < length; i++)
            {
                valueArray[i] = values[i];
            }
            values = valueArray;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator() => new CustomStackEnumerator(this);

        public void CopyTo(Array array, int index) => values.CopyTo(array, index);

        public struct CustomStackEnumerator : IEnumerator<T>
        {
            public int currentIndex;
            public T Current => list.values[currentIndex];

            object IEnumerator.Current => Current;

            CustomStack<T> list;

            public CustomStackEnumerator(CustomStack<T> list)
            {
                this.list = list;
                currentIndex = list.Count;
            }

            public void Dispose()
            {
                list = null;
            }

            public bool MoveNext() => --currentIndex > -1;

            public void Reset()
            {
                currentIndex = list.Count;
            }
        }
    }
}
