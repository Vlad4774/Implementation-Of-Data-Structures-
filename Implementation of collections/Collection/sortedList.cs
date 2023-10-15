

namespace Collection
{
    class SortedList<T> : List<T> where T : IComparable<T>
    {
        List<T> list;
        public SortedList()
        {
            list = new List<T>();
        }

        public override T this[int index]
        {
            set
            {
                list[index] = value;
            }
        }

        public override void Add(T element)
        {
            if (Count == 0 || (element.CompareTo(this[Count - 1]) > 0))
            {
                base.Insert(Count, element);
                return;

            }

            for (int i = 0; i < Count; i++)
            {
                if (element.CompareTo(this[i]) < 0)
                {
                    base.Insert(i, element);
                    break;
                }
            }
        }

        public override void Insert(int index, T element)
        {
            T first = ElementOrDefault(index - 1, element);
            T second = ElementOrDefault(index, element);
            if (first.CompareTo(element) > 0 || element.CompareTo(second) > 0)
            {
                return;
            }

            base.Insert(index, element);
        }

        private T ElementOrDefault(int index, T defaultValue)
        {
            return index >= 0 && index < Count ? this[index] : defaultValue;
        }
    }
}
