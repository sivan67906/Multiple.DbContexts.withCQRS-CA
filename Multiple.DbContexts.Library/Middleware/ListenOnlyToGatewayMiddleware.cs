using Microsoft.AspNetCore.Http;

namespace Multiple.DbContexts.Library.Middleware;

public class ListenOnlyToGatewayMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        // Extract specific header from the request
        var signedHeader = context.Request.Headers["Api-Gateway"];

        // Null means, the request is not coming from the Api-Gateway
        if (signedHeader.FirstOrDefault() is null)
        {
            context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
            await context.Response.WriteAsync("Sorry, Service is unavailable");

            return;
        }
        else
        {
            await next(context);
        }
    }
}
