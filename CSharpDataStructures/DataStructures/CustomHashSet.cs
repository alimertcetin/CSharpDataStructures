using System;
using System.Collections;
using System.Collections.Generic;

namespace XIV.DataStructures
{

    public struct BucketData<T>
    {
        public T[] array;
        public int Capacity => array.Length;
        public int Count;

        public BucketData(int size)
        {
            array = new T[size];
            Count = 0;
        }
    }

    public class CustomHashSet<T> : IEnumerable<T>, IEnumerable
    {
        const int bucketCount = 10;
        BucketData<T>[] buckets;

        public int Count;

        public CustomHashSet()
        {
            Init(8);
        }

        public CustomHashSet(int size)
        {
            Init(size);
        }

        void Init(int size)
        {
            buckets = new BucketData<T>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
            {
                buckets[i] = new BucketData<T>(size);
            }
        }

        public void Add(T item)
        {
            ref BucketData<T> bucket = ref GetBucket(item);
            ref var count = ref bucket.Count;
            var capacity = bucket.Capacity;

            if (capacity == count)
            {
                Array.Resize(ref bucket.array, capacity * 2);
            }

            bucket.array[count++] = item;

            Count++;
        }

        public void Remove(T item)
        {
            ref BucketData<T> bucket = ref GetBucket(item);
            var count = bucket.Count;
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (bucket.array[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            for (int i = index; i < count - 1; i++)
            {
                bucket.array[i] = bucket.array[i + 1];
            }

            bucket.Count--;

            Count--;
        }

        public bool Contains(T item)
        {
            ref BucketData<T> bucket = ref GetBucket(item);

            int count = bucket.Count;
            for (int i = 0; i < count; i++)
            {
                if (bucket.array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        ref BucketData<T> GetBucket(T item) => ref buckets[Math.Abs(item.GetHashCode() % bucketCount)];

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator() => new CustomHashSetEnumerator(this);

        public struct CustomHashSetEnumerator : IEnumerator<T>
        {
            public int currentListIndex;
            public int currentItemIndex;

            public T Current => customHashSet.buckets[currentListIndex].array[currentItemIndex];

            object IEnumerator.Current => Current;

            CustomHashSet<T> customHashSet;

            public CustomHashSetEnumerator(CustomHashSet<T> customHashSet)
            {
                this.customHashSet = customHashSet;
                currentListIndex = -1;
                currentItemIndex = -1;
            }

            public void Dispose()
            {
                customHashSet = null;
            }

            public bool MoveNext()
            {
                if (currentListIndex < 0)
                {
                    MoveToNextNotNullBucket();
                }

                if (++currentItemIndex < customHashSet.buckets[currentListIndex].Count)
                {
                    return true;
                }
                else
                {
                    currentItemIndex = 0;
                    return MoveToNextNotNullBucket();
                }
            }

            bool MoveToNextNotNullBucket()
            {
                ++currentListIndex;
                var length = customHashSet.buckets.Length;
                for (int i = currentListIndex; i < length; i++)
                {
                    if (customHashSet.buckets[i].Count > 0)
                    {
                        currentListIndex = i;
                        return true;
                    }
                }
                return false;
            }

            public void Reset()
            {
                currentListIndex = -1;
                currentItemIndex = -1;
            }
        }
    }
}
