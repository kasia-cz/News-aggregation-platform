using Microsoft.AspNetCore.Http;
using NewsPlatform.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace NewsPlatform.Shared.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception excp)
            {
                await ExceptionAsync(context, excp);
            }
        }

        private static Task ExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode;
            string message;

            var excpType = ex.GetType();

            if (excpType == typeof(BadRequestException))
            {
                statusCode = HttpStatusCode.BadRequest;
                message = ex.Message;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = ex.Message;
            }

            var result = JsonSerializer.Serialize(new { message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(result);
        }
    }
}
