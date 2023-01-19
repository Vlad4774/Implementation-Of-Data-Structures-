namespace Dictionary
{
    public class DictionaryTests
    {
        [Fact]
        public void TestforAdding2Elements()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5);
            dictionary.Add(1, "one");
            dictionary.Add(2, "two");
            Assert.Equal(2, dictionary.Count);
        }
    }
}