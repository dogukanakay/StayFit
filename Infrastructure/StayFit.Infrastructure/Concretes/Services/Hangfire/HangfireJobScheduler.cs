using Hangfire;
using StayFit.Application.Abstracts.Services.Hangfire;
using System.Linq.Expressions;

namespace StayFit.Infrastructure.Concretes.Services.Hangfire
{
    public class HangfireJobScheduler : IJobSchedulerService
    {
        private readonly IBackgroundJobClient _backgroundJobClient;

        public HangfireJobScheduler(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }

        public void Enqueue<T>(Expression<Action<T>> methodCall)
        {
            _backgroundJobClient.Enqueue(methodCall);
        }
    }

}
