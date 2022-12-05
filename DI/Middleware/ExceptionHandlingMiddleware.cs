using System.Net;
using System.Text.Json;

namespace DI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            string message = exception.Message;
            //You can change the text of the msg messages or the response staus code here depending on exception type but i chose to view the exact msg 
            switch (exception) { 
                case SystemException ex:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;

            }
            _logger.LogError(exception.Message);
            var exceptionMessage = JsonSerializer.Serialize(new { Message = message });
            await context.Response.WriteAsync(exceptionMessage);
        }
    }
}
