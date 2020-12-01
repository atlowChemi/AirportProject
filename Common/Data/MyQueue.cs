using System.Collections.Generic;

namespace Common.Data
{
    /// <summary>
    /// Simple Queue implemantation to enable adding to front of line if needed.
    /// </summary>
    /// <typeparam name="T">Type of elements to handle in Queue</typeparam>
    public class MyQueue<T>
    {
        /// <summary>
        /// The items saved in the queue currently.
        /// </summary>
        private readonly LinkedList<T> _items;

        /// <summary>
        /// Build a new empty Queue.
        /// </summary>
        public MyQueue()
        {
            _items = new LinkedList<T>();
        }
        /// <summary>
        /// Buila a new Queue out of a given <see cref="IEnumerable{T}"/>
        /// </summary>
        /// <param name="items">An IEnumerable of items.</param>
        public MyQueue(IEnumerable<T> items)
        {
            _items = new LinkedList<T>(items);
        }

        /// <summary>
        /// Is the Queue currnetly empty.
        /// </summary>
        public bool IsEmpty => _items.Count <= 0;
        /// <summary>
        /// The count of all items currently in the Queue.
        /// </summary>
        public int Count => _items.Count;
        /// <summary>
        /// Add item to begining of the Queue.
        /// </summary>
        /// <param name="value">Item to add.</param>
        public void AddToBegining(T value)
        {
            _items.AddFirst(value);
        }
        /// <summary>
        /// Add item to end of the Queue.
        /// </summary>
        /// <param name="value"></param>
        public void Enqueue(T value)
        {
            _items.AddLast(value);
        }
        /// <summary>
        /// Remove item from Queue.
        /// </summary>
        public void Dequeue()
        {
            if (_items.Count <= 0) return;
            _items.RemoveFirst();
        }
        /// <summary>
        /// Try removing Item from Queue.
        /// </summary>
        /// <param name="result">The item removed.</param>
        /// <returns>True, if value found and removed, false if no value was found.</returns>
        public bool TryDequeue(out T result)
        {
            result = default;
            if (_items.Count <= 0) return false;

            result = _items.First.Value;
            _items.RemoveFirst();
            return true;

        }
        /// <summary>
        /// Try getting first item of the Queue.
        /// </summary>
        /// <param name="result">First item of Queue.</param>
        /// <returns>True, if value found, false if no value was found.</returns>
        public bool TryPeek(out T result)
        {
            result = default;
            if (_items.Count <= 0) return false;

            result = _items.First.Value;
            return true;
        }
    }
}
