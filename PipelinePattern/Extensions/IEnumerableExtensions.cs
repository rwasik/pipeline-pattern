using System;
using System.Collections.Generic;

namespace PipelinePattern.Extensions
{
    internal static class IEnumerableExtensions
    {
        internal static IEnumerable<TSource> SkipUntil<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            bool include = false;
            foreach (TSource element in source)
            {
                if (include) yield return element;
                if (!include && !predicate(element))
                {
                    include = true;
                    yield return element;
                }
            }
        }

        internal static IEnumerable<TSource> TakeUntil<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource element in source)
            {
                if (!predicate(element))
                {
                    yield return element;
                    yield break;
                }
                yield return element;
            }
        }
    }
}
