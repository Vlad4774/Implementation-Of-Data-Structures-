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

        public void Add(T Value)
        {
            var newNode = new Node<T>(Value);
            if (Count == 0)
            {
                sentinel.Next = newNode;
                sentinel.Previous = newNode;
                newNode.Next = sentinel;
                newNode.Previous = sentinel;
            }
            else
            {
                var sentinelPrevious = sentinel.Previous;
                sentinelPrevious.Next = newNode;
                newNode.Previous = sentinelPrevious;
                newNode.Next = sentinel;
                sentinel.Previous = newNode;
            }

            Count++;
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
            while (current != sentinel)
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
            while (current != sentinel)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool IsReadOnly => false;

        public bool Remove(T Element)
        {
            Node<T> current = sentinel.Next;
            while (current != sentinel)
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