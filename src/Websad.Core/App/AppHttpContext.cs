using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Websad.Core.App
{
    public class AppHttpContext {
        private static IHttpContextAccessor _httpContext;
        public static HttpContext Current => _httpContext.HttpContext;
        public static HttpRequest Request => Current.Request;
        public static string BaseUrl => $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
        internal static void Configure(IHttpContextAccessor httpContext) {
            _httpContext = httpContext;
        }
    }

    public static class HttpContextExtensions {
        public static IApplicationBuilder UseAppHttpContext(this IApplicationBuilder app) {
            AppHttpContext.Configure(app.ApplicationServices
                .GetRequiredService<IHttpContextAccessor>());
            return app;
        }
    }
}
