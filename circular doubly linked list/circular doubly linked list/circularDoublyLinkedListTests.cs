
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
        public void ThrowExceptionWhenElementIsNotInListAndTryToRemovingIt()
        {
            var list = new CircularDoublyLinkedList<string>();
            list.Add("yes");
            list.Add("Hello World");
            list.Add("no");
            Assert.Throws<ArgumentNullException>(() => list.Remove("maybe"));
        }

        [Fact]
        public void AddBeforeANodeWhichDoesntExist()
        {
            var list = new CircularDoublyLinkedList<string>();
            list.Add("yes");
            list.Add("Hello World");
            list.Add("no");
            var node = new Node<string>("sure");
            Assert.Throws<InvalidOperationException>(() => list.AddBefore(node, "maybe"));
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
        public void AddNodeAsFirstElementUsingAddBefore()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            var beforeNode = list.First;
            list.AddBefore(beforeNode, 0);
            Assert.Equal(3, list.Count);
            var enumerator = list.GetEnumerator();
            int[] items = new[] { 0, 1, 2 };
            Assert.Equal(items, list);
        }

        [Fact]
        public void AddNodeAsSecondElementUsingAddBefore()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var beforeNode = list.Find(2);
            list.AddBefore(beforeNode, new Node<int>(4));
            Assert.Equal(4, list.Count);
            var enumerator = list.GetEnumerator();
            int[] items = new[] { 1, 4, 2, 3 };
            Assert.Equal(items, list);
        }

        [Fact]
        public void AddLastInAListOfStrings()
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
        public void AddFirstInAListOfStrings()
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
        public void AddFirstInAListOfFloat()
        {
            var list = new CircularDoublyLinkedList<double>();
            list.Add(0.12);
            list.Add(0.47);
            list.Add(5.6);
            list.AddFirst(new Node<double>(23));
            Assert.Equal(4, list.Count);
            var enumerator = list.GetEnumerator();
            double[] items = new[] { 23, 0.12, 0.47, 5.6 };
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

        [Fact]
        public void ThrowExceptionWhenArrayLengthIsSmallerThanCount()
        {
            var list = new CircularDoublyLinkedList<string>();
            list.Add("yes");
            list.Add("Hello World");
            list.Add("no");
            Assert.Throws<ArgumentException>(() => list.CopyTo(new string[3], 2));
        }

        [Fact]
        public void AddValueAfterASpecificNode()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var afterNode = list.Find(2);
            list.AddAfter(afterNode, 1);
            var enumerator = list.GetEnumerator();
            int[] items = new[] { 1, 2, 1, 3 };
            Assert.Equal(items, list);
        }

        [Fact]
        public void AddNodeAfterASpecificNode()
        {
            var list = new CircularDoublyLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var afterNode = list.Find(1);
            list.AddAfter(afterNode, new Node<int>(4));
            var enumerator = list.GetEnumerator();
            int[] items = new[] { 1, 4, 2, 3 };
            Assert.Equal(items, list);
        }

        [Fact]
        public void AddANodeWhichBelongsToAnotherLinkedList()
        {
            var list = new CircularDoublyLinkedList<string>();
            list.Add("yes");
            list.Add("Hello World");
            list.Add("no");
            var secondList = new CircularDoublyLinkedList<string>();
            secondList.Add("maybe");
            secondList.Add("sure");
            var newNode = list.Find("Hello World");
            var beforeNode = secondList.Find("sure");
            Assert.Throws<InvalidOperationException>(() => secondList.AddBefore(beforeNode, newNode));
        }
    }
}