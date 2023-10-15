using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    class ReadOnlyList<T> : IList<T>
    {
        private IList<T> objects;
        public ReadOnlyList(IList<T> list)
        {
            this.objects = list;
        }

        public void Add(T element)
        {
            IsReadOnlyException();
        }

        public T this[int index]
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

        public int IndexOf(T element)
        {
            return objects.IndexOf(element);
        }

        public bool Contains(T element)
        {
            return objects.Contains(element);
        }

        public int Count => objects.Count;

        public void Insert(int index, T element)
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

        public void RemoveAt(int index)
        {
            IsReadOnlyException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            IsReadOnlyException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return objects.GetEnumerator();
        }

        public  bool IsReadOnly => true;

        private void IsReadOnlyException()
        {
            throw new ReadOnlyException("Is Read Only");
        }

        private void InvalidIndexException(int index)
        {
            if (index < 0 || index > objects.Count)
            {
                throw new IndexOutOfRangeException("Index is invalid");
            }
        }
    }
}
