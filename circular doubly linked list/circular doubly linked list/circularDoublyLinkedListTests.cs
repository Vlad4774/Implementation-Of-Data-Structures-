
using Xunit;

namespace circular_doubly_linked_list
{
    public class CircularDoublyLinkedListTests
    {
        [Fact]
        public void AddIncreaseCount()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.Equal(3, list.Count);
        }

        [Fact]
        public void TestClear()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Clear();
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void ContainsElement()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.True(list.Contains(2));
        }

        [Fact]
        public void DoesntContainsElement()
        {
            var list = new CircularDoublyLinkedList<string>();
            list.Add("yes");
            list.Add("Hello World");
            list.Add("no");
            Assert.False(list.Contains("maybe"));
        }

        [Fact]
        public void RemoveElement()
        {
            var list = new CircularDoublyLinkedList<string>();
            list.Add("yes");
            list.Add("Hello World");
            list.Add("no");
            Assert.True(list.Remove("yes"));
        }

        [Fact]
        public void ReturningFalseWhenElementIsNotInListAndTryToRemovingIt()
        {
            var list = new CircularDoublyLinkedList<string>();
            list.Add("yes");
            list.Add("Hello World");
            list.Add("no");
            Assert.False(list.Remove("maybe"));
        }

        [Fact]
        public void GetEnumeratorTestForCaseOf3Elements()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var enumerator = list.GetEnumerator();
            int[] items = new[] { 1, 2, 3 };
            Assert.Equal(items, list);
        }

        [Fact]
        public void FirstReturnFirstNode()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.Equal(1, list.First.Value);
        }

        [Fact]
        public void LastReturnLastNode()
        {
            var list = new CircularDoublyLinkedList<string>();
            list.Add("yes");
            list.Add("Hello World");
            list.Add("no");

            Assert.Equal("no", list.Last.Value);
        }

        [Fact]
        public void AddBeforeAddsNodeCorrectlyAsFirstElement()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.AddBefore(1, 0);
            Assert.Equal(3, list.Count);
            var enumerator = list.GetEnumerator();
            int[] items = new[] { 0, 1, 2 };
            Assert.Equal(items, list);
        }

        [Fact]
        public void AddBeforeNodeNotExist()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.AddBefore(3, 2);
            Assert.Equal(2, list.Count);
            Assert.Equal(1, list.First.Value);
            Assert.Equal(2, list.Last.Value);
        }

        [Fact]
        public void AddLastWorks()
        {
            var list = new CircularDoublyLinkedList<string>();
            list.Add("yes");
            list.Add("Hello World");
            list.Add("no");
            list.AddLast("maybe");
            Assert.Equal(4, list.Count);
            Assert.Equal("maybe", list.Last.Value);
        }

        [Fact]
        public void AddFirstWorks()
        {
            var list = new CircularDoublyLinkedList<string>();
            list.Add("yes");
            list.Add("Hello World");
            list.Add("no");
            list.AddFirst("maybe");
            Assert.Equal(4, list.Count);
            var enumerator = list.GetEnumerator();
            string[] items = new[] { "maybe", "yes", "Hello World", "no" };
            Assert.Equal(items, list);
        }

        [Fact]
        public void FindReturnsCorrectNode()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var node = list.Find(2);

            Assert.Equal(2, node.Value);
            Assert.Equal(3, node.Next.Value);
            Assert.Equal(1, node.Previous.Value);
        }

        [Fact]
        public void FindValueNotFoundReturnsNull()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            
            var node = list.Find(4);

            Assert.Null(node);
        }

        [Fact]
        public void FindLastReturnsCorrectNode()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(2);
            list.Add(3);

            var node = list.FindLast(2);

            Assert.Equal(2, node.Value);
            Assert.Equal(3, node.Next.Value);
            Assert.Equal(2, node.Previous.Value);
        }

        [Fact]
        public void FindLastValueNotFoundReturnsNull()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            var node = list.FindLast(4);

            Assert.Null(node);
        }

        [Fact]
        public void RemoveFirstRemovesCorrectNode()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.RemoveFirst();

            Assert.Equal(2, list.Count);
            Assert.Equal(2, list.First.Value);
            Assert.Equal(3, list.Last.Value);
        }

        [Fact]
        public void RemoveLastRemovesCorrectNode()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.RemoveLast();

            Assert.Equal(2, list.Count);
            Assert.Equal(1, list.First.Value);
            Assert.Equal(2, list.Last.Value);
        }

    }
}