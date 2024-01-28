using System.Net;
using System.Text.Json;

namespace CaseWork.WebApi.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var messageError = string.Empty;

                messageError = "Internal Server Error";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var result = JsonSerializer.Serialize(messageError);
                Console.WriteLine(ex.Message);
                await response.WriteAsync(result);
            }
        }

    }
}