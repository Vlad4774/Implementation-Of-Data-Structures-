
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
            NullException(key);
            SameKeyException(key);
            int index = Math.Abs(key.GetHashCode()) % buckets.Length;
            int elementIndex = FreePosition();
            if (buckets[index] == -1)
            {
                buckets[index] = elementIndex;
                elements[elementIndex] = new element<TKey, TValue>(key, value, -1);
            }
            else
            {
                elements[elementIndex] = new element<TKey, TValue>(key, value, buckets[index]);
                buckets[index] = elementIndex;
            }

            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        private int FreePosition()
        {
            if (freeIndex == -1)
            {
                return Count;
            }

            freeIndex = NextFreePosition();
            return freeIndex;
        }

        private int NextFreePosition()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == null || elements[i].Equals(default(element<TKey, TValue>)))
                {
                    return i;
                }
            }

            throw new InvalidOperationException("Dictionary is full");
        }


        private int IndexOfKey(TKey key)
        {
            int index = Math.Abs(key.GetHashCode()) % buckets.Length;
            int elementIndex = buckets[index];
            for (int i = elementIndex; i != -1; i = elements[i].Next)
            {
                if (elements[i] != null && elements[i].Key.Equals(key))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool ContainsKey(TKey key)
        {
            NullException(key);
            return IndexOfKey(key) != -1;
        }

        public ICollection<TKey> Keys
        {
            get
            {
                List<TKey> keys = new List<TKey>();
                for (int i = 0; i < elements.Length; i++)
                {
                    if (elements[i] != null && !elements[i].Equals(default(element<TKey, TValue>)))
                    {
                        keys.Add(elements[i].Key);
                    }
                }

                return keys;
            }
        }

        public bool Remove(TKey key)
        {
            NullException(key);
            if (!ContainsKey(key))
            {
                return false;
            }

            int index = Math.Abs(key.GetHashCode() % buckets.Length);
            int elementIndex = buckets[index];
            int previous = -1;

            while (elementIndex != -1)
            {
                if (elements[elementIndex].Key.Equals(key))
                {
                    if (previous == -1)
                    {
                        buckets[index] = elements[elementIndex].Next;
                    }
                    else
                    {
                        elements[previous].Next = elements[elementIndex].Next;
                    }

                    elements[elementIndex] = default(element<TKey, TValue>);

                    break;
                }

                previous = elementIndex;
                elementIndex = elements[elementIndex].Next;
            }

            freeIndex = elementIndex;
            Count--;
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            NullException(key);
            int index = IndexOfKey(key);
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
                var values = new List<TValue>();
                for (int i = 0; i < elements.Length; i++)
                {
                    if (elements[i] != null && elements[i].Value != null && !elements[i].Value.Equals(default(TValue)))
                    {
                        values.Add(elements[i].Value);
                    }
                }

                return values;

            }
        }

        public TValue this[TKey key]
        {
            get
            {
                NullException(key);
                bool succeded = TryGetValue(key, out TValue value);
                return value;
            }

            set
            {
                NullException(key);
                int index = IndexOfKey(key);
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
            NullException(item.Key);
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

        private void NullException(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key cannot be null");
            }
        }

        private void SameKeyException(TKey key)
        {
            if (ContainsKey(key))
            {
                throw new ArgumentException("Key already exists");
            }
        }
    }
}

