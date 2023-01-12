
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
    }
}