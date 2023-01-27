

namespace graph
{
    class Graph
    {
        List<int>[] vertexList;
        
        public Graph(int numberOfVertex)
        {
            NumberOfVertexIsValid(numberOfVertex);
            vertexList = new List<int>[numberOfVertex];
            for (int i = 0; i < numberOfVertex; i++)
            {
                vertexList[i] = new List<int>();
            }
        }

        public void AddEdge(int firstVertex, int secondVertex)
        {
            ExistAlreadyAEgde(firstVertex, secondVertex);
            VertexIsValid(firstVertex);
            VertexIsValid(secondVertex);
            vertexList[firstVertex].Add(secondVertex);
        }
        
        public bool ExistEdgeBetween(int firstVertex, int secondVertex)
        {
            VertexIsValid(firstVertex);
            VertexIsValid(secondVertex);
            return vertexList[firstVertex].Contains(secondVertex) || vertexList[secondVertex].Contains(firstVertex);
        }

        private void NumberOfVertexIsValid(int node)
        {
            if (node < 0)
            {
                throw new ArgumentException("Node is not valid");
            }
        }

        private void ExistAlreadyAEgde(int firstVertex, int secondVertex)
        {
            if (vertexList[firstVertex].Contains(secondVertex) || vertexList[secondVertex].Contains(firstVertex))
            {
                throw new ArgumentException("Edge already exist");
            }
        }

        private void VertexIsValid(int vertex)
        {
            if (vertex < 0 || vertex >= vertexList.Length)
            {
                throw new ArgumentException("Vertex is not valid");
            }
        }
    }
}
