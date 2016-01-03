using System;
using System.Collections.Generic;

namespace CAESAR.Chess.Helpers
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> TakeWhileUntil<T>(this IEnumerable<T> list, Func<T, bool> whilePredicate, Func<T, bool> untilPredicate)
        {
            foreach (var item in list)
            {
                if (whilePredicate(item) || untilPredicate(item))
                    yield return item;
                if (untilPredicate(item))
                    yield break;
            }
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> items)
        {
            return new HashSet<T>(items);
        }
    }
}