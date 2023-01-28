using System.Collections.Generic;

namespace graph
{
    public class graphTests
    {
        [Fact]
        public void AddEdgesInAGraphWith3Vertex()
        {
            var graph = new Graph<int>();
            graph.AddNewVertex(0);
            graph.AddNewVertex(1);
            graph.AddNewVertex(2);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            Assert.True(graph.ExistEdgeBetween(0, 1));
            Assert.True(graph.ExistEdgeBetween(0, 2));
            Assert.False(graph.ExistEdgeBetween(1, 2));
        }

        [Fact]
        public void ThrowsExceptionWhenTryToAddAEdgeBetween2VertexThatAlreadyHaveAEdge()
        {
            var graph = new Graph<int>();
            graph.AddNewVertex(0);
            graph.AddNewVertex(1);
            graph.AddNewVertex(2);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            Assert.Throws<ArgumentException>(() => graph.AddEdge(1, 0));
        }

        [Fact]

        public void ThrowsExceptionWhenTryToAddAEdgeBetween2VertexThatDoesntExist()
        {
            var graph = new Graph<int>();
            graph.AddNewVertex(0);
            graph.AddNewVertex(1);
            graph.AddNewVertex(2);
            Assert.Throws<ArgumentException>(() => graph.AddEdge(1, 3));
        }
    }
}