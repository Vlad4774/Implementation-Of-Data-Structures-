
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
            GraphIsCyclicIfAddEdgeException(firstIndex, secondIndex);    
            vertexList[firstIndex].adjacencyList.Add(secondVertex);
        }

        public bool ExistEdgeBetween(int firstVertex, int secondVertex)
        {
            return vertexList[firstVertex].adjacencyList.Contains(vertexList[secondVertex].Value)
                || vertexList[secondVertex].adjacencyList.Contains(vertexList[firstVertex].Value);
        }

        public List<T> GetNeighbours(T vertex)
        {
            int index = FindIndexForVertex(vertex);
            return vertexList[index].adjacencyList;
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

        public bool CanReachVertex(int startIndex, int endIndex)
        {
            var visitedVertices = new List<T>();
            var startVertex = vertexList[startIndex].Value;
            var endVertex = vertexList[endIndex].Value;
            return CanReach(startVertex, endVertex, visitedVertices);
        }

        private bool CanReach(T currentVertex, T endVertex, List<T> visitedVertices)
        {
            if (currentVertex.Equals(endVertex))
            {
                return true;
            }

            visitedVertices.Add(currentVertex);
            var neighbours = GetNeighbours(currentVertex);
            foreach (var neighbour in neighbours)
            {
                if (!visitedVertices.Contains(neighbour) && CanReach(neighbour, endVertex, visitedVertices))
                {
                    return true;
                }
            }

            return false;
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

        private void GraphIsCyclicIfAddEdgeException(int firstIndex, int endIndex)
        {
            if (CanReachVertex(firstIndex, endIndex) || CanReachVertex(endIndex, firstIndex))
            {
                throw new ArgumentException("Graph is cyclic");
            }
        }
    } 
}
