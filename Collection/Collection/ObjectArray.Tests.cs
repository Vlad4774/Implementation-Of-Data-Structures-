
namespace Collection
{
    public class ObjectArrayTests
    {
        [Fact]
        public void AddStringAndNumber()
        {
            var array = new ObjectArray();
            array.Add(23);
            array.Add("text");
            Assert.Equal(2, array.Count);
        }

        [Theory]
        [InlineData(67, true)]
        [InlineData(false, true)]
        [InlineData("text", true)]
        [InlineData(23.32, true)]
        [InlineData(13, false)]
        public void ContainsElement(object element, bool result)
        {
            var array = new ObjectArray();
            array.Add(67);
            array.Add("text");
            array.Add(false);
            array.Add(23.32);
            Assert.Equal(result, array.Contains(element));
        }
    }
}
