
using System.Net;
using TMPInterview.Enums;

namespace TMPInterview.Helpers
{
    public class APIResponse<T>
    {
        public Response<T> ResponseBody { get; set; }
        public int StatusCode { get; set; }

        public APIResponse<T> FormatResponse(string responseMessage, ResponseStatus status, HttpStatusCode statusCode, T data)
        {
            APIResponse<T> response = new()
            {
                ResponseBody = new Response<T>
                {
                    Data = data,
                    Message = responseMessage,
                    Status = status.ToString()
                },
                StatusCode = (int)statusCode
            };
            return response;
        }
    }
}

