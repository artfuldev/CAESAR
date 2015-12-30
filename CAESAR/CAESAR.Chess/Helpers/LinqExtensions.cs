using System;
using System.Collections.Generic;

namespace CAESAR.Chess.Helpers
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> TakeWhileIncluding<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            foreach (var el in list)
            {
                yield return el;
                if (predicate(el))
                    yield break;
            }
        }
    }
}