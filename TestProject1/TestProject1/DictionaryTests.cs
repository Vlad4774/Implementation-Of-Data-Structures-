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

        [Fact]
        public void TestContains()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(12, "yes");
            dictionary.Add(23, "no");
            Assert.Equal(2, dictionary.Count);
            Assert.True(dictionary.ContainsKey(23));
            Assert.False(dictionary.ContainsKey(24));
        }

        [Fact]
        public void RemoveElement()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(12, "yes");
            dictionary.Add(23, "no");
            Assert.True(dictionary.Remove(23));
            Assert.Equal(1, dictionary.Count);
            Assert.False(dictionary[23] == "no");
            Assert.False(dictionary.ContainsKey(23));
        }

        [Fact]
        public void RemoveAInexistentElement()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(12, "yes");
            dictionary.Add(23, "no");
            Assert.False(dictionary.Remove(2234));
            Assert.Equal(2, dictionary.Count);
        }
    }
}