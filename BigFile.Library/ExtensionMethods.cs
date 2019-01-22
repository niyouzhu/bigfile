using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace BigFile.Library
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
            return enumerable;
        }

        public static void Enqueue<T>(this ConcurrentQueue<T> queue, IEnumerable<T> enumerable)
        {
            foreach (var item in enumerable)
            {
                queue.Enqueue(item);
            }
        }
    }
}