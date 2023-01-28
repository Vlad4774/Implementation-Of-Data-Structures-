
namespace graph
{
    class Graph<T>
    {
        List<Vertex<T>> vertexList;

        public Graph()
        {
            vertexList = new List<Vertex<T>>();
        }

        public int Count { get; private set; } = 0;

        public void AddNewVertex(T value)
        {
            vertexList.Add(new Vertex<T>(value));
            Count++;
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

        public List<T> GetNeighbours(T vertex)
        {
            int index = FindIndexForVertex(vertex);
            return vertexList[index].EdgesToNextVertices;
        }

        public List<T> TogologicalSort()
        {
            List<T> sortedList = new List<T>();
            var visitedVertices = new List<T>();
            for (int i = 0; i < Count; i++)
            {
                if (!visitedVertices.Contains(vertexList[i].Value))
                {
                    Sort(vertexList[i].Value, visitedVertices, sortedList);
                }
            }

            return sortedList;
        }

        private void Sort(T vertex, List<T> visitedVertices, List<T> sortedList)
        {
            visitedVertices.Add(vertex);
            var neighbours = GetNeighbours(vertex);
            foreach (var neighbour in neighbours)
            {
                if (!visitedVertices.Contains(neighbour))
                {
                    Sort(neighbour, visitedVertices, sortedList);
                }
            }

            sortedList.Add(vertex);
        }

        private int FindIndexForVertex(T vertex)
        {
            for (int i = 0; i < Count; i++)
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
