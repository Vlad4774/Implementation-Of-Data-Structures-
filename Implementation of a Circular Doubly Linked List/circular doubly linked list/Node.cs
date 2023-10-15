using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circular_doubly_linked_list
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; internal set; }

        public Node<T> Next { get; internal set; }

        public CircularDoublyLinkedList<T>  List { get; internal set; }

        public Node<T> Previous { get; internal set; }
    }
}
