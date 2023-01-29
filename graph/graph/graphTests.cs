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
            Assert.Equal(3, graph.Count);
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

        [Fact]
        public void ReturnsNeighboursCorrectly()
        {
            var graph = new Graph<int>();
            graph.AddNewVertex(0);
            graph.AddNewVertex(1);
            graph.AddNewVertex(2);
            graph.AddNewVertex(3);
            graph.AddNewVertex(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            var neighbours = graph.GetNeighbours(0);
            Assert.Equal(1, neighbours[0]);
            Assert.Equal(2, neighbours[1]);
            Assert.Equal(3, neighbours[2]);
        }

        [Fact]
        public void TopologicalSortWorksCorrectlyInASimpleCase()
        {
            var graph = new Graph<int>();
            graph.AddNewVertex(0);
            graph.AddNewVertex(1);
            graph.AddNewVertex(2);
            graph.AddNewVertex(3);
            graph.AddNewVertex(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 4);
            graph.AddEdge(2, 3);
            var sortedList = graph.TogologicalSort();
            Assert.Equal(1, sortedList[0]);
            Assert.Equal(3, sortedList[1]);
            Assert.Equal(2, sortedList[2]);
            Assert.Equal(4, sortedList[3]);
            Assert.Equal(0, sortedList[4]);
        }

        [Fact]
        public void TopologicalSortWorksCorrectlyInAComplexCase()
        {
            var graph = new Graph<int>();
            for (int i = 1; i <= 8; i++)
            {
                graph.AddNewVertex(i);
            }
            
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 6);
            graph.AddEdge(3, 7);
            graph.AddEdge(4, 8);
            graph.AddEdge(5, 8);
            graph.AddEdge(6, 8);
            graph.AddEdge(7, 8);

            var sortedList = graph.TogologicalSort();
            Assert.Equal(new List<int> { 8, 4, 5, 2, 6, 7, 3, 1 }, sortedList);
        }

        [Fact]
        public void CanReachTest()
        {
            var graph = new Graph<int>();
            graph.AddNewVertex(0);
            graph.AddNewVertex(1);
            graph.AddNewVertex(2);
            graph.AddNewVertex(3);
            graph.AddNewVertex(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            Assert.True(graph.CanReachVertex(0, 3));
            Assert.False(graph.CanReachVertex(0, 4));
        }

        [Fact]
        public void DetectsAcycleConsistingOf4Vertices()
        {
            var graph = new Graph<int>();
            graph.AddNewVertex(0);
            graph.AddNewVertex(1);
            graph.AddNewVertex(2);
            graph.AddNewVertex(3);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            Assert.Throws<ArgumentException>(() => graph.AddEdge(3, 0));
        }

        [Fact]
        public void DetectsAcycleInAComplexGraph()
        {
            var graph = new Graph<int>();
            graph.AddNewVertex(0);
            graph.AddNewVertex(1);
            graph.AddNewVertex(2);
            graph.AddNewVertex(3);
            graph.AddNewVertex(4);
            graph.AddNewVertex(5);
            graph.AddNewVertex(6);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(0, 6);
            graph.AddEdge(1, 5);
            graph.AddEdge(5, 6);
            Assert.Throws<ArgumentException>(() => graph.AddEdge(4, 2));
        }
    }
}