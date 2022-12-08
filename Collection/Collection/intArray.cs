
using System;

namespace Collection
{
    class IntArray
    {
        int[] numbers;

	    public IntArray()
        {
            this.numbers = new int[0];
        }

        public void Add(int element)
        {
            Array.Resize(ref numbers, numbers.Length + 1);
            numbers[numbers.Length - 1] = element;
        }

        public int Count()
        {
            return numbers.Length;
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
            ShiftRight(index);
            numbers[index] = element;
        }

        private void ShiftRight(int index)
        {
            Array.Resize(ref numbers, numbers.Length + 1);
            for (int i = numbers.Length - 1; i > index; i--)
            {
                numbers[i] = numbers[i - 1];
            }
        }

        public void Clear()
        {
            numbers = new int[0]; 
        }

        public void Remove(int element)
        {
            int index = FindIndex(element);
            RemoveAt(index);
        }

        private int FindIndex(int element)
        {
            int index = 0;
            while (index < numbers.Length)
            {
                if (numbers[index] == element)
                {
                    break;
                }

                index++;
            }

            return index;
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Array.Resize(ref numbers, numbers.Length - 1);
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
