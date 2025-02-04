using System.Linq.Expressions;

namespace StayFit.Application.Abstracts.Services.Hangfire
{
    public interface IJobSchedulerService
    {
        void Enqueue<T>(Expression<Action<T>> methodCall);
    }

}
