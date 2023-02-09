
namespace TMPInterview.Helpers
{
    public class Response<T>
    {
        /// <summary>
        /// Error or Success Message you wish to display to the User.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Status of the Request Made - Whether it was Successful or it Failed
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The response data you wish to send to the Client making the request.
        /// </summary>
        public T Data { get; set; }

    }
}
