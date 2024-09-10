using Hospitals.Persistance.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace Hospitals.WebApi.Common.Middleware
{
    public class CustomExceptionHandlerMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            string message = string.Empty;

            switch (exception)
            {
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    message = notFoundException.Message;
                    break;
                case WrongQueryException wrongQueryException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = wrongQueryException.Message;
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            if (message == string.Empty)
                message = JsonSerializer.Serialize(new { error = exception.Message });

            await context.Response.WriteAsync(message);
        }
    }
}
