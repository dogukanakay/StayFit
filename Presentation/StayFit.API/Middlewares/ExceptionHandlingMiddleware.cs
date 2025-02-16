using FluentValidation;
using StayFit.Application.Commons.Exceptions.Auths;
using StayFit.Application.Commons.Exceptions.Business;
using System.Net;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
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

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex switch
            {
                BusinessException => (int)HttpStatusCode.BadRequest,  
                ForbiddenAccessException => (int)HttpStatusCode.Forbidden,  
                _ => (int)HttpStatusCode.InternalServerError
            };

            var response = new
            {
                error = ex.Message,
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
