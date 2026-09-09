using Microsoft.AspNetCore.Mvc;

namespace Gnocchi.Backend.API.Middleware;

public sealed class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            var statusCode = exception is NullReferenceException
                ? StatusCodes.Status404NotFound
                : StatusCodes.Status500InternalServerError;
            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = statusCode == StatusCodes.Status404NotFound
                    ? "Resource not found"
                    : "An unexpected error occurred",
                Detail = exception.Message
            };

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}