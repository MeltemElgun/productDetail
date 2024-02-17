using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using productDetail.Domain.Exceptions;

namespace productDetail.Middleware
{
    public static class UseCustomExceptionMiddleware 
    {
        public static void UseCustomException(this IApplicationBuilder app) 
        {
            app.UseExceptionHandler(appError => {

                appError.Run(async context => { 
                    
                    context.Response.ContentType = "application/json";
                    var exception = context.Features.Get<IExceptionHandlerFeature>();

                    if(exception != null)
                    {
                        var statusCode = exception.Error.GetType().Name switch
                        {
                            nameof(CustomException) => HttpStatusCode.BadRequest,
                            nameof(NullReferenceException) => HttpStatusCode.NotFound,
                            nameof(ArgumentException) => HttpStatusCode.BadRequest,

                            _ => HttpStatusCode.InternalServerError
                        };

                        var message = exception.Error.GetType().Name switch
                        {
                            nameof(CustomException) => exception.Error.Message,
                            nameof(NullReferenceException) => "Category cannot be null or empty.",
                            nameof(ArgumentException) => "Invalid category provided.",
                            _ => "An unexpected error occurred",

                        };

                        context.Response.StatusCode = (int)statusCode;
                        var errorObj = new
                        {
                            StatusCode = statusCode,
                            Message = message
                        };
                        await context.Response.WriteAsJsonAsync(errorObj);
                        Console.WriteLine(exception.Error.Message);
                    }
                });    
            });
        }

        public static void UseTimeElapsedCalculate(this IApplicationBuilder app)
        {
            app.Use(async (ctx, next) => {
                var startTimeStamp = DateTime.Now;

                await next();

                var endTimeStamp = DateTime.Now;
                var elapsed = endTimeStamp - startTimeStamp;
                
            });
        }
    }


}
