using System.Collections.Generic;

namespace Common.DTO
{
    /// <summary>
    /// A pagination wrappwer for any required element.
    /// </summary>
    /// <typeparam name="T">Type of paginated data.</typeparam>
    public class PaginatedDTO<T>
    {
        /// <summary>
        /// All the elements in current page.
        /// </summary>
        public IEnumerable<T> Elements { get; init; }
        /// <summary>
        /// Total count of elements, including this page.
        /// </summary>
        public int Total { get; init; }
    }
}
