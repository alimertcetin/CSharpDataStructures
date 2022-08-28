using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace XIV.DataStructures
{
    public struct BucketData<TKey, TValue>
    {
        public KeyValuePair<TKey, TValue>[] array;
        public int Capacity => array.Length;
        public int Count;

        public BucketData(int size)
        {
            array = new KeyValuePair<TKey, TValue>[size];
            Count = 0;
        }
    }

    //https://github.com/microsoft/referencesource/blob/master/mscorlib/system/collections/generic/dictionary.cs
    //IDictionary<TKey, TValue>, IDictionary, IReadOnlyDictionary<TKey, TValue>, ISerializable, IDeserializationCallback
    // Reference source implements interfaces above but current Dictionary class implements 
    /*
        ICollection<KeyValuePair<TKey, TValue>>, 
        IEnumerable<KeyValuePair<TKey, TValue>>, 
        IEnumerable, 
        IDictionary<TKey, TValue>, 
        IReadOnlyCollection<KeyValuePair<TKey, TValue>>
        IReadOnlyDictionary<TKey, TValue>, 
        ICollection, 
        IDictionary, 
        IDeserializationCallback, 
        ISerializable where TKey : notnull
     */

    public class CustomDictionary<TKey, TValue> :
        ICollection<KeyValuePair<TKey, TValue>>, 
        IEnumerable<KeyValuePair<TKey, TValue>>, 
        IEnumerable, 
        IDictionary<TKey, TValue>, 
        IReadOnlyCollection<KeyValuePair<TKey, TValue>>
        //IReadOnlyDictionary<TKey, TValue>, 
        //ICollection, 
        //IDictionary, 
        //IDeserializationCallback, 
        //ISerializable where TKey : notnull
    {
        const int BucketCount = 8;
        const int DefaultBucketSize = 8;

        BucketData<TKey, TValue>[] buckets;

        public int Count { get; private set; }

        public bool IsReadOnly => throw new NotImplementedException();

        // TODO : Use comparer
        //IEqualityComparer comparer;

        #region IDictionary<TKey, TValue> implementation

        public ICollection<TKey> Keys => throw new NotImplementedException();

        public ICollection<TValue> Values => throw new NotImplementedException();

        #endregion

        public TValue this[TKey key]
        {
            get 
            {
                ref var bucket = ref GetBucket(key);
                for (int i = 0; i < bucket.Count; i++)
                {
                    if (bucket.array[i].Key.Equals(key))
                    {
                        return bucket.array[i].Value;
                    }
                }

                throw new KeyNotFoundException(key.ToString());
            }
            set
            {
                ref var bucket = ref GetBucket(key);
                for (int i = 0; i < bucket.Count; i++)
                {
                    if (bucket.array[i].Key.Equals(key))
                    {
                        // TODO : Which one is better?
                        bucket.array[i] = new KeyValuePair<TKey, TValue>(key, value);
                        //bucket.array[i] = KeyValuePair.Create(key, value);
                        return;
                    }
                }

                throw new KeyNotFoundException(key.ToString());
            }
        }

        public CustomDictionary() : this(null, DefaultBucketSize) { }
        public CustomDictionary(int size) : this(null, size) { }
        public CustomDictionary(IEqualityComparer comparer) : this (comparer, DefaultBucketSize) { }

        public CustomDictionary(IEqualityComparer comparer, int size)
        {
            //this.comparer = comparer ?? EqualityComparer<TKey>.Default;

            buckets = new BucketData<TKey, TValue>[BucketCount];
            for (int i = 0; i < BucketCount; i++)
            {
                buckets[i] = new BucketData<TKey, TValue>(size);
            }
        }

        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                throw new InvalidOperationException("Key already exist. " + key);
            }
            ref BucketData<TKey, TValue> bucket = ref GetBucket(key);
            ref var count = ref bucket.Count;
            var capacity = bucket.Capacity;

            if (capacity == count)
            {
                Array.Resize(ref bucket.array, capacity * 2);
            }

            bucket.array[count++] = new KeyValuePair<TKey, TValue>(key, value);

            Count++;
        }

        public bool Remove(TKey key)
        {
            ref BucketData<TKey, TValue> bucket = ref GetBucket(key);
            var count = bucket.Count;
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (bucket.array[i].Key.Equals(key))
                {
                    index = i;
                    break;
                }
            }

            if (index < 0) return false;

            for (int i = index; i < count - 1; i++)
            {
                bucket.array[i] = bucket.array[i + 1];
            }

            bucket.Count--;

            Count--;

            return true;
        }

        public bool ContainsKey(TKey key)
        {
            ref BucketData<TKey, TValue> bucket = ref GetBucket(key);

            int count = bucket.Count;
            for (int i = 0; i < count; i++)
            {
                if (bucket.array[i].Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsValue(TValue value)
        {
            for (int i = 0; i < BucketCount; i++)
            {
                ref var bucket = ref buckets[i];
                var count = bucket.Count;
                for (int j = 0; j < count; j++)
                {
                    if(bucket.array[j].Value.Equals(value))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        ref BucketData<TKey, TValue> GetBucket(TKey key) => ref buckets[Math.Abs(key.GetHashCode() % BucketCount)];

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => new CustomDictionaryEnumerator(this);

        #region ICollection<KeyValuePair<TKey, TValue>> implementation

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            ref BucketData<TKey, TValue> bucket = ref GetBucket(item.Key);
            ref var count = ref bucket.Count;
            var capacity = bucket.Capacity;

            if (capacity == count)
            {
                Array.Resize(ref bucket.array, capacity * 2);
            }

            bucket.array[count++] = item;

            Count++;
        }

        public void Clear()
        {
            // TODO : set array values to null?
            for (int i = 0; i < BucketCount; i++)
            {
                buckets[i] = new BucketData<TKey, TValue>(DefaultBucketSize);
            }

            Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            for (int i = 0; i < BucketCount; i++)
            {
                ref var bucket = ref buckets[i];
                var count = bucket.Count;
                for (int j = 0; j < count; j++)
                {
                    if (bucket.array[j].Key.Equals(item.Key) && bucket.array[j].Value.Equals(item.Value))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            var arrayToMerge = new KeyValuePair<TKey, TValue>[Count];
            int counter = 0;
            foreach (KeyValuePair<TKey, TValue> item in this)
            {
                arrayToMerge[counter++] = item;
            }

            Array.Copy(arrayToMerge, 0, array, arrayIndex, counter);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            ref BucketData<TKey, TValue> bucket = ref GetBucket(item.Key);
            var count = bucket.Count;
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (bucket.array[i].Key.Equals(item.Key) && bucket.array[i].Value.Equals(item.Value))
                {
                    index = i;
                    break;
                }
            }

            if (index < 0) return false;

            for (int i = index; i < count - 1; i++)
            {
                bucket.array[i] = bucket.array[i + 1];
            }

            bucket.Count--;

            Count--;

            return true;
        }

        #endregion

        #region IDictionary<TKey, TValue> implementation

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            ref var bucket = ref GetBucket(key);
            var count = bucket.Count;
            for (int i = 0; i < count; i++)
            {
                if (bucket.array[i].Key.Equals(key))
                {
                    value = bucket.array[i].Value;
                    return true;
                }
            }

            value = default;
            return false;
        }

        #endregion

        public struct CustomDictionaryEnumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            public int currentListIndex;
            public int currentItemIndex;

            public KeyValuePair<TKey, TValue> Current => customDictionary.buckets[currentListIndex].array[currentItemIndex];

            object IEnumerator.Current => Current;

            CustomDictionary<TKey, TValue> customDictionary;

            public CustomDictionaryEnumerator(CustomDictionary<TKey, TValue> customDictionary)
            {
                this.customDictionary = customDictionary;
                currentListIndex = -1;
                currentItemIndex = -1;
            }

            public void Dispose()
            {
                customDictionary = null;
            }

            public bool MoveNext()
            {
                if (currentListIndex < 0)
                {
                    MoveToNextNotNullBucket();
                }

                if (++currentItemIndex < customDictionary.buckets[currentListIndex].Count)
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
                var length = customDictionary.buckets.Length;
                for (int i = currentListIndex; i < length; i++)
                {
                    if (customDictionary.buckets[i].Count > 0)
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

        // [Serializable]
        // public sealed class KeyCollection : ICollection<TKey>, ICollection, IReadOnlyCollection<TKey>

        // [Serializable]
        // public sealed class ValueCollection : ICollection<TValue>, ICollection, IReadOnlyCollection<TValue>



    }
}
