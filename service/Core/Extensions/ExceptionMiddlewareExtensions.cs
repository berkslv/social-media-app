using System.Net;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using NLog;

namespace Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>   
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    { 
                        logger.Error($"Something went wrong: {contextFeature.Error}");
                        
                        await context.Response.WriteAsync(
                            new Result(false, contextFeature.Error.Message, (HttpStatusCode)context.Response.StatusCode).ToString()
                        );
                    }
                });
            });
        }

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>   
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    { 
                        await context.Response.WriteAsync(
                            new Result(false, contextFeature.Error.Message, (HttpStatusCode)context.Response.StatusCode).ToString()
                        );
                    }
                });
            });
        }
    }
}
