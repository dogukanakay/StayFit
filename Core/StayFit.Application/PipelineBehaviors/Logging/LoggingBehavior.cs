using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Security.Claims;

namespace StayFit.Application.PipelineBehaviors.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggingBehavior(
            ILogger<LoggingBehavior<TRequest, TResponse>> logger,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            _logger.LogInformation(
                "Request: {RequestName} by User = {@UserId}",
                requestName,
                userId
                );

            try
            {
                var sw = Stopwatch.StartNew();
                var response = await next();
                sw.Stop();

                _logger.LogInformation(
                    "Completed: {RequestName} by User = {@UserId} - Execution Time: {ElapsedMilliseconds}ms",
                    requestName,
                    userId,
                    sw.ElapsedMilliseconds);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error: {RequestName} by User = {@UserId} - Message: {Message}",
                    requestName,
                    userId,
                    ex.Message);

                throw;
            }
        }
    }
}
