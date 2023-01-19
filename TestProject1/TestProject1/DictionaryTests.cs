using System.Collections.Generic;

namespace Dictionary
{
    public class DictionaryTests
    {
        [Fact]
        public void TestforAdding2Elements()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(12, "one");
            dictionary.Add(23, "two");
            Assert.Equal(2, dictionary.Count);
            Assert.Equal("one", dictionary[12]);
            Assert.Equal("two", dictionary[23]);
        }
    }
}