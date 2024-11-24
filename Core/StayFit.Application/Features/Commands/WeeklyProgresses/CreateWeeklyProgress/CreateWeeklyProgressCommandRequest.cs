using MediatR;
using Microsoft.AspNetCore.Http;
using StayFit.Application.DTOs.WeeklyProgresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.WeeklyProgresses.CreateWeeklyProgress
{
    public class CreateWeeklyProgressCommandRequest : IRequest<CreateWeeklyProgressCommandResponse>
    {
        public IFormFileCollection Images { get; set; }
        public CreateWeeklyProgressDto CreateWeeklyProgressDto { get; set; }
        public string BaseStorageUrl { get; set; }
    }
}
