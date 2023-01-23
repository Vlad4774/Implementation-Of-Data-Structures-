using System;
using System.Collections;

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
            int index = GetIndexUsingKey(key);
            int elementIndex = FreePosition();
            int next = -1;
            if (buckets[index] != -1)
            {
                next = buckets[index];
            }

            buckets[index] = elementIndex;
            elements[elementIndex] = new element<TKey, TValue>(key, value, next);
            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        private int GetIndexUsingKey(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % buckets.Length;
        }
        
        private int FreePosition()
        {
            if (freeIndex == -1)
            {
                return Count;
            }

            int index = freeIndex;
            freeIndex = elements[index].Next;
            return index;
        }

        private int IndexOfKey(TKey key)
        {
            int index = GetIndexUsingKey(key);
            int elementIndex = buckets[index];
            for (int i = elementIndex; i != -1; i = elements[i].Next)
            {
                if (elements[i].Key.Equals(key))
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
                foreach (var element in this)
                {
                    keys.Add(element.Key);
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

            int index = GetIndexUsingKey(key);
            int elementIndex = buckets[index];
            int previous;
            elementIndex = FindElementIndexToRemove(key, elementIndex, out previous);

            if (previous == -1)
            {
                buckets[index] = elements[elementIndex].Next;
            }
            else
            {
                elements[previous].Next = elements[elementIndex].Next;
            }

            RemoveElementAndSetFreeIndex(elementIndex);
            Count--;
            return true;
        }

        private void RemoveElementAndSetFreeIndex(int elementIndex)
        {
            elements[elementIndex].Next = freeIndex;
            freeIndex = elementIndex;
            elements[elementIndex].Key = default(TKey);
            elements[elementIndex].Value = default(TValue);
        }

        private int FindElementIndexToRemove(TKey key, int elementIndex, out int previous)
        {
            previous = -1;
            while (elementIndex != -1)
            {
                if (elements[elementIndex].Key.Equals(key))
                {
                    return elementIndex;
                }

                previous = elementIndex;
                elementIndex = elements[elementIndex].Next;
            }

            return -1;
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
                List<TValue> values = new List<TValue>();
                foreach (var element in this)
                {
                    values.Add(element.Value);
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
            return TryGetValue(item.Key, out TValue value) && value.Equals(item.Value);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != null && elements[i].Equals(default(element<TKey, TValue>)))
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
                if (elements[i] != null && !elements[i].Equals(default(element<TKey, TValue>)))
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

