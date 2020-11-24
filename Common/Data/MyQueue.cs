using System.Collections.Generic;

namespace Common.Data
{
    public class MyQueue<T>
    {
        private readonly LinkedList<T> _items;

        public MyQueue()
        {
            _items = new LinkedList<T>();
        }

        public MyQueue(IEnumerable<T> items)
        {
            _items = new LinkedList<T>(items);
        }

        public bool IsEmpty => _items.Count <= 0;
        public int Count => _items.Count;
        public void Enqueue(T value)
        {
            _items.AddLast(value);
        }
        public void Dequeue()
        {
            if (_items.Count <= 0) return;
            _items.RemoveFirst();
        }
        public bool TryDequeue(out T result)
        {
            result = default;
            if (_items.Count <= 0) return false;

            result = _items.First.Value;
            _items.RemoveFirst();
            return true;

        }

        public bool TryPeek(out T result)
        {
            result = default;
            if (_items.Count <= 0) return false;

            result = _items.First.Value;
            return true;
        }

        public void AddToBegining(T value)
        {
            _items.AddFirst(value);
        }
    }
}
