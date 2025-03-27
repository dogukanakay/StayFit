using MediatR;
using Microsoft.Extensions.Logging;
using StayFit.Application.Features.Commands.WorkoutDays.ResetCompletedWorkoutDays;

namespace StayFit.Infrastructure.Concretes.Services.Hangfire.RecurringJobs
{
    public class ResetCompletedWorkoutDaysJob
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ResetCompletedDietDaysJob> _logger;

        public ResetCompletedWorkoutDaysJob(IMediator mediator, ILogger<ResetCompletedDietDaysJob> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Run()
        {
            var response = await _mediator.Send(new ResetCompletedWorkoutDaysCommandRequest());
            _logger.LogInformation("Reset completed workout days result: {Response}, {Success}", response.Message, response.Success);
        }
    }
}
