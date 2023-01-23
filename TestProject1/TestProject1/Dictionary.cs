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
            elements[elementIndex] = new element<TKey, TValue>(key, value, buckets[index]);
            buckets[index] = elementIndex;
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

        private int FindElementIndex(TKey key, out int previous)
        {
            int index = GetIndexUsingKey(key);
            previous = -1;
            for (int i = buckets[index]; i != -1; i = elements[i].Next)
            {
                if (elements[i].Key.Equals(key))
                {
                    return i;
                }

                previous = i;
            }

            return -1;
        }

        public bool ContainsKey(TKey key)
        {
            NullException(key);
            int previous;
            return FindElementIndex(key, out previous) != -1;
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
            int index = GetIndexUsingKey(key);
            int previous;
            int elementIndex = FindElementIndex(key, out previous);
            if (elementIndex == -1)
            {
                return false;
            }

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

        public bool TryGetValue(TKey key, out TValue value)
        {
            NullException(key);
            int previous;
            int index = FindElementIndex(key, out previous);
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
                int previous;
                int index = FindElementIndex(key, out previous);
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
            foreach (var element in this)
            {
                array[arrayIndex] = new KeyValuePair<TKey, TValue>(element.Key, element.Value);
                arrayIndex++;
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

