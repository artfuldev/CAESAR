using System.Linq;
using CAESAR.Chess.Helpers;
using Xunit;

namespace CAESAR.Chess.Tests.Helpers
{
    public class LinqExtensionsTests
    {
        [Fact]
        public void TakeWhileXUntilYTakesWhileXUntilY()
        {
            var items = Enumerable.Range(2, 9).ToArray();
            var takeWhile = items.TakeWhile(x => x < 7).ToHashSet();
            var until = items.SkipWhile(x => x < 7).Take(1).ToHashSet();
            var takeWhileUntil = items.TakeWhileUntil(x => x < 7, x => x != 0).ToArray().ToHashSet();
            Assert.All(takeWhile, (x)=>takeWhileUntil.Contains(x));
            Assert.True(takeWhile.Concat(until).ToHashSet().SetEquals(takeWhileUntil));

            takeWhile = items.TakeWhile(x => x > 100).ToHashSet();
            takeWhileUntil = items.TakeWhileUntil(x => x > 100, x => x > 50).ToHashSet();
            Assert.Empty(takeWhile);
            Assert.Empty(takeWhileUntil);
            takeWhileUntil = items.TakeWhileUntil(x => x > 100, x => x <7).ToHashSet();
            Assert.True(takeWhileUntil.Count == 1);
            Assert.True(takeWhileUntil.ElementAt(0) == 2);
        }
    }
}