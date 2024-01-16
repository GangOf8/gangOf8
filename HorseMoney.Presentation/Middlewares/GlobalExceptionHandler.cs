
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HorseMoney.Presentation.Middlewares
{
    public class GlobalExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case DbUpdateException ex:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await response.WriteAsJsonAsync("Exception update");
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await response.WriteAsJsonAsync("Internal error");
                        break;
                }
            }
        }
    }
}
