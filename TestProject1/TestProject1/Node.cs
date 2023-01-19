

namespace Dictionary
{
    class Node<Tkey, TValue>
    {
        public Tkey Key { get; set; }
        public TValue Value { get; set; }
        public int Next { get; set; }

        public Node(Tkey key, TValue value, int next)
        {
            this.Key = key;
            this.Value = value;
            this.Next = next;
        }
    }
}
