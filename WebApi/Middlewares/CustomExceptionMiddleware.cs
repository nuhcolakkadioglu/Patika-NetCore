using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();

            string message = "[Request] HTTP " + context.Request.Method + " " + context.Request.Path;
            Console.WriteLine(message);
            await _next(context);
            watch.Stop();

            message = "[Response] HTTP" + context.Request.Method + " " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.Elapsed + "ms";
            Console.WriteLine(message);
           

        }

    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
