using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Extensions;
using VideoManagementApi.Domain.Enums;

namespace VideoManagementApi.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await GeneralException(context, ex);
        }
    }

    private async Task GeneralException(HttpContext context, Exception exception)
    {
        var problemDetails = new
        {
            ResultSteecvatus = ResultStatus.Error,
            Message = exception.Message,
            Detail = exception.StackTrace,
            StatusCode = HttpStatusCode.InternalServerError,
            Href = context.Request.GetDisplayUrl()
        };

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(problemDetails);

        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(result);
    }
}