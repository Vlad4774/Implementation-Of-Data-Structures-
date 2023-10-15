using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    public class ClassIEnumeratorTests
    {
        [Fact]
        public void AddTwoObjects()
        {
            var array = new ObjectArray { 1, true };
            Assert.Equal(2, array.Count);

        }


        [Fact]
        public void AddMultipleObjects()
        {
            var array = new ObjectArray { "test", 12.312, true, 123 };
            Assert.True(array.Contains(12.312));
            Assert.True(array.Contains("test"));
            Assert.True(array.Contains(true));
            Assert.False(array.Contains(13));

        }

        [Fact]
        public void TestMoveNextAndCurrent()
        {
            var array = new ObjectArray { "test", 12.312, true, 123 };
            var num = array.GetEnumerator();
            num.MoveNext();
            num.MoveNext();
            var current = num.Current;
            Assert.Equal(12.312, current);
            Assert.True(num.MoveNext());
            num.MoveNext();
            Assert.False(num.MoveNext());
        }

        [Fact]
        public void EmptyString()
        {
            var array = new ObjectArray {};
            var num = array.GetEnumerator();
            Assert.False(num.MoveNext());
        }
    }
}
