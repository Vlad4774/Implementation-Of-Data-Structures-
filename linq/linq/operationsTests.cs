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

    }
}