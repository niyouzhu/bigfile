using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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

        public static TList ForEach<TList, T1, T2>(this IEnumerable<T1> enumerable, Func<T1, T2> func) where TList : IList<T2>, new()
        {
            var list = new TList();
            foreach (var item in enumerable)
            {
                list.Add(func(item));
            }
            return list;
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