using System.Data;

namespace Collection
{
    public class ReadOnlyListTests
    {
        [Fact]
        public void ReadOnlyExceptionForAdd()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var readOnlyList = new ReadOnlyList<int>(list);
            Assert.Throws<ReadOnlyException>(() => readOnlyList.Add(2));
        }

        [Fact]
        public void ReadOnlyExceptionForInsert()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            var readOnlyList = new ReadOnlyList<int>(list);
            Assert.Throws<ReadOnlyException>(() => readOnlyList.Insert(2, 3));
        }

        [Fact]
        public void ReadOnlyExceptionForRemoveAt()
        {
            var list = new List<char>();
            list.Add('a');
            list.Add('c');
            list.Add('b');
            var readOnlyList = new ReadOnlyList<char>(list);
            Assert.Throws<ReadOnlyException>(() => readOnlyList.RemoveAt(1));
        }

        [Fact]
        public void InvalidIndexForGet()
        {
            var list = new List<string>();
            list.Add("Fcsb");
            list.Add("Sepsi");
            list.Add("Rapid");
            var readOnlyList = new ReadOnlyList<string>(list);
            Assert.Throws<IndexOutOfRangeException>(() => list[4]);
        }
    }
}
