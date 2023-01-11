﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace circular_doubly_linked_list
{

    public class CircularDoublyLinkedList<T> : ICollection<T>
    {
        private Node<T> head = null;
        private Node<T> tail = null;
        public int Count { get; private set; } = 0;

        public void Add(T Value)
        {
            var newNode = new Node<T>(Value);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                head.Next = head;
                head.Previous = head;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                newNode.Next = head;
                head.Previous = newNode;
                tail = newNode;
            }

            Count++;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var current = head;
            do
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;

            } while (current != head);

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = head;
            do
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;

            } while (current != head);
        }

        public bool IsReadOnly => false;

        public bool Remove(T Element)
        {
            var current = head;
            do
            {
                if (current.Value.Equals(Element))
                {
                    if (current == head)
                    {
                        head = head.Next;
                    }
                    if (current == tail)
                    {
                        tail = tail.Previous;
                    }
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    Count--;
                    return true;
                }

                current = current.Next;

            } while (current != head);

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            do
            {
                yield return current.Value;
                current = current.Next;
            } while (current != head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}