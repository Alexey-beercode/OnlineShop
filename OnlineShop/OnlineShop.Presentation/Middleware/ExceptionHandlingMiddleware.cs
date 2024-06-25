using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlineShop.BLL.Exceptions;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        
        var response = context.Response;

        switch (exception)
        {
            case EntityNotFoundException entityNotFoundException:
                response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            case FormatException formatException:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case ValidationException validationException:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case UnauthorizedAccessException unauthorizedAccessException:
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                break;
            case AuthenticationException authenticationException:
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                break;
            case OrderAlreadyCancelledException orderAlreadyCancelledException:
                response.StatusCode = (int)HttpStatusCode.Conflict;
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        var result = JsonConvert.SerializeObject(new 
        {
            error = exception.Message,
            details = exception.StackTrace
        });

        return context.Response.WriteAsync(result);
    }
}