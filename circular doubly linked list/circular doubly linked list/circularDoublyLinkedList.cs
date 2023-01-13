﻿using System;
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
                return sentinel.Next == sentinel ? null : sentinel.Next;
            }
        }

        public Node<T> Last
        {
            get
            {
                return sentinel.Previous == sentinel ? null : sentinel.Previous;
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
            var beforeNode = Find(beforeValue);
            if (beforeNode != null)
            {
                LinkTwoNodes(newNode, beforeNode);
                Count++;
            }
        }

        private void LinkTwoNodes(Node<T> first, Node<T> second)
        {
            first.Previous = second.Previous;
            first.Next = second;
            second.Previous.Next = first;
            second.Previous = first;
        }

        public void AddLast(T value)
        {
            Add(value);
        }

        public void AddFirst(T value)
        {
            AddBefore(First.Value, value);
        }

        public void Clear()
        {
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
            Count = 0;
        }

        public Node<T> Find(T value)
        {
            var current = First;
            for (int i = 0; i < Count; i++)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }
                current = current.Next;
            }
            
            return null;
        }

        public Node<T> FindLast(T value)
        {
            var current = Last;
            for (int i = 0; i < Count; i++)
            {
                if (current.Value.Equals(value))
                {
                    return current;
                }
                current = current.Previous;
            }
            return null;
        }

        public bool Contains(T value)
        {
            return Find(value) != null;
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
            var node = Find(Element);
            if (node != null)
            {
                RemoveNode(node);
                return true;
            }
            
            return false;
        }

        private void RemoveNode(Node<T> node)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            Count--;
        }

        public void RemoveFirst()
        {
            Remove(First.Value);
        }

        public void RemoveLast()
        {
            Remove(Last.Value);
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