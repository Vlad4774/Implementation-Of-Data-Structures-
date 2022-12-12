

namespace Collection
{
    class sortedIntArray : IntArray
    {
        public override int this[int index]
        {
            set
            {
                if (CanBeSeted(index, value))   
                {
                    base[index] = value;
                }
            }
        }

        public override void Add(int element)
        {
            if (Count == 0 || element >= this[Count - 1])
            {
                base.Insert(Count, element);
                return;

            }

            for (int i = 0; i < Count; i++)
            {
                if (element <= this[i])
                {
                    base.Insert(i, element);
                    break;
                }
            }
        }

        public override void Insert(int index, int element)
        {
            if (!CanBeInserted(index, element))
            {
                return;
            }
        }

        private bool CanBeSeted(int index, int element)
        {
            if (index > 0 && index < Count - 1)
            {
                return element >= this[index - 1] && element <= this[index + 1];
            }
            else if (index > 0)
            {
                return element >= this[index - 1];
            }

            return element <= this[index + 1];
        }

        private bool CanBeInserted(int index, int element)
        {
            int first = ElementOrDefault(index - 1);
            int second = ElementOrDefault(index);
            if (first == -1 || second == -1)
            {
                return false;
            }

            return first >= element && second <= element;
        }

        private int ElementOrDefault(int index)
        {
            return index >= 0 && index < Count ? this[index] : -1;
        }
    }
}
