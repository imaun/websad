using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Websad.Core.Middlewares
{
    public class IgnoreUploadedFilesMiddleware
    {
        private readonly RequestDelegate next;

        // You can inject a dependency here that gives you access
        // to your ignored route configuration.
        public IgnoreUploadedFilesMiddleware(RequestDelegate next) {
            this.next = next;
        }



        public async Task Invoke(HttpContext context) {
            if (context.Request.Path.HasValue &&
                context.Request.Path.Value.Contains("favicon.ico")) {

                context.Response.StatusCode = 404;

                Console.WriteLine("Ignored!");

                return;
            }

            await next.Invoke(context);
        }
    }
}
