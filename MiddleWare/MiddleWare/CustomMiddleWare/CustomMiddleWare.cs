
using Microsoft.AspNetCore.Hosting.Builder;

namespace MiddleWare.CustomMiddleWare
{
    public class CustomMiddleWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Query.ContainsKey("firstname"))
            {
                var name = context.Request.Query["firstname"];
                await context.Response.WriteAsync($"Hello {name}\n");
                await next(context);
            }
            await context.Response.WriteAsync("custom end\n");
        }
    }

    public static class MiddleWareExtension
    {
        public static IApplicationBuilder UseCustomeMiddleWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleWare>();
        }
    }
}
