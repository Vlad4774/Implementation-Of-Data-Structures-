using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Xunit.Sdk;

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
            NullException(Value);

            var newNode = new Node<T>(Value);
            LinkTwoNodes(newNode, sentinel);
            Count++;
        }

        public void AddBefore(Node<T> beforeNode, T value)
        {
            NullException(beforeNode.Value);
            NullException(value);
            NodeNotInTheListException(beforeNode.Value);

            var newNode = new Node<T>(value);
            LinkTwoNodes(newNode, beforeNode);
            Count++;
        }

        public void AddBefore(Node<T> beforeNode, Node<T> newNode)
        {
            NullException(beforeNode.Value);
            NullException(newNode.Value);
            NodeNotInTheListException(beforeNode.Value);

            LinkTwoNodes(newNode, beforeNode);
            Count++;
        }

        public void AddAfter(Node<T> afterNode, T value)
        {
            NullException(afterNode.Value);
            NullException(value);
            NodeNotInTheListException(afterNode.Value);

            var newNode = new Node<T>(value);
            LinkTwoNodes(newNode, afterNode.Next);
            Count++;
        }

        public void AddAfter(Node<T> afterNode, Node<T> newNode)
        {
            NullException(afterNode.Value);
            NullException(newNode.Value);
            NodeNotInTheListException(afterNode.Value);

            LinkTwoNodes(newNode, afterNode.Next);
            Count++;
        }

        public void AddLast(T value)
        {
            AddAfter(Last, value);
        }

        public void AddLast(Node<T> value)
        {
            AddAfter(Last, value);
        }

        public void AddFirst(T value)
        {
            AddBefore(First, value);
        }

        public void AddFirst(Node<T> newNode)
        {
            AddBefore(First, newNode);
        }

        private void LinkTwoNodes(Node<T> first, Node<T> second)
        {
            first.Previous = second.Previous;
            first.Next = second;
            second.Previous.Next = first;
            second.Previous = first;
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
            InvalidIndexException(arrayIndex);
            ArrayNullException(array);
            NotEnoughCapacityException(array.Length, arrayIndex);
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
            NullException(Element);
            NodeNotInTheListException(Element);

            var node = Find(Element);
            RemoveNode(node);
            return true;
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

        private void NullException(T Value)
        {
            if (Value == null)
            {
                throw new ArgumentNullException();
            }
        }

        private void NotEnoughCapacityException(int lengthArray, int arrayIndex)
        {
            if (lengthArray - arrayIndex < Count)
            {
                throw new ArgumentException("NotEnoughCapacity");
            }
        }

        private void ArrayNullException(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array Is Null");
            }
        }

        private void InvalidIndexException(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Index is invalid");
            }
        }

        private void NodeNotInTheListException(T value)
        {
            if (!Contains(value))
            {
                throw new ArgumentException("Node is not in the list");
            }
        }
    }
}