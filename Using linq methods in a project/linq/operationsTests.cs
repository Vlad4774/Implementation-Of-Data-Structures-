
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

        public void AllThrowsExceptionWhenSourceIsNull()
        {
            int[] source = null;
            Func<int, bool> predicate = x => x > 0;
            Assert.Throws<ArgumentNullException>(() => source.All(predicate));
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
        public void AnyThrowsExceptionWhenSourceIsNull()
        {
            int[] source = null;
            Func<int, bool> predicate = x => x > 0;

            Assert.Throws<ArgumentNullException>(() => source.Any(predicate));
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
        public void SelectThrowsExceptionForNull()
        {
            int[] numbers = { 1, 3, 7, 25 };
            Func<int, IEnumerable<int>> selector = null;
            Assert.Throws<ArgumentNullException>(() => numbers.Select(selector).ToArray());
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
        public void SelectManyThrowsExceptionForNull()
        {
            int[] numbers = { 1, 3, 7, 25 };
            Func<int, IEnumerable<int>> selector = null;
            Assert.Throws<ArgumentNullException>(() => numbers.SelectMany(selector).ToArray());
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
        public void WhereThrowsExceptionIfSelectorIsNull()
        {
            int[] numbers = { 1, 3, 5, 7, 9 };
            Func<int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => numbers.Where(predicate).ToArray());
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
        public void ToDictionaryThrowsExceptionForNull()
        {
            int[] numbers = { 1, 3, 5, 7, 9 };
            Func<int, int> keySelector = null;
            Func<int, int> elementSelector = n => n * n;
            Assert.Throws<ArgumentNullException>(() => numbers.ToDictionary(keySelector, elementSelector));
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
        public void ZipThrowsExceptionForNull()
        {
            int[] first = { 1, 3, 5, 7, 9 };
            int[] second = null;
            Func<int, int, int> resultSelector = (f, s) => f + s;
            Assert.Throws<ArgumentNullException>(() => first.Zip(second, resultSelector).ToArray());
        }

        [Fact]
        public void AggregateReturnsSumOfNumbers()
        {
            int[] numbers = new int[] { 1, 2, 3, 4 };
            int result = numbers.Aggregate(0, (seed, next) => seed + next);
            Assert.Equal(10, result);
        }

        [Fact]
        public void AggregateWithStringsReturnsConcatenatedString()
        {
            string[] words = new string[] { "hello", "world" };
            string result = words.Aggregate("", (acc, next) => acc + next);
            Assert.Equal("helloworld", result);
        }

        [Fact]
        public void AggregateThrowsExceptionForNull()
        {
            int[] numbers = { 1, 2, 3, 4 };
            Func<int, int, int> func = null;
            Assert.Throws<ArgumentNullException>(() => numbers.Aggregate(0, func));
        }


        [Fact]
        public void TestJoinMethod()
        {
            List<int> list1 = new List<int> { 1, 2, 3 };
            List<int> list2 = new List<int> { 2, 3, 4 };

            var result = list1.Join(
                list2,
                num1 => num1,
                num2 => num2,
                (num1, num2) => num1
            );

            Assert.Equal(new List<int> { 2, 3 }, result);
        }

        [Fact]
        public void JoinReturnsExpectedResult()
        {
            var outer = new[]
            {
        new Person { Name = "Octa", Age = 30 },
        new Person { Name = "Vlad", Age = 25 },
        new Person { Name = "Radu", Age = 35 }
    };

            var inner = new[]
            {
        new Person { Name = "Ana", Age = 31 },
        new Person { Name = "Teodora", Age = 25 },
        new Person { Name = "Ioana", Age = 36 }
    };

            var result = outer.Join(
                inner,
                person => person.Age,
                person => person.Age,
                (outerPerson, innerPerson) => new { outerPerson, innerPerson });

            Assert.Equal(1, result.Count());
            Assert.Equal("Vlad", result.First().outerPerson.Name);
            Assert.Equal("Teodora", result.First().innerPerson.Name);
        }

        [Fact]
        public void JoinThrowsExceptionForNull()
        {
            int[] outer = { 1, 2, 3 };
            int[] inner = { 2, 3, 4 };
            Func<int, int> outerKeySelector = null;
            Func<int, int> innerKeySelector = x => x;
            Func<int, int, int> resultSelector = (x, y) => x + y;

            Assert.Throws<ArgumentNullException>(() => outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector).ToArray());
        }


        [Fact]
        public void DistinctReturnsUniqueElements()
        {
            int[] source = { 1, 2, 3, 4, 5, 1, 2, 3 };
            int[] expected = { 1, 2, 3, 4, 5 };
            var result = source.Distinct();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DistinctWithCustomComparerReturnsExpectedResult()
        {
            string[] source = { "apple", "banana", "cherry", "banana", "apple" };
            string[] expected = { "apple", "banana", "cherry" };
            var result = source.Distinct();
            Assert.Equal(expected, result);

        }

        [Fact]
        public void DistinctWithPersonEqualityComparerTest()
        {
            Person[] source = {
        new Person { Name = "Vlad", Age = 30 },
        new Person { Name = "Ion", Age = 30 },
        new Person { Name = "Marcel", Age = 25 }
    };
            var result = source.Distinct(new PersonEqualityComparer());
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void DistinctThrowsExceptionWhenSourceIsNull()
        {
            int[] numbers = null;
            Assert.Throws<ArgumentNullException>(() => numbers.Distinct(null).ToArray());
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class PersonEqualityComparer : IEqualityComparer<Person>
        {
            public bool Equals(Person x, Person y)
            {
                return x.Age == y.Age;
            }

            public int GetHashCode(Person obj)
            {
                return obj.Age.GetHashCode();
            }
        }

        [Fact]
        public void UnionWithTwoSequencesReturnsCorrectValues()
        {
            int[] first = new int[] { 1, 2, 3, 4, 5 };
            int[] second = new int[] { 4, 5, 6, 7, 8 };
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] result = first.Union(second).ToArray();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void UnionWorksProprielyWithStrings()
        {
            string[] first = new string[] { "A", "B", "C", "D", "E" };
            string[] second = new string[] { "D", "E", "F", "G", "H" };
            string[] expected = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
            string[] result = first.Union(second).ToArray();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void UnionThrowsException()
        {
            int[] first = null;
            int[] second = new int[] { 4, 5, 6, 7, 8 };
            Assert.Throws<ArgumentNullException>(() => first.Union(second).ToArray());
        }

        [Fact]
        public void InstersectWithTwoSequencesReturnsCorrectValues()
        {
            int[] first = new int[] { 1, 2, 3, 4, 5 };
            int[] second = new int[] { 4, 5, 6, 7, 8 };
            int[] expected = new int[] { 4, 5 };
            int[] result = first.Intersect(second).ToArray();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IntersectWorksProprielyWithStrings()
        {
            string[] first = new string[] { "A", "B", "C", "D", "E" };
            string[] second = new string[] { "D", "E", "F", "G", "H" };
            string[] expected = new string[] { "D", "E" };
            string[] result = first.Intersect(second).ToArray();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IntersectThrowsException()
        {
            int[] first = null;
            int[] second = new int[] { 4, 5, 6, 7, 8 };
            Assert.Throws<ArgumentNullException>(() => first.Intersect(second).ToArray());
        }

        [Fact]
        public void ExceptReturnsExpectedResult()
        {
            var first = new List<Person>{
        new Person { Name = "Ion", Age = 25 },
        new Person { Name = "Maria", Age = 30 },
        new Person { Name = "Lucian", Age = 35 }};
            var second = new List<Person>{
        new Person { Name = "Ana", Age = 30 },
        new Person { Name = "Paul", Age = 35 }};

            var comparer = new PersonEqualityComparer();
            var result = first.Except(second, comparer);
            Assert.Equal(1, result.Count());
            Assert.Equal("Ion", result.First().Name);
        }

        [Fact]
        public void ExceptThrowsException()
        {
            var first = new List<Person>{
        new Person { Name = "Ion", Age = 25 },
        new Person { Name = "Maria", Age = 30 },
        new Person { Name = "Lucian", Age = 35 }};
            List<Person> second = null;

            var comparer = new PersonEqualityComparer();

            Assert.Throws<ArgumentNullException>(() => first.Except(second, comparer).ToArray());
        }

        [Fact]
        public void TestGroupByWithComparer()
        {
            var persons = new List<Person>{
        new Person { Name = "Ion", Age = 30 },
        new Person { Name = "Maria", Age = 30 },
        new Person { Name = "Ana", Age = 25 }};
            var comparer = new PersonEqualityComparer();
            var result = persons.GroupBy(p => p, comparer);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GroupByThrowsExceptionWhenSourceIsNull()
        {
            List<Person> source = null;

            Assert.Throws<ArgumentNullException>(() => source.GroupBy(p => p).ToArray());
        }

        [Fact]
        public void OrderByShouldSortElements()
        {
            var source = new[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
            var expected = new[] { 1, 1, 2, 3, 3, 4, 5, 5, 5, 6, 9 };
            var result = source.OrderBy(x => x);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void OrderSortPersonsByAge()
        {
            var source = new[]
            {
                new Person { Name = "John", Age = 35 },
                new Person { Name = "Jane", Age = 29 },
                new Person { Name = "Jim", Age = 42 },
                new Person { Name = "Jack", Age = 36 }
            };
            var expected = new List<Person>
            {
                new Person { Name = "Jane", Age = 29 },
                new Person { Name = "John", Age = 35 },
                new Person { Name = "Jack", Age = 36 },
                new Person { Name = "Jim", Age = 42 }
            };

            var result = Operations.OrderBy(source, x => x.Age, Comparer<int>.Default).ToList();
            Assert.Equal(result, expected, new PersonEqualityComparer());
        }

        [Fact]
        public void ThenSortListOfPeopleByNameAfterSortingByAge()
        {
            var people = new List<Person>
            {
        new Person { Name = "Ioan", Age = 32 },
        new Person { Name = "Maria", Age = 27 },
        new Person { Name = "Adrian", Age = 36 },
        new Person { Name = "Stefan", Age = 25 },
        new Person { Name = "Elena", Age = 25 }
            };

            var expected = new List<Person>
            {
        new Person { Name = "Adrian", Age = 36 },
        new Person { Name = "Elena", Age = 25 },
        new Person { Name = "Ioan", Age = 32 },
        new Person { Name = "Maria", Age = 27 },
        new Person { Name = "Stefan", Age = 25 }
            };

            var result = Operations.OrderBy(people, x => x.Name, Comparer<string>.Default)
                                    .ThenBy(x => x.Age, Comparer<int>.Default)
                                    .ToList();

            Assert.Equal(expected, result, new PersonEqualityComparer());
        }


        [Fact]
        public void ThenByThrowExceptionWhenListIsNull()
        {
            List<Person> people = null;
            Assert.Throws<ArgumentNullException>(() => people.OrderBy(x => x.Name).ThenBy(x => x.Age));
        }
    }   
}