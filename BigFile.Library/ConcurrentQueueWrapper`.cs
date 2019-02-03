using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace BigFile.Library
{
    public class ConcurrentQueueWrapper<T>
    {
        public ConcurrentQueueWrapper(ConcurrentQueue<T> queue)
        {
            Queue = queue;
        }

        public ConcurrentQueueWrapper() : this(new ConcurrentQueue<T>())
        {
        }

        public ConcurrentQueue<T> Queue { get; }

        public event Action Enqueued;

        public void Enqueue(T directory)
        {
            Queue.Enqueue(directory);
            Enqueued?.Invoke();
        }

        public void Enqueue(IEnumerable<T> list)
        {
            list.ForEach(Enqueue);
        }

        public bool TryDequeue(out T item)
        {
            if (Queue.TryDequeue(out item))
            {
                return true;
            }
            return false;
        }
    }
}