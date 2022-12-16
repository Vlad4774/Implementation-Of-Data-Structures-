using System.Collections;
using System.Runtime.CompilerServices;

namespace Collection
{
    class ObjectArray : IEnumerable
    {
        protected object[] objects;

        public ObjectArray()
        {
            this.objects = new object[4];
        }

        public void Add(object element)
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

        public object this[int index]
        {
            get => objects[index];
            set => objects[index] = value;
        }

        public bool Contains(object element)
        {
            return IndexOf(element) >= 0;
        }

        public int IndexOf(object element)
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

        public void Insert(int index, object element)
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
            objects = new object[4];
            Count = 0;
        }

        public void Remove(object element)
        {
            int index = FindIndex(element);
            RemoveAt(index);
        }

        private int FindIndex(object element)
        {
            for (int index = 0; index < objects.Length; index++)
            {
                if (objects[index] == element)
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
            var array = this;
            return new ClassIEnumerator(this);
        }
    }
}
