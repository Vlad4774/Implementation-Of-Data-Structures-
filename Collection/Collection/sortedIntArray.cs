

namespace Collection
{
    class sortedIntArray : IntArray
    {
        public override int this[int index]
        {
            set
            {
                if (CanBeInserted(index, value))
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

        private bool CanBeInserted(int index, int element)
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
    }
}
