using MiddlewareTask.Middleware;

namespace MiddlewareTask.Extensions
{
    public static class ApplicationMiddlewaresExtension
    {
        public static IApplicationBuilder UseAppMiddlewares(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ResponseHeadersMiddleware>();
        }
    }
}
