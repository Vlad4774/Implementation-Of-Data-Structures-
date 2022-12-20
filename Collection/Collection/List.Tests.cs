

namespace Collection
{
    public class ListTests
    {
        [Fact]
        public void AddElements()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.Equal(3, list.Count);
            Assert.True(list.Contains(3));
        }

        [Fact]
        public void InsertElements()
        {
            var list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Insert(1, "4");
            Assert.Equal("4", list[1]);
        }

        [Fact]
        public void CountIfIsAEmpty()
        {
            var list = new List<string>();
            Assert.Equal(0, list.Count);
        }

        [Theory]
        [InlineData(2, 34)]
        [InlineData(1, 12)]
        [InlineData(0, 50)]
        public void SetElementFromPosition(int index, int element)
        {
            var list = new List<int>();
            list.Add(7);
            list.Add(23);
            list.Add(1);
            list[index] = element;
            Assert.Equal(element, list[index]);
        }

        [Fact]
        public void IndexIsNotInRange()
        {
            var list = new List<int>();
            list.Add(7);
            list.Add(23);
            list.Add(1);
            Assert.Throws<IndexOutOfRangeException>(() => list.Insert(7,3));
        }

        [Fact]
        public void ArrayIsNull()
        {
            var list = new List<int>();
            list.Add(7);
            list.Add(23);
            list.Add(1);
            int[] array = null;
            Assert.Throws<ArgumentNullException>(() => list.CopyTo(array, 2));
        }

        [Fact]
        public void NotEnoughCapacity()
        {
            var list = new List<int>();
            list.Add(7);
            list.Add(23);
            list.Add(1);
            int[] array = new int[4];
            Assert.Throws<ArgumentException>(() => list.CopyTo(array, 2));
        }

        [Fact]
        public void ThrowsExceptionAtRemoveAt()
        {
            var list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(4));
        }

        [Fact]
        public void ThrowsExceptionAtThis()
        {
            var list = new List<char>();
            list.Add('a');
            list.Add('c');
            list.Add('d');
            Assert.Throws<IndexOutOfRangeException>(() => list[4]);
        }
    }
}
