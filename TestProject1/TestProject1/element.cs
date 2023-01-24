

namespace Dictionary
{
    class Element<Tkey, TValue>
    {
        public Tkey Key { get; set; }
        public TValue Value { get; set; }
        public int Next { get; set; }

        public Element(Tkey key, TValue value, int next)
        {
            this.Key = key;
            this.Value = value;
            this.Next = next;
        }
    }
}
