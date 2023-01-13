
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
        public void AddBefore_NodeNotFound_DoesNotAddNode()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);

            list.AddBefore(3, 2);

            Assert.Equal(2, list.Count);
            Assert.Equal(1, list.First.Value);
            Assert.Equal(2, list.Last.Value);
        }

    }
}