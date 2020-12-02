namespace Common.DTO
{
    /// <summary>
    /// A HTTP response to send from API server.
    /// </summary>
    public class HttpResponseDTO
    {
        /// <summary>
        /// The response type.
        /// </summary>
        /// <seealso cref="Constants.Constants.RESPONSE_TYPE_SUCCESS"/>
        /// <seealso cref="Constants.Constants.RESPONSE_TYPE_FAILURE"/>
        public string ResponseType { get; init; }
        /// <summary>
        /// The message regarding the HTTP response.
        /// </summary>
        public string Message { get; init; }
        /// <summary>
        /// The reason for the failure, if any.
        /// </summary>
        public string FailureReason { get; init; }
    }
}
