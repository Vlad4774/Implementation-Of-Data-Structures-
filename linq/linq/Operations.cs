
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace linq
{
    static class Operations
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            NullException(source, nameof(source));
            NullException(predicate, nameof(predicate));

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
            NullException(source, nameof(source));

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
            NullException(source, nameof(source));

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
            NullException(source, nameof(source));
            NullException(selector, nameof(selector));

            foreach (var element in source)
            {
                yield return selector(element);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            NullException(source, nameof(source));
            NullException(selector, nameof(selector));

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
            NullException(source, nameof(source));
            NullException(predicate, nameof(predicate));

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
            NullException(source, nameof(source));
            NullException(keySelector, nameof(keySelector));
            NullException(elementSelector, nameof(elementSelector));

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
            NullException(first, nameof(first));
            NullException(second, nameof(second));

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
            NullException(source, nameof(source));
            NullException(seed, nameof(seed));
            NullException(func, nameof(func));

            var agg = seed;
            foreach (var element in source)
            {
                agg = func(agg, element);
            }

            return agg;
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
    this IEnumerable<TOuter> outer,
    IEnumerable<TInner> inner,
    Func<TOuter, TKey> outerKeySelector,
    Func<TInner, TKey> innerKeySelector,
    Func<TOuter, TInner, TResult> resultSelector)
        {
            NullException(outer, nameof(outer));
            NullException(inner, nameof(inner));
            NullException(outerKeySelector, nameof(outerKeySelector));
            NullException(innerKeySelector, nameof(innerKeySelector));
            NullException(resultSelector, nameof(resultSelector));

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
            NullException(source, nameof(source));

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
            NullException(first, nameof(first));
            NullException(second, nameof(second));

            return first.Concat(second).Distinct(comparer);
        }

        public static IEnumerable<TSource> Intersect<TSource>(
    this IEnumerable<TSource> first,
    IEnumerable<TSource> second,
    IEqualityComparer<TSource> comparer)
        {
            NullException(first, nameof(first));
            NullException(second, nameof(second));

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
            NullException(first, nameof(first));
            NullException(second, nameof(second));

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
            NullException(source, nameof(source));
            NullException(keySelector, nameof(keySelector));
            NullException(elementSelector, nameof(elementSelector));
            NullException(resultSelector, nameof(resultSelector));

            var dictionary = new Dictionary<TKey, List<TElement>>(comparer);
            foreach (var element in source)
            {
                var key = keySelector(element);
                var value = elementSelector(element);
                dictionary.TryAdd(key, new List<TElement> { value });
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
            NullException(source, nameof(source));
            NullException(keySelector, nameof(keySelector));

            return new OrderedEnumerable<TSource, TKey>(source, keySelector, comparer, false);
        }

        public static IOrderedEnumerable<TSource> ThenBy<TSource, TKey>(
    this IOrderedEnumerable<TSource> source,
    Func<TSource, TKey> keySelector,
    IComparer<TKey> comparer)
        {
            NullException(source, nameof(source));
            NullException(keySelector, nameof(keySelector));

            return source.CreateOrderedEnumerable(keySelector, comparer, false);
        }

        private class OrderedEnumerable<TSource, Tkey> : IOrderedEnumerable<TSource>
        {
            private IEnumerable<TSource> source;
            private Func<TSource, Tkey> keySelector;
            private IComparer<Tkey> comparer;
            private bool descending;

            public OrderedEnumerable(
                IEnumerable<TSource> source,
                Func<TSource, Tkey> keySelector,
                IComparer<Tkey> comparer,
                bool descending)
            {
                this.source = source;
                this.keySelector = keySelector;
                this.comparer = comparer;
                this.descending = descending;
            }

            public IEnumerator<TSource> GetEnumerator()
            {
                var sortedList = new SortedList<Tkey, TSource>(comparer);
                foreach (var element in source)
                {
                    sortedList.Add(keySelector(element), element);
                }
                
                return sortedList.Values.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(
                Func<TSource, TKey> keySelector,
                IComparer<TKey> comparer,
                bool descending)
            {
                return new OrderedEnumerable<TSource, TKey>(source, keySelector, comparer, descending);
            }
        }
        
        private static void NullException<T>(T argument, string name)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
