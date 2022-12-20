using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    class ReadOnlyList<T> : IList<T>
    {
        private List<T> objects;
        public ReadOnlyList(List<T> list)
        {
            this.objects = list;
        }

        public virtual void Add(T element)
        {
            IsReadOnlyException();
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
            }
        }

        public bool Contains(T element)
        {
            return IndexOf(element) >= 0;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < objects.Count; i++)
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
            IsReadOnlyException();
        }

        public void Clear()
        {
            IsReadOnlyException();
        }

        public bool Remove(T element)
        {
            IsReadOnlyException();
            return false;
        }

        private int FindIndex(T element)
        {
            for (int index = 0; index < objects.Count; index++)
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
            IsReadOnlyException();
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
            IsReadOnlyException();
        }

        public bool IsReadOnly => true;

        private void IsReadOnlyException()
        {
            throw new ReadOnlyException("Is Read Only");
        }

        private void InvalidIndexException(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Index is invalid");
            }
        }
    }
}
