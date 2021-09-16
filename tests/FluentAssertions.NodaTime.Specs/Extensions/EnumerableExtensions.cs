using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentAssertions.NodaTime.Specs.Extensions
{
    public static class EnumerableExtensions
    {
        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.OrderBy(_ => Guid.NewGuid()).First();
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> enumerable, T item)
        {
            return enumerable.Except(new[] { item });
        }
    }
}
