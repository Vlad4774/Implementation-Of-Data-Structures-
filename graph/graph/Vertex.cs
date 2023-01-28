
namespace graph
{
    class Vertex<T>
    {
        public T Value { get; set; }
        public List<T> EdgesToNextVertices { get; set; }

        public Vertex(T value)
        {
            Value = value;
            EdgesToNextVertices = new List<T>();
        }
    }
}
