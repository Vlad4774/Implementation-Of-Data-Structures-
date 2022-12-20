using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    class ReadOnlyList<T> : List<T>, IList<T>
    {
        private IList<T> objects;
        public ReadOnlyList(IList<T> list)
        {
            this.objects = list;
        }

        public override void Add(T element)
        {
            IsReadOnlyException();
        }

        public override T this[int index]
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

        public override void Insert(int index, T element)
        {
            IsReadOnlyException();
        }

        public override void Clear()
        {
            IsReadOnlyException();
        }

        public override bool Remove(T element)
        {
            IsReadOnlyException();
            return false;
        }

        public override void RemoveAt(int index)
        {
            IsReadOnlyException();
        }

        public override void CopyTo(T[] array, int arrayIndex)
        {
            IsReadOnlyException();
        }

        public override bool IsReadOnly => true;

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
