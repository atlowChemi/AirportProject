using System.Collections.Generic;

namespace Common.DTO
{
    public class PaginatedDTO<T>
    {
        public IEnumerable<T> Elements { get; init; }
        public int Total { get; init; }
    }
}
