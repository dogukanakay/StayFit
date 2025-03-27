using MediatR;
using System.Linq.Expressions;

namespace StayFit.Application.Abstracts.Services.Hangfire
{
    public interface IJobSchedulerService
    {
        void Enqueue<T>(Expression<Action<T>> methodCall);
        void ScheduleRecurringJobs();

        void ExecuteTask<TRequest, TResponse>(string taskName) where TRequest : IRequest<TResponse>, new();

    }

}
