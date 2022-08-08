using System;
using System.Collections;
using System.Collections.Generic;

namespace XIV.DataStructures
{
    public class CustomStack<T> : IList<T>
    {
        T[] values;
        int length;

        public T this[int index]
        {
            get => values[index];
            set => values[index] = value;
        }

        public int Count => length;
        public int Capacity => values.Length;
        public bool IsReadOnly => values.IsReadOnly;

        public CustomStack()
        {
            values = new T[8];
        }

        public CustomStack(int count)
        {
            values = new T[count];
        }

        public void Add(T item)
        {
            if (length == values.Length)
            {
                Array.Resize(ref values, values.Length * 2);
            }

            values[length++] = item;
        }

        public void Clear()
        {
            values = new T[2];
            length = 0;
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

        public int IndexOf(T item)
        {
            for (int i = 0; i < length; i++)
            {
                if (values[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (length == values.Length)
            {
                Array.Resize(ref values, values.Length * 2);
            }

            for (int i = length; i >= index; i--)
            {
                values[i] = values[i - 1];
            }
            length++;
            values[index] = item;
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);
            if (index < 0) return false;

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < length - 1; i++)
            {
                values[i] = values[i + 1];
            }
            length--;
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
        	return values[length--];
        }

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
        public IEnumerator<T> GetEnumerator() => new CustomListEnumerator(this);

        public struct CustomListEnumerator : IEnumerator<T>
        {
            public int currentIndex;
            public T Current => list[currentIndex];

            object IEnumerator.Current => Current;

            CustomStack<T> list;

            public CustomListEnumerator(CustomStack<T> list)
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
