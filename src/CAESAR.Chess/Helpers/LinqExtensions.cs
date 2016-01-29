using System;
using System.Collections.Generic;

namespace CAESAR.Chess.Helpers
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> TakeWhileUntil<TSource>(this IEnumerable<TSource> list,
            Func<TSource, bool> whilePredicate, Func<TSource, bool> untilPredicate)
        {
            foreach (var item in list)
            {
                var currentItem = item;
                if (whilePredicate(item) || untilPredicate(item))
                    yield return item;
                if (!whilePredicate(currentItem) && untilPredicate(currentItem))
                    yield break;
            }
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> items)
        {
            return new HashSet<T>(items);
        }
    }
}