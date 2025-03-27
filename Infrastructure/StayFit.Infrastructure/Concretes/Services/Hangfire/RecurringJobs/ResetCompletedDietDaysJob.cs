using MediatR;
using Microsoft.Extensions.Logging;
using StayFit.Application.Features.Commands.DietDays.ResetCompletedDietDays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Infrastructure.Concretes.Services.Hangfire.RecurringJobs
{
    public class ResetCompletedDietDaysJob
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ResetCompletedDietDaysJob> _logger;

        public ResetCompletedDietDaysJob(IMediator mediator, ILogger<ResetCompletedDietDaysJob> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Run()
        {
            var response = await _mediator.Send(new ResetCompletedDietDaysCommandRequest());
            _logger.LogInformation("Reset completed diet days result: {Response}, {Success}", response.Message,response.Success);
        }
    }
}
