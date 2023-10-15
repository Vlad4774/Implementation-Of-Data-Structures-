namespace Collection
{
    public class IntArrayTests
    {
        [Fact]
        public void AddNumber()
        {
            var array = new IntArray();
            array.Add(10);
            Assert.True(array.Contains(10));
        }

        [Fact]
        public void AddNumbers() 
        {
            var array = new IntArray();
            array.Add(7);
            array.Add(23);
            Assert.Equal(1, array.IndexOf(23));
        }

        [Fact]
        public void LengthIfArrayIsEmpty()
        {
            var array = new IntArray();
            Assert.Equal(0, array.Count);
        }

        [Fact]
        public void LengthIfArrayHaveNumbers()
        {
            var array = new IntArray();
            array.Add(7);
            array.Add(23);
            array.Add(1);
            Assert.Equal(3, array.Count);
        }

        [Fact]
        public void ElementFromPosition()
        {
            var array = new IntArray();
            array.Add(7);
            array.Add(23);
            array.Add(1);
            Assert.Equal(1, array[2]);
        }

        [Theory]
        [InlineData(2, 34)]
        [InlineData(1, 12)]
        [InlineData(0, 50)]
        public void SetElementFromPosition(int index, int element)
        {
            var array = new IntArray();
            array.Add(7);
            array.Add(23);
            array.Add(1);
            array[index] = element;
            Assert.Equal(element, array[index]);
        }

        [Theory]
        [InlineData(67, true)]
        [InlineData(23, true)]
        [InlineData(13, false)]
        [InlineData(97, false)]
        public void ContainsElement(int element, bool result)
        {
            var array = new IntArray();
            array.Add(7);
            array.Add(23);
            array.Add(1);
            array.Add(67);
            array.Add(12);
            Assert.Equal(result, array.Contains(element));
        }

        [Theory]
        [InlineData(67, 3)]
        [InlineData(23, 1)]
        [InlineData(13, -1)]
        [InlineData(97, -1)]
        public void IndexOfElement(int element, int index)
        {
            var array = new IntArray();
            array.Add(7);
            array.Add(23);
            array.Add(1);
            array.Add(67);
            array.Add(12);
            Assert.Equal(index, array.IndexOf(element));
        }

        [Theory]
        [InlineData(67, 3)]
        [InlineData(23, 1)]
        [InlineData(13, 2)]
        [InlineData(97, 0)]
        public void InsertElement(int element, int index)
        {
            var array = new IntArray();
            array.Add(7);
            array.Add(23);
            array.Add(1);
            array.Add(67);
            array.Insert(index, element);
            Assert.Equal(index, array.IndexOf(element));
        }

        [Fact]
        public void ClearArray()
        {
            var array = new IntArray();
            array.Add(7);
            array.Add(23);
            array.Add(1);
            array.Add(67);
            array.Clear();
            Assert.Equal(0, array.Count);
        }

        [Theory]
        [InlineData(67)]
        [InlineData(23)]
        [InlineData(1)]
        [InlineData(7)]
        public void RemoveElement(int element)
        {
            var array = new IntArray();
            array.Add(7);
            array.Add(23);
            array.Add(1);
            array.Add(67);
            array.Remove(element);
            Assert.Equal(3, array.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void RemoveElementFromIndex(int index)
        {
            var array = new IntArray();
            array.Add(7);
            array.Add(23);
            array.Add(1);
            array.Add(67);
            array.RemoveAt(index);
            Assert.Equal(3, array.Count);
        }
    }
}