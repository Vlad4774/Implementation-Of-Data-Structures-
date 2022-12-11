
namespace Collection
{
    class ObjectArray
    {
        protected object[] numbers;

        public ObjectArray()
        {
            this.numbers = new object[4];
        }

        public void Add(object element)
        {
            EnoughCapacity();
            numbers[Count] = element;
            Count++;
        }

        private void EnoughCapacity()
        {
            if (numbers.Length == Count)
            {
                Array.Resize(ref numbers, numbers.Length * 2);
            }
        }

        public int Count { get; private set; } = 0;

        public object this[int index]
        {
            get => numbers[index];
            set => numbers[index] = value;
        }

        public bool Contains(object element)
        {
            return IndexOf(element) >= 0;
        }

        public int IndexOf(object element)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].Equals(element))
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
            numbers[index] = element;
            Count++;
        }

        private void ShiftRight(int index)
        {
            for (int i = numbers.Length - 1; i > index; i--)
            {
                numbers[i] = numbers[i - 1];
            }
        }

        public void Clear()
        {
            numbers = new object[4];
            Count = 0;
        }

        public void Remove(object element)
        {
            int index = FindIndex(element);
            RemoveAt(index);
        }

        private int FindIndex(object element)
        {
            for (int index = 0; index < numbers.Length; index++)
            {
                if (numbers[index] == element)
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
            for (int i = numbers.Length - 1; i > index; i--)
            {
                numbers[i - 1] = numbers[i];
            }
        }
    }
}
