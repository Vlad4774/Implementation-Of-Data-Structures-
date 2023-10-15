

using System;

namespace Collection
{
    public class sortedListTests
    {
        [Fact]
        public void Sort2Numbers()
        {
            var array = new SortedList<int>();
            array.Add(23);
            array.Add(7);
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
            var array = new SortedList<int>();
            array.Add(23);
            array.Add(7);
            array.Add(78);
            array.Add(71);
            array.Add(1);
            array.Add(9);
            Assert.Equal(index, array.IndexOf(number));
        }

        [Fact]
        public void InsertOneNumber()
        {
            var array = new SortedList<int>();
            array.Insert(0, 1);
            Assert.Equal(0, array.IndexOf(1));
        }

        [Fact]
        public void InsertTwoNumbers()
        {
            var array = new SortedList<int>();
            array.Insert(0, 1);
            array.Insert(1, 7);
            Assert.Equal(1, array.IndexOf(7));
        }

        [Fact]
        public void InsertNumberInAExistingArray()
        {
            var array = new SortedList<int>();
            array.Add(23);
            array.Add(78);
            array.Add(71);
            array.Insert(0, 7);
            Assert.Equal(0, array.IndexOf(7));
        }

        [Fact]
        public void Sort2Strings()
        {
            var array = new SortedList<string>();
            array.Add("ac");
            array.Add("aa");
            Assert.Equal(0, array.IndexOf("aa"));
        }

        [Theory]
        [InlineData(0, "aaa")]
        [InlineData(1, "ada")]
        [InlineData(2, "bca")]
        [InlineData(3, "bcd")]
        [InlineData(4, "zye")]
        public void SortMultipleStrings(int index, string str)
        {
            var array = new SortedList<string>();
            array.Add("ada");
            array.Add("bca");
            array.Add("zye");
            array.Add("bcd");
            array.Add("aaa");
            Assert.Equal(index, array.IndexOf(str));
        }

        [Theory]
        [InlineData(0, 'a')]
        [InlineData(1, 'c')]
        [InlineData(2, 'd')]
        [InlineData(3, 'e')]
        [InlineData(4, 'z')]
        public void SortChar(int index, char letter) 
        {
            var array = new SortedList<char>();
            array.Add('z');
            array.Add('e');
            array.Add('a');
            array.Add('c');
            array.Add('d');
            Assert.Equal(index, array.IndexOf(letter));
        }
    }
}
