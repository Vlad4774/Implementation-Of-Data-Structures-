
namespace linq
{
    static class Operations
    {
        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource element in source)
            {
                if (!predicate(element))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
