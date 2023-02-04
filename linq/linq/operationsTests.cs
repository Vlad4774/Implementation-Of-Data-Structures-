namespace linq
{
    public class OperationsTests
    {
        [Fact]
        public void AllElementsSatisfyingPredicateReturnsTrue()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            Func<int, bool> predicate = n => n < 6;
            bool result = numbers.All(predicate);
            Assert.True(result);
        }

        [Fact]
        public void NotAllElementsSatisfyingPredicateReturnsFalse()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            Func<int, bool> predicate = n => n > 3;
            bool result = numbers.All(predicate);
            Assert.False(result);
        }

        [Fact]
        public void AnyElementsSatisfyingPredicateReturnsTrue()
        {
            string[] strings = { "Hello", "World", "Goodbye" };
            Func<string, bool> predicate = s => s.Length > 5;
            bool result = strings.Any(predicate);
            Assert.True(result);
        }

        [Fact]
        public void NoneOfElementsSatisfyingPredicateReturnsFalse()
        {
            string[] strings = { "Hello", "World", "yes" };
            Func<string, bool> predicate = s => s.Length > 10;
            bool result = strings.Any(predicate);
            Assert.False(result);
        }

        [Fact]
        public void FirstReturnRightElement()
        {
            string[] strings = { "Hello", "World", "Goodbye" };
            Func<string, bool> predicate = s => s.Length > 6;
            string result = strings.First(predicate);
            Assert.Equal("Goodbye", result);
        }

        [Fact]
        public void FirstThrowsExceptionIfTheMatch()
        {
            string[] strings = { "Hello", "World", "Goodbye" };
            Func<string, bool> predicate = s => s == "Hey";
            Assert.Throws<InvalidOperationException>(() => strings.First(predicate));
        }

        [Fact]
        public void SelectAppliesTransformToEachElement()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            Func<int, string> selector = n => n.ToString();
            string[] result = numbers.Select(selector).ToArray();
            Assert.Equal(new string[] { "1", "2", "3", "4", "5" }, result);
        }

        [Fact]
        public void SelectReturnsCorrectly()
        {
            int[] numbers = { 1, 3, 7, 25 };
            Func<int, int> selector = n => n * 2;
            int[] result = numbers.Select(selector).ToArray();
            Assert.Equal(new int[] { 2, 6, 14, 50 }, result);
        }

        [Fact]
        public void SelectManyReturnsCorrectly()
        {
            int[] numbers = { 1, 3, 7, 25 };
            Func<int, IEnumerable<int>> selector = n => new int[] { n, n * 2 };
            int[] result = numbers.SelectMany(selector).ToArray();
            Assert.Equal(new int[] { 1, 2, 3, 6, 7, 14, 25, 50 }, result);
        }

        [Fact]
        public void WhereReturnsCorrectElements()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            Func<int, bool> predicate = n => n % 2 == 0;
            int[] result = numbers.Where(predicate).ToArray();
            Assert.Equal(new int[] { 2, 4 }, result);
        }

        [Fact]
        public void WhereReturnsEmptyEnumerableForNoMatches()
        {
            int[] numbers = { 1, 3, 5, 7, 9 };
            Func<int, bool> predicate = n => n % 2 == 0;
            int[] result = numbers.Where(predicate).ToArray();
            Assert.Empty(result);
        }

        [Fact]
        public void ToDictionaryWithValidInputReturnsCorrectDictionary()
        {
            var source = new List<string> { "Hello", "world", "hey", "yes", "no", "maybe" };
            var expected = new Dictionary<int, string> { { 0, "Hello" }, { 1, "world" }, { 2, "hey" }, { 3, "yes" }, { 4, "no" }, { 5, "maybe" } };
            var result = source.ToDictionary(x => source.IndexOf(x), x => x);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToDictionaryWithDuplicateKeyThrowsException()
        {
            var source = new List<string> { "Hello", "World" };
            Assert.Throws<ArgumentException>(() => source.ToDictionary(x => x.Length, x => x));
        }

        [Fact]
        public void ZipAddElementsFromTwoArraysReturnCorectResult()
        {
            var first = new[] { 1, 2, 3 };
            var second = new[] { 4, 5, 6 };
            var expected = new[] { 5, 7, 9 };
            var result = first.Zip(second, (f, s) => f + s);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ZipWithDifferentLengthReturnsCorectResult()
        {
            var first = new[] { 1, 2, 3 };
            var second = new[] { 1, 2 };
            var result = first.Zip(second, (f, s) => f + s);
            var expected = new[] { 2, 4 };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AggregateReturnsSumOfNumbers()
        {
            int[] numbers = new int[] { 1, 2, 3, 4 };
            int result = numbers.Aggregate(0, (acc, next) => acc + next);
            Assert.Equal(10, result);
        }

        [Fact]
        public void AggregateWithStringsReturnsConcatenatedString()
        {
            string[] words = new string[] { "hello", "world" };
            string result = words.Aggregate("", (acc, next) => acc + next);
            Assert.Equal("helloworld", result);
        }

    }
}