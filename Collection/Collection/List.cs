using System.Collections;

namespace Collection
{
    class List<T> : IList<T>
    {
        protected T[] objects;

        public List()
        {
            this.objects = new T[4];
        }

        public virtual void Add(T element)
        {
            EnoughCapacity();
            objects[Count] = element;
            Count++;
        }

        private void EnoughCapacity()
        {
            if (objects.Length == Count)
            {
                Array.Resize(ref objects, objects.Length * 2);
            }
        }

        public int Count { get; private set; } = 0;

        public virtual T this[int index]
        {
            get => objects[index];
            set => objects[index] = value;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) >= 0;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T element)
        {
            EnoughCapacity();
            ShiftRight(index);
            objects[index] = element;
            Count++;
        }

        private void ShiftRight(int index)
        {
            for (int i = objects.Length - 1; i > index; i--)
            {
                objects[i] = objects[i - 1];
            }
        }

        public void Clear()
        {
            objects = new T[4];
            Count = 0;
        }

        public bool Remove(T element)
        {
            int index = FindIndex(element);
            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        private int FindIndex(T element)
        {
            for (int index = 0; index < objects.Length; index++)
            {
                if (objects[index].Equals(element))
                {
                    return index;
                }
            }

            return -1;
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
        }

        private void ShiftLeft(int index)
        {
            for (int i = objects.Length - 1; i > index; i--)
            {
                objects[i - 1] = objects[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return objects[i];
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex++] = objects[i];
            }
        }

        public bool IsReadOnly => false;
    }
}
