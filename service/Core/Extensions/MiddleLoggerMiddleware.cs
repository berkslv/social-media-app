using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Core.Extensions
{
    // Şuanlık kullanımda değildir.
    public class MiddleLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MiddleLoggerMiddleware> _logger;

        public MiddleLoggerMiddleware(RequestDelegate next, ILogger<MiddleLoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {;
            await _next(context);

            _logger.LogInformation("Response");
        }
    }

    public static class MiddleLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleLogger(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddleLoggerMiddleware>();
        }
    }
}