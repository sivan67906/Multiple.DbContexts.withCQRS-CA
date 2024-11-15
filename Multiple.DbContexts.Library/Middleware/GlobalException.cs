using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multiple.DbContexts.Library.Logs;
using System.Net;
using System.Text.Json;

namespace Multiple.DbContexts.Library.Middleware;

public class GlobalException(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        // Declare Default Variable
        string title = "Error";
        string message = "Sorry, internal server error occured. Kindly try again.";
        int statusCode = (int)HttpStatusCode.InternalServerError;

        try
        {
            await next(context);

            // Check if Exception is Too many request // 429 status code.
            if (context.Response.StatusCode == StatusCodes.Status429TooManyRequests)
            {
                title = "Warning";
                message = "Too many request made.";
                statusCode = (int)StatusCodes.Status429TooManyRequests;

                await ModifyHeader(context, title, message, statusCode);
            }

            // Check if Exception is Unauthorized // 401 status code.
            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                title = "Alert";
                message = "You are not authorized to access.";
                statusCode = (int)StatusCodes.Status429TooManyRequests;

                await ModifyHeader(context, title, message, statusCode);
            }

            // Check if Exception is Forbidden // 403 status code.
            if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                title = "Out of Access";
                message = "You are not allowed/required to access.";
                statusCode = (int)StatusCodes.Status429TooManyRequests;

                await ModifyHeader(context, title, message, statusCode);
            }
        }
        catch (Exception ex)
        {
            // Log original exception
            LogException.LogExceptions(ex);

            // Check if Exception is Timeout
            if (ex is TimeoutException || ex is TaskCanceledException)
            {
                title = "Out of time";
                message = "Request timeout. Try again.";
                statusCode = (int)StatusCodes.Status408RequestTimeout;
            }

            // If none of the exceptions then do the default.
            await ModifyHeader(context, title, message, statusCode);
        }
    }

    private async Task ModifyHeader(HttpContext context, string title, string message, int statusCode)
    {
        // Display scary-free message to client
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(JsonSerializer.Serialize(new ProblemDetails()
        {
            Title = title,
            Detail = message,
            Status = statusCode
        }), CancellationToken.None);

        return; // To kill thre request.
    }
}
