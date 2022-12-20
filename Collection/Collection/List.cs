using System.Collections;
using System.Data;
using System.Text.Json;

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
            IsReadOnlyException();
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
            get
            {
                InvalidIndexException(index);
                return objects[index];
            }
            set
            {
                IsReadOnlyException();
                InvalidIndexException(index);
                objects[index] = value; 
            }
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
            InvalidIndexException(index);
            IsReadOnlyException();
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

        public virtual void Clear()
        {
            objects = new T[4];
            Count = 0;
        }

        public virtual bool Remove(T element)
        {
            IsReadOnlyException();
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

        public virtual void RemoveAt(int index)
        {
            InvalidIndexException(index);
            IsReadOnlyException();
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

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            InvalidIndexException(arrayIndex);
            ArrayNullException(array);
            NotEnoughCapacityException(array.Length, arrayIndex);
            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex++] = objects[i];
            }
        }

        public virtual bool IsReadOnly => false;

        private void InvalidIndexException(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Index is invalid");
            }
        }

        private void IsReadOnlyException()
        {
            if (IsReadOnly)
            {
                throw new ReadOnlyException("Is Read Only");
            }
        }

        private void ArrayNullException(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array Is Null");
            }
        }

        private void NotEnoughCapacityException(int lengthArray, int arrayIndex)
        {
            if (lengthArray - arrayIndex < Count)
            {
                throw new ArgumentException("NotEnoughCapacity");
            }
        }
    }
}
