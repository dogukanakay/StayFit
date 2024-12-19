﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StayFit.Application.PipelineBehaviors.Caching;
using StayFit.Application.PipelineBehaviors.Logging;
using StayFit.Application.PipelineBehaviors.Performance;
using System.Reflection;

namespace StayFit.Application
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(CacheBehavior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(CacheRemoveBehavior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            });

            

        }
    }
}
