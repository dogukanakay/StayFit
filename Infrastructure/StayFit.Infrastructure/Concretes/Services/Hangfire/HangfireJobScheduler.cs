using Hangfire;
using MediatR;
using Microsoft.Extensions.Logging;
using StayFit.Application.Abstracts.Services.Hangfire;
using StayFit.Application.Features.Commands.DietDays.ResetCompletedDietDays;
using StayFit.Application.Features.Commands.WorkoutDays.ResetCompletedWorkoutDays;
using StayFit.Infrastructure.Concretes.Services.Hangfire.RecurringJobs;
using System.Linq.Expressions;

namespace StayFit.Infrastructure.Concretes.Services.Hangfire
{
    public class HangfireJobScheduler : IJobSchedulerService
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IMediator _mediator;
        private readonly ILogger<HangfireJobScheduler> _logger;

        public HangfireJobScheduler(IBackgroundJobClient backgroundJobClient, IMediator mediator, ILogger<HangfireJobScheduler> logger)
        {
            _backgroundJobClient = backgroundJobClient;
            _mediator = mediator;
            _logger = logger;
        }

        public void Enqueue<T>(Expression<Action<T>> methodCall)
        {
            _backgroundJobClient.Enqueue(methodCall);
        }

        public void ExecuteTask<TRequest, TResponse>(string taskName) where TRequest : IRequest<TResponse>, new()
        {
            var response =  _mediator.Send(new TRequest());
            _logger.LogInformation($"{taskName} task result:", response);
        }

        public void ScheduleRecurringJobs()
        {

            RecurringJob.AddOrUpdate<ResetCompletedDietDaysJob>(
                "Reset-Completed-Diet-Days",
                job => job.Run(),
                Cron.Weekly());

            RecurringJob.AddOrUpdate<ResetCompletedWorkoutDaysJob>(
                "Reset-Completed-Workout-Days",
                job => job.Run(),
                Cron.Weekly());
                
        }
    }

}
