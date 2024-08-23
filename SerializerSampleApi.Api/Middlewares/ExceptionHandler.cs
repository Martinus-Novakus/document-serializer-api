using System.Net;
using SerializerSampleApi.Api.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace SerializerSampleApi.Api.Middlewares;

public static class ExceptionHandlerMiddleware
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(handler => handler.Run(async context =>
        {
            var handler = context.Features.Get<IExceptionHandlerFeature>();

            if (handler == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            else
            {
                var errorDetail = GetErrorDetails(handler.Error);
                context.Response.StatusCode = errorDetail.StatusCode;

                await context.Response.WriteAsync(
                    System.Text.Json.JsonSerializer.Serialize(errorDetail));
            }
        }));
    }

    private static ErrorDetails GetErrorDetails(Exception ex)
    {
        return ex switch
        {
            DocumentNotFoundException e => new ErrorDetails(HttpStatusCode.NotFound, $"{e.Message}"),
            ValidationException e => new ErrorDetails(HttpStatusCode.BadRequest, $"{e.Message}"),
            _ => new ErrorDetails(HttpStatusCode.InternalServerError, $"Internal server error."),
        };
    }
}