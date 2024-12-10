using System.Diagnostics;
using System.Text.Json;
using MicroServiceWorkOrder.Shared.Exceptions;
using MicroServiceWorkOrder.Shared.Models;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    private readonly IWebHostEnvironment _env;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger, IWebHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var traceId = Activity.Current?.Id ?? context.TraceIdentifier;

        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, traceId);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex, string traceId)
    {
        //log
        _logger.LogError($"Error with TraceId {traceId}: {ex}");
        
        //management custom errors and handleError
        // var response = new ErrorResponseModel()
        // {
        //     Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
        //     Title = "An error occurred while processing your request.",
        //     Status = StatusCodes.Status500InternalServerError,
        //     TraceId = traceId,
        //     Detail = _env.IsDevelopment() ? ex.ToString() : "An unexpected error occurred. Please contact support if the issue persists."
        // };
        
        //pattern matching
        var response = ex switch
        {
            NotFoundException notFoundEx => new ErrorResponseModel
            {
                Title = "Resource Not Found",
                Status = StatusCodes.Status404NotFound,
                TraceId = traceId,
                Detail = notFoundEx.Message,
                Date = notFoundEx.Date
            },
            _ => new ErrorResponseModel
            {
                Title = "Internal Server Error",
                Status = StatusCodes.Status500InternalServerError,
                TraceId = traceId,
                Detail = _env.IsDevelopment() ? ex.ToString() : "An unexpected error occurred. Please contact support if the issue persists."
            }
        };
        
        //config status code and headers
        context.Response.StatusCode = response.Status;
        context.Response.ContentType = "application/json";

         //serialize
        var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true 
        });

        await context.Response.WriteAsync(jsonResponse);
    }
}