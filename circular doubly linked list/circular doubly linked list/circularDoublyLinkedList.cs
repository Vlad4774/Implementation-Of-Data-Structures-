using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace circular_doubly_linked_list
{

    public class CircularDoublyLinkedList<T> : ICollection<T>
    {
        private Node<T> sentinel;

        public CircularDoublyLinkedList()
        {
            sentinel = new Node<T>(default);
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
        }
        public int Count { get; private set; } = 0;

        public Node<T> First 
        { 
            get
            {
               return sentinel.Next;
            }
        }

        public Node<T> Last
        {
            get
            {
                return sentinel.Previous;
            }
        }

        public void Add(T Value)
        {
            var newNode = new Node<T>(Value);
            var sentinelPrevious = sentinel.Previous;
            sentinelPrevious.Next = newNode;
            newNode.Previous = sentinelPrevious;
            newNode.Next = sentinel;
            sentinel.Previous = newNode;
            Count++;
        }

        public void AddBefore(T beforeValue, T value)
        {
            var newNode = new Node<T>(value);
            var current = First;
            for (int i = 0; i < Count; i++)
            {
                if (current.Value.Equals(beforeValue))
                {
                    newNode.Previous = current.Previous;
                    newNode.Next = current;
                    current.Previous.Next = newNode;
                    current.Previous = newNode;
                    Count++;
                    break;
                }
                current = current.Next;
            }
        }

        public void AddLast(T value)
        {
            Add(value);
        }

        public void Clear()
        {
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
            Count = 0;
        }

        public bool Contains(T item)
        {
            Node<T> current = sentinel.Next;
            for(int i = 0; i < Count; i++)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> current = sentinel.Next;
            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool IsReadOnly => false;

        public bool Remove(T Element)
        {
            Node<T> current = sentinel.Next;
            for (int i = 0; i < Count; i++)
            {
                if (current.Value.Equals(Element))
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = sentinel.Next;
            while (current != sentinel)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}