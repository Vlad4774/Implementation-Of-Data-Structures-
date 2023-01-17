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

        public void Add(T value)
        {
            AddLast(new Node<T>(value));
        }

        public void AddBefore(Node<T> beforeNode, T value)
        {
            var newNode = new Node<T>(value);
            AddBefore(beforeNode, newNode);
        }

        public void AddBefore(Node<T> beforeNode, Node<T> newNode)
        {
            NullException(beforeNode);
            NullException(newNode);
            NodeNotInTheListException(beforeNode);
            NodeBelongsToAnotherListException(newNode);
            newNode.Previous = beforeNode.Previous;
            newNode.Next = beforeNode;
            beforeNode.Previous.Next = newNode;
            beforeNode.Previous = newNode;
            Count++;
        }

        public void AddAfter(Node<T> afterNode, T value)
        {
            var newNode = new Node<T>(value);
            AddBefore(afterNode.Next, newNode);
        }

        public void AddAfter(Node<T> afterNode, Node<T> newNode)
        {
            AddBefore(afterNode.Next, newNode);
        }

        public void AddLast(T value)
        {
            AddAfter(sentinel.Previous, value);
        }

        public void AddLast(Node<T> value)
        {
            AddAfter(sentinel.Previous, value);
        }

        public void AddFirst(T value)
        {
            AddBefore(sentinel.Next, value);
        }

        public void AddFirst(Node<T> newNode)
        {
            AddBefore(sentinel.Next, newNode);
        }

        public void Clear()
        {
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
            Count = 0;
        }

        public Node<T> Find(T value)
        {
            for (Node<T> node = sentinel.Next; node != sentinel; node = node.Next)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }

            return null;
        }

        public Node<T> FindLast(T value)
        {
            var current = Last;
            for (Node<T> node = sentinel.Previous; node != sentinel; node = node.Previous)
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

        public bool Remove(T value)
        {
            var node = Find(value);
            NullException(node);
            NodeNotInTheListException(node);
            if (node == sentinel)
            {
                return false;
            }

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
            Remove(sentinel.Next.Value);
        }

        public void RemoveLast()
        {
            Remove(sentinel.Previous.Value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = sentinel.Next;
            for (int i = 0; i < Count; i++)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void NullException(Node<T> node)
        {
            if (node == null)
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

        private void NodeNotInTheListException(Node<T> node)
        {
            if (node.Next == null || node.Previous == null)
            {
                throw new InvalidOperationException("Node is not in the list");
            }
        }

        private void NodeBelongsToAnotherListException(Node<T> node)
        {
            if (node.Next != null || node.Previous != null)
            {
                throw new InvalidOperationException("Node belongs to another list");
            }
        }
    }
}