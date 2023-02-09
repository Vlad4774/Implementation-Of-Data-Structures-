
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace linq
{
    static class Operations
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            NullExceptionForSource(source);
            NullExceptionForPredicate(predicate);

            foreach (var element in source)
            {
                if (!predicate(element))
                {
                    return false;
                }
            }
            
            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            NullExceptionForSource(source);

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    return true;
                }
            }
            
            return false;
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            NullExceptionForSource(source);

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    return element;
                }
            }

            throw new InvalidOperationException();
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            NullExceptionForSource(source);
            NullExceptionForSelector(selector);
            
            foreach (var element in source)
            {
                yield return selector(element);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            NullExceptionForSource(source);
            NullExceptionForSelector(selector);
            
            foreach (var element in source)
            {
                foreach (TResult result in selector(element))
                {
                    yield return result;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            NullExceptionForSource(source);
            NullExceptionForPredicate(predicate);

            foreach (var element in source)
            {
                if (predicate(element))
                {
                    yield return element;
                }
            }
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
    this IEnumerable<TSource> source,
    Func<TSource, TKey> keySelector,
    Func<TSource, TElement> elementSelector)
        {
            NullExceptionForSource(source);
            NullExceptionForSelector(keySelector);
            NullExceptionForSelector(elementSelector);
            
            var dictionary = new Dictionary<TKey, TElement>();
            foreach (var element in source)
            {   
                dictionary.Add(keySelector(element), elementSelector(element));
            }

            return dictionary;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
    this IEnumerable<TFirst> first,
    IEnumerable<TSecond> second,
    Func<TFirst, TSecond, TResult> resultSelector)
        {
            NullExceptionForSource(first);
            NullExceptionForSource(second);

            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();
            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                yield return resultSelector(firstEnumerator.Current, secondEnumerator.Current);
            }
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
    this IEnumerable<TSource> source,
    TAccumulate seed,
    Func<TAccumulate, TSource, TAccumulate> func)
        {
            NullExceptionForSource(source);
            NullExceptionForSeed(seed);
            NullExceptionForFunc(func);
            
            foreach (var element in source)
            {
                seed = func(seed, element);
            }

            return seed;
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
    this IEnumerable<TOuter> outer,
    IEnumerable<TInner> inner,
    Func<TOuter, TKey> outerKeySelector,
    Func<TInner, TKey> innerKeySelector,
    Func<TOuter, TInner, TResult> resultSelector)
        {
            NullExceptionForSource(outer);
            NullExceptionForSource(inner);
            NullExceptionForSelector(outerKeySelector);
            NullExceptionForSelector(innerKeySelector);
            NullExceptionForResultSelector(resultSelector);

            var dictionaryInner = inner.ToDictionary(innerKeySelector);

            foreach (var outerElement in outer)
            {
                var outerKey = outerKeySelector(outerElement);

                if (dictionaryInner.TryGetValue(outerKey, out var innerElement))
                {
                    yield return resultSelector(outerElement, innerElement);
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(
    this IEnumerable<TSource> source,
    IEqualityComparer<TSource> comparer)
        {
            NullExceptionForSource(source);

            var hashSet = new HashSet<TSource>(comparer);
            foreach (var item in source)
            {
                if (hashSet.Add(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> Union<TSource>(
    this IEnumerable<TSource> first,
    IEnumerable<TSource> second,
    IEqualityComparer<TSource> comparer)
        {
            NullExceptionForSource(first);
            NullExceptionForSource(second);

            return first.Concat(second).Distinct(comparer);
        }

        public static IEnumerable<TSource> Intersect<TSource>(
    this IEnumerable<TSource> first,
    IEnumerable<TSource> second,
    IEqualityComparer<TSource> comparer)
        {
            NullExceptionForSource(first);
            NullExceptionForSource(second);

            var hashSet = new HashSet<TSource>(second, comparer);
            foreach (var item in first)
            {
                if (hashSet.Remove(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> Except<TSource>(
    this IEnumerable<TSource> first,
    IEnumerable<TSource> second,
    IEqualityComparer<TSource> comparer)
        {
            NullExceptionForSource(first);
            NullExceptionForSource(second);

            var hashSet = new HashSet<TSource>(second, comparer);
            foreach (var item in first)
            {
                if (hashSet.Add(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
    this IEnumerable<TSource> source,
    Func<TSource, TKey> keySelector,
    Func<TSource, TElement> elementSelector,
    Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
    IEqualityComparer<TKey> comparer)
        {
            NullExceptionForSource(source);
            NullExceptionForSelector(keySelector);
            NullExceptionForSelector(elementSelector);
            NullExceptionForResultSelector(resultSelector);

            var dictionary = new Dictionary<TKey, List<TElement>>(comparer);
            foreach (var element in source)
            {
                var key = keySelector(element);
                var value = elementSelector(element);
                if (dictionary.ContainsKey(key))
                {
                    dictionary[key].Add(value);
                }
                else
                {
                    dictionary.Add(key, new List<TElement> { value });
                }
            }

            foreach (var key in dictionary.Keys)
            {
                yield return resultSelector(key, dictionary[key]);
            }
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
    this IEnumerable<TSource> source,
    Func<TSource, TKey> keySelector,
    IComparer<TKey> comparer)
        {
            NullExceptionForSource(source);
            NullExceptionForSelector(keySelector);

            var sortedList = new SortedList<TKey, TSource>(comparer);
            foreach (var element in source)
            {
                sortedList.Add(keySelector(element), element);
            }

            return (IOrderedEnumerable<TSource>)sortedList;
        }

        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
    this IOrderedEnumerable<TSource> source,
    Func<TSource, TKey> keySelector,
    IComparer<TKey> comparer)
        {
            return source.OrderBy(keySelector, comparer);
        }

        private static void NullExceptionForSource<TSource>(IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
        }

        private static void NullExceptionForPredicate<TSource>(Func<TSource, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
        }

        private static void NullExceptionForSelector<TSource, TResult>(Func<TSource, TResult> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }
        }

        private static void NullExceptionForResultSelector<TOuter, TInner, TResult>(Func<TOuter, TInner, TResult> resultSelector)
        {
            if (resultSelector == null)
            {
                throw new ArgumentNullException(nameof(resultSelector));
            }
        }

        private static void NullExceptionForSeed<TAccumulate>(TAccumulate seed)
        {
            if (seed == null)
            {
                throw new ArgumentNullException(nameof(seed));
            }
        }

        private static void NullExceptionForFunc<TSource, TAccumulate>(
    Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
        }
    }
}
