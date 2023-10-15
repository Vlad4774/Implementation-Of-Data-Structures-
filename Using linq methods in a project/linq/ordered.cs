using System;
using System.Collections;
using System.Collections.Immutable;

namespace linq
{
    public class Ordered<TSource, Tkey> : IOrderedEnumerable<TSource>
    {
        private IEnumerable<TSource> source;
        private Func<TSource, Tkey> keySelector;
        private IComparer<Tkey> comparer;
        private bool descending;

        public Ordered(
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
            var sortedList = new SortedList<TSource, Tkey>();

            foreach (var element in source)
            {
                sortedList.Add(element, keySelector(element));
            }

            foreach (var element in sortedList)
            {
                yield return element.Value;
            }
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
            return new Ordered<TSource, TKey>(source, keySelector, comparer, descending);
        }
    }
}
