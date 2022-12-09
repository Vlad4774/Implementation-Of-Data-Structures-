
using System;

namespace Collection
{
    class IntArray
    {
        int[] numbers;
        int count;

	    public IntArray()
        {
            this.numbers = new int[4];
            this.count = 0;
        }

        public void Add(int element)
        {
            EnoughCapacity();
            numbers[count] = element;
            count++;
        }

        private void EnoughCapacity()
        {
            if (numbers.Length == count)
            {
                Array.Resize(ref numbers, numbers.Length * 2);
            }
        }

        public int Count()
        {
            return count;
        }

        public int Element(int index)
        {
            return numbers[index];
        }

        public void SetElement(int index, int element)
        {
            numbers[index] = element;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) >= 0;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            EnoughCapacity();
            ShiftRight(index);
            numbers[index] = element;
            count++;
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
            numbers = new int[4];
            count = 0;
        }

        public void Remove(int element)
        {
            int index = FindIndex(element);
            RemoveAt(index);
        }

        private int FindIndex(int element)
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
            count--;
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
