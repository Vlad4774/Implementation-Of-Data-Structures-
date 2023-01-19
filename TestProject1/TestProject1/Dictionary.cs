
using System.Collections;

namespace Dictionary
{
    class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        int[] buckets;
        Node<TKey, TValue>[] nodes = new Node<TKey, TValue>[5];
        public Dictionary(int lenght)
        {
            buckets = new int[lenght];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
            }
        }

        public void Add(TKey key, TValue value)
        {
            int index = key.GetHashCode() % buckets.Length;
            int nodeIndex = IndexUsingForInsert();
            if (buckets[index] == -1)
            {
                buckets[index] = nodeIndex;
                nodes[nodeIndex] = new Node<TKey, TValue>(key, value, -1);
            }
            else
            {
                nodes[nodeIndex] = new Node<TKey, TValue>(key, value, buckets[index]);
                buckets[index] = nodeIndex;
            }

            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        private int IndexUsingForInsert()
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i] == null)
                {
                    return i;
                }
            }
            
            Resize();
            return nodes.Length / 2;
        }
        private void Resize()
        {
            Array.Resize(ref nodes, nodes.Length * 2);
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public ICollection<TKey> Keys
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        public ICollection<TValue> Values
        {
            get { throw new NotImplementedException(); }
        }

        public TValue this[TKey key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
