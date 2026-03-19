using System.Net;
using System.Text.Json;
using Estoque.Application.Exceptions;

namespace Estoque.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var statusCode = StatusCodes.Status500InternalServerError;
                var message = "Erro interno.";

                if (ex is NotFoundException)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    message = ex.Message;
                }
                else if (ex is ValidationException)
                {
                    statusCode = StatusCodes.Status400BadRequest;
                    message = ex.Message;
                }
                else
                {
                    statusCode = StatusCodes.Status500InternalServerError; 
                    message = ex.Message;
                }
                var response = new { error = message };
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)statusCode;

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}