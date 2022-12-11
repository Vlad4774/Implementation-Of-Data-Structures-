
namespace Collection
{
    public class sortedIntArrayTests
    {
        [Fact]
        public void Sort2Numbers()
        {
            var array = new sortedIntArray();
            array.Add(23);
            array.Add(7);
            array.Sort();
            Assert.Equal(1, array.IndexOf(23));
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(7, 1)]
        [InlineData(9, 2)]
        [InlineData(23, 3)]
        [InlineData(71, 4)]
        [InlineData(78, 5)]
        public void SortManyNumbers(int number, int index)
        {
            var array = new sortedIntArray();
            array.Add(23);
            array.Add(7);
            array.Add(78);
            array.Add(71);
            array.Add(1);
            array.Add(9);
            array.Sort();
            Assert.Equal(index, array.IndexOf(number));
        }
    }
}
