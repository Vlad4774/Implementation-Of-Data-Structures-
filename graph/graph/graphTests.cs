using System.Collections.Generic;

namespace graph
{
    public class graphTests
    {
        [Fact]
        public void AddEdgesInAGraphWith3Vertex()
        {
            var graph = new Graph(5);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            Assert.True(graph.ExistEdgeBetween(0, 1));
            Assert.True(graph.ExistEdgeBetween(0, 2));
            Assert.False(graph.ExistEdgeBetween(1, 2));
        }

        [Fact]
        public void ThrowsExceptionWhenNumberOfVertexAreNotValid()
        {
            Assert.Throws<ArgumentException>(() => new Graph(-1));
        }

        [Fact]
        public void ThrowsExceptionWhenTryToAddAEdgeBetween2VertexThatAlreadyHaveAEdge()
        {
            var graph = new Graph(5);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            Assert.Throws<ArgumentException>(() => graph.AddEdge(1, 0));
        }

        [Fact]
        public void AddANexVertexAfterICreatedTheGraph()
        {
            var graph = new Graph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddNewVertex();
            graph.AddEdge(4, 0);
            Assert.True(graph.ExistEdgeBetween(4, 0));
        }
    }
}