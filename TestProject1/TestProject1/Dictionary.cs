
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace Dictionary
{
    class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        int[] buckets;
        element<TKey, TValue>[] elements;
        int freeIndex = -1;
        public Dictionary(int lenght)
        {
            buckets = new int[lenght];
            elements = new element<TKey, TValue>[lenght];
            Array.Fill(buckets, -1);
        }

        public void Add(TKey key, TValue value)
        {
            int index = key.GetHashCode() % buckets.Length;
            int nodeIndex = FreePosition();
            if (buckets[index] == -1)
            {
                buckets[index] = nodeIndex;
                elements[nodeIndex] = new element<TKey, TValue>(key, value, -1);
            }
            else
            {
                elements[nodeIndex] = new element<TKey, TValue>(key, value, buckets[index]);
                buckets[index] = nodeIndex;
            }

            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        private int FreePosition()
        {
            if(freeIndex == -1)
            {
                return Count;
            }

            int index = freeIndex;
            freeIndex = elements[freeIndex].Next;
            return index;
        }

        private int IndexOfKey(TKey key, out bool previous)
        {
            int index = key.GetHashCode() % buckets.Length;
            int nodeIndex = buckets[index];
            previous = false;
            for (int i = nodeIndex; i != -1; i = elements[i].Next)
            {
                if (elements[i] != null && elements[i].Key.Equals(key))
                {
                    return nodeIndex;
                }

                previous = true;
            }
            
            return -1;
        }

        public bool ContainsKey(TKey key)
        {
            bool previous;
            return IndexOfKey(key, out previous) != -1;
        }

        public ICollection<TKey> Keys
        {
            get
            {
                var keys = new List<TKey>();
                for (int i = 0; i < elements.Length; i++)
                {
                    if (elements[i] != null && !elements[i].Key.Equals(default(TKey)))
                    {
                        keys.Add(elements[i].Key);
                    }
                }

                return keys;
            }
        }

        public bool Remove(TKey key)
        {
            bool previous;
            int index = IndexOfKey(key, out previous);
            if (index == -1)
            {
                return false;
            }

            if (previous)
            {
                elements[index].Next = elements[elements[index].Next].Next;
            }
            else
            {
                buckets[key.GetHashCode() % buckets.Length] = elements[index].Next;
            }

            Count--;
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int index = IndexOfKey(key, out bool previous);
            if (index == -1)
            {
                value = default(TValue);
                return false;
            }

            value = elements[index].Value;
            return true;
        }

        public ICollection<TValue> Values
        {
            get
            {
                var keys = new List<TValue>();
                for (int i = 0; i < elements.Length; i++)
                {
                    if (elements[i] != null && !elements[i].Key.Equals(default(TKey)))
                    {
                        keys.Add(elements[i].Value);
                    }
                }

                return keys;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                bool succeded = TryGetValue(key, out TValue value);
                return value;
            }
            
            set
            {
                int index = IndexOfKey(key, out bool previous);
                if (index == -1)
                {
                    Add(key, value);
                }
                else
                {
                    elements[index].Value = value;
                }
            }
        }

        public void Clear()
        {
            elements = new element<TKey, TValue>[buckets.Length];
            buckets = new int[buckets.Length];
            Count = 0;
            Array.Fill(buckets, -1);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ContainsKey(item.Key) && TryGetValue(item.Key, out TValue value) && value.Equals(item.Value);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != null && elements[i].Key.Equals(default(TKey)))
                {
                    array[arrayIndex] = new KeyValuePair<TKey, TValue>(elements[i].Key, elements[i].Value);
                    arrayIndex++;
                }
            }
        }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
           return Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != null && !elements[i].Key.Equals(default(TKey)))
                {
                    yield return new KeyValuePair<TKey, TValue>(elements[i].Key, elements[i].Value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
