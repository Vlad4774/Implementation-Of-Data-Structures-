using System.Collections;
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

        [Fact]
        public void GetListOfKeys()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(12, "yes");
            dictionary.Add(23, "no");
            dictionary.Add(15, "no");
            var list = dictionary.Keys;
            Assert.Equal(3, list.Count);
            Assert.Contains(12, list);
            Assert.Contains(23, list);
            Assert.Contains(15, list);
            Assert.DoesNotContain(10, list);
        }

        [Fact]
        public void GetListOfValues()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(12, "yes");
            dictionary.Add(23, "no");
            dictionary.Add(15, "maybe");
            var list = dictionary.Values;
            Assert.Equal(3, list.Count);
            Assert.Contains("yes", list);
            Assert.Contains("no", list);
            Assert.Contains("maybe", list);
            Assert.DoesNotContain("sure", list);
        }

        [Fact]
        public void SetAValue()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(12, "yes");
            dictionary.Add(23, "no");
            dictionary.Add(15, "maybe");
            dictionary[15] = "sure";
            Assert.Equal(3, dictionary.Count);
            Assert.Contains("sure", dictionary.Values);
        }

        [Fact]
        public void ContainsTest()
        {
            var dictionary = new Dictionary<int, string>(5);
            dictionary.Add(12, "yes");
            dictionary.Add(23, "no");
            Assert.True(dictionary.Contains(new KeyValuePair<int, string>(12, "yes")));
            Assert.False(dictionary.Contains(new KeyValuePair<int, string>(24, "maybe")));
        }

        [Fact]
        public void AddIntUsingStringAsKey()
        {
            var dictionary = new Dictionary<string, int>(10);
            dictionary.Add("key1", 1);
            dictionary.Add("key2", 2);

            Assert.True(dictionary.ContainsKey("key1"));
            Assert.True(dictionary.ContainsKey("key2"));
            Assert.Equal(1, dictionary["key1"]);
            Assert.Equal(2, dictionary["key2"]);
        }

        [Fact]
        public void TryGetValueShouldReturnTrueIfKeyExists()
        {
            var dictionary = new Dictionary<string, int>(10);
            dictionary.Add("key1", 1);
            var result = dictionary.TryGetValue("key1", out int value);

            Assert.True(result);
            Assert.Equal(1, value);
        }

        [Fact]
        public void TryGetValueShouldReturnFalseIfKeyDoesNotExist()
        {
            var dictionary = new Dictionary<string, int>(10);
            dictionary.Add("key1", 1);
            var result = dictionary.TryGetValue("key2", out int value);

            Assert.False(result);
        }

        [Fact]
        public void RemoveShouldRemoveItemFromDictionary()
        {
            var dictionary = new Dictionary<string, int>(10);
            dictionary.Add("key1", 1);
            dictionary.Add("key2", 2);
            var removed = dictionary.Remove("key1");

            Assert.True(removed);
            Assert.False(dictionary.ContainsKey("key1"));
            Assert.True(dictionary.ContainsKey("key2"));
        }

        [Fact]
        public void AddAndRemoveShouldWork()
        {
            var dictionary = new Dictionary<string, int>(10);
            dictionary.Add("key1", 1);
            dictionary.Add("key2", 2);
            dictionary.Add("key3", 3);
            dictionary.Add("key4", 4);
            dictionary.Add("key5", 5);
            dictionary.Remove("key1");
            dictionary.Remove("key4");
            dictionary.Add("key6", 6);
            dictionary.Add("key7", 7);

            var keys = new List<string>(dictionary.Keys);
            var values = new List<int>(dictionary.Values);
            var expectedKeys = new List<string> { "key7", "key2", "key3", "key6", "key5" };
            var expectedValues = new List<int> { 7, 2, 3, 6, 5 };
            for (int i = 0; i < keys.Count; i++)
            {
                Assert.Equal(expectedKeys[i], keys[i]);
                Assert.Equal(expectedValues[i], values[i]);
            }
        }

        [Fact]
        public void AddThrowsExceptionWhenKeyIsNull()
        {
            var dictionary = new Dictionary<string, int>(10);
            Assert.Throws<ArgumentNullException>(() => dictionary.Add(null, 1));
        }

        [Fact]
        public void AddThrowsExceptionWhenKeyAlreadyExists()
        {
            var dictionary = new Dictionary<string, int>(10);
            dictionary.Add("key", 1);
            Assert.Throws<ArgumentException>(() => dictionary.Add("key", 2));
        }

        [Fact]
        public void RemoveShouldThrowExceptionWhenKeyIsNull()
        {
            var dictionary = new Dictionary<string, int>(10);
            Assert.Throws<ArgumentNullException>(() => dictionary.Remove(null));
        }

        [Fact]
        public void TryGetValueShouldThrowExceptionWhenKeyIsNull()
        {
            var dictionary = new Dictionary<string, int>(10);
            Assert.Throws<ArgumentNullException>(() => dictionary.TryGetValue(null, out var value));
        }
    }
}