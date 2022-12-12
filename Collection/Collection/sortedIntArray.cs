

namespace Collection
{
    class sortedIntArray : IntArray
    {
        public override int this[int index]
        {
            get => base[index];
            set
            {
                base[index] = value;
            }
        }

        public override void Add(int element)
        {
            if (Count == 0 || element >= this[Count - 1])
            {
                base.Insert(Count, element);
            }
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    if (element <= this[i])
                    {
                        base.Insert(i, element);
                        break;
                    }
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
            return element >= this[index - 1] && element <= this[index + 1];
        }
    }
}
