using System.Collections;

namespace Collection
{
    class List<T> : IEnumerable
    {
        protected T[] objects;

        public List()
        {
            this.objects = new T[4];
        }

        public void Add(T element)
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

        public T this[int index]
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

        public void Insert(int index, T element)
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

        public void Remove(T element)
        {
            int index = FindIndex(element);
            RemoveAt(index);
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

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return objects[i];
            }
        }
    }
}
