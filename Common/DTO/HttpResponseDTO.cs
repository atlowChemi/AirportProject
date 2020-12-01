using System;

namespace Common.DTO
{
    public class HttpResponseDTO
    {
        public string ResponseType { get; init; }
        public string Message { get; init; }
        public string? FailureReason { get; init; }
    }
}
