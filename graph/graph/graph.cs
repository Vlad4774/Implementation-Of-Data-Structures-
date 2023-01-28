
namespace graph
{
    class Graph<T>
    {
        List<Vertex<T>> vertexList;
        int count;

        public Graph()
        {
            vertexList = new List<Vertex<T>>();
            count = 0;
        }

        public void AddNewVertex(T value)
        {
            vertexList.Add(new Vertex<T>(value));
            count++;
        }

        public void AddEdge(T firstVertex, T secondVertex)
        {
            int firstIndex = FindIndexForVertex(firstVertex);
            int secondIndex = FindIndexForVertex(secondVertex);
            ExistAlreadyAEgdeException(firstIndex, secondIndex);
            vertexList[firstIndex].EdgesToNextVertices.Add(secondVertex);
        }

        public bool ExistEdgeBetween(int firstVertex, int secondVertex)
        {
            return vertexList[firstVertex].EdgesToNextVertices.Contains(vertexList[secondVertex].Value)
                || vertexList[secondVertex].EdgesToNextVertices.Contains(vertexList[firstVertex].Value);
        }

        private int FindIndexForVertex(T vertex)
        {
            for (int i = 0; i < count; i++)
            {
                if (vertex.Equals(vertexList[i].Value))
                {
                    return i;
                }
            }

            throw new ArgumentException("Vertex doesnt exist");
        }

        private void ExistAlreadyAEgdeException(int firstIndex, int secondIndex)
        {
            if (ExistEdgeBetween(firstIndex, secondIndex))
            {
                throw new ArgumentException("A edge between vertices already exist");
            }
        }
    } 
}
