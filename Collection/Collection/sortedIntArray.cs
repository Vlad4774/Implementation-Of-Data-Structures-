

using Newtonsoft.Json.Linq;

namespace Collection
{
    class sortedIntArray : IntArray
    {
        public override int this[int index]
        {
            set
            {
                if (ElementOrDefault(index - 1, value) <= value && value <= ElementOrDefault(index + 1, value))   
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
            if (index > 0 && index < Count - 1)
            {
                if (ElementOrDefault(index - 1, element) > element || element > ElementOrDefault(index, element))
                {
                    return;
                }
            }
            else if (index > 0)
            {
                if (element > ElementOrDefault(index, element))
                {
                    return;
                }
            }

            if (ElementOrDefault(index - 1, element) > element)
            {
                return;
            }
        }

        private int ElementOrDefault(int index, int defaultValue)
        {
            return index >= 0 && index < Count ? this[index] : defaultValue;
        }
    }
}
