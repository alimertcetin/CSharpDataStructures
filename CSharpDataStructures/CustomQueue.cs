using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSharpDataStructures
{
    class CustomQueue<T> : IEnumerable<T>, ICollection, IReadOnlyCollection<T>
    {
        T[] values;
        int head;
        int tail;

        //https://github.com/microsoft/referencesource/blob/master/System/compmod/system/collections/generic/queue.cs - 42
        //private const int _MinimumGrow = 4; ?
        private const int _ShrinkThreshold = 32;
        //private const int _GrowFactor = 200;  // double each time ?
        private const int _DefaultCapacity = 4;

        public CustomQueue()
        {
            values = new T[_DefaultCapacity];
            head = 0;
            tail = 0;
        }

        public CustomQueue(int size)
        {
            size = size < _DefaultCapacity ? _DefaultCapacity : size;

            values = new T[size];
            head = 0;
            tail = 0;
        }

        public void Enqueue(T item)
        {
            if (tail == values.Length)
            {
                Array.Resize(ref values, tail * 2);
            }

            values[tail++] = item;
        }

        public T Dequeue()
        {
            var item = values[head];
            values[head++] = default(T);

            if(head == _ShrinkThreshold)
            {
                var newArr = new T[tail - head];
                int index = 0;
                for (int i = head; i < tail; i++)
                {
                    newArr[index++] = values[i];
                }
                values = newArr;
                head = 0;
                tail = newArr.Length;
            }

            return item;
        }

        public int Count => tail - head;

        public bool IsSynchronized => values.IsSynchronized;

        public object SyncRoot => values.SyncRoot;

        public void CopyTo(Array array, int index) => values.CopyTo(array, index);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator() => new CustomQueueEnumerator(this);

        public struct CustomQueueEnumerator : IEnumerator<T>
        {
            int index;
            CustomQueue<T> customQueue;

            public T Current => customQueue.values[index];

            object IEnumerator.Current => Current;

            public CustomQueueEnumerator(CustomQueue<T> customQueue)
            {
                this.customQueue = customQueue;
                index = customQueue.head - 1;
            }

            public void Dispose()
            {
                customQueue = null;
            }

            public bool MoveNext()
            {
                return index++ < customQueue.tail - 1;
            }

            public void Reset()
            {
                index = customQueue.head - 1;
            }
        }
    }
}
