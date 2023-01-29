
namespace graph
{
    class Vertex<T>
    {
        public T Value { get; set; }
        public List<T> adjacencyList { get; set; }

        public Vertex(T value)
        {
            Value = value;
            adjacencyList = new List<T>();
        }
    }
}
