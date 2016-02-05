using System;
using System.Collections.Generic;
using System.Linq;

namespace CAESAR.Chess.Helpers
{
    /// <summary>
    ///     Extensions for <seealso cref="IEnumerable{T}" />
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        ///     A random number generator
        /// </summary>
        private static readonly Random _random = new Random();

        /// <summary>
        ///     Takes the <seealso cref="IEnumerable{TSource}" />, as long as a while condition is met, until a specified condition
        ///     is satisfied.
        /// </summary>
        /// <typeparam name="TSource">The type of item in the <seealso cref="IEnumerable{TSource}" />.</typeparam>
        /// <param name="list">The <seealso cref="IEnumerable{TSource}" /> of items from which to take.</param>
        /// <param name="whilePredicate">The while condition.</param>
        /// <param name="untilPredicate">The until condition./</param>
        /// <returns></returns>
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

        /// <summary>
        ///     Converts an <seealso cref="IEnumerable{T}" /> to a <seealso cref="HashSet{T}" />.
        /// </summary>
        /// <typeparam name="T">The type of items in the <seealso cref="IEnumerable{T}" />.</typeparam>
        /// <param name="items">The <seealso cref="IEnumerable{TSource}" /> of items from which to take.</param>
        /// <returns>A <seealso cref="HashSet{T}" /> containing the same items as in the passed <seealso cref="IEnumerable{T}" />.</returns>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> items)
        {
            return new HashSet<T>(items);
        }

        /// <summary>
        ///     Selects a random element from an <seealso cref="IEnumerable{TSource}" />, with an optional condition.
        /// </summary>
        /// <typeparam name="TSource">The type of items in the <seealso cref="IEnumerable{TSource}" />.</typeparam>
        /// <param name="source">The <seealso cref="IEnumerable{TSource}" /> of items from which to select a random element.</param>
        /// <param name="whilePredicate">The optional where condition with which to select the random element.</param>
        /// <returns>
        ///     A random <seealso cref="TSource" /> from the <seealso cref="IEnumerable{TSource}" /> matching the
        ///     <seealso cref="whilePredicate" />.
        /// </returns>
        public static TSource Random<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> whilePredicate = null)
        {
            whilePredicate = whilePredicate ?? (x => true);
            var list = source.Where(whilePredicate).ToList();
            var count = list.Count;
            var index = _random.Next(count);
            return list[index];
        }

        /// <summary>
        ///     Selects a random element from an <seealso cref="IEnumerable{TSource}" />, with an optional condition. If no such
        ///     element is found, the default value of the <seealso cref="TSource" /> is returned.
        /// </summary>
        /// <typeparam name="TSource">The type of items in the <seealso cref="IEnumerable{TSource}" />.</typeparam>
        /// <param name="source">The <seealso cref="IEnumerable{TSource}" /> of items from which to select a random element.</param>
        /// <param name="whilePredicate">The optional where condition with which to select the random element.</param>
        /// <returns>
        ///     A random <seealso cref="TSource" /> from the <seealso cref="IEnumerable{TSource}" /> matching the
        ///     <seealso cref="whilePredicate" />. If no such element is found, the default value of the <seealso cref="TSource" />
        ///     is returned.
        /// </returns>
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