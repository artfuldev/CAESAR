using System;
using System.Collections.Generic;
using System.Linq;

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

        private static readonly Random _random = new Random();
        public static TSource Random<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> whilePredicate = null)
        {
            whilePredicate = whilePredicate ?? (x => true);
            var list = source.Where(whilePredicate).ToList();
            var count = list.Count;
            var index = _random.Next(0, count + 1);
            return list[index];
        }

        public static TSource RandomOrDefault<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> whilePredicate = null)
        {
            try
            {
                return source.Random(whilePredicate);
            }
            catch
            {
                return default(TSource);
            }
        }
    }
}