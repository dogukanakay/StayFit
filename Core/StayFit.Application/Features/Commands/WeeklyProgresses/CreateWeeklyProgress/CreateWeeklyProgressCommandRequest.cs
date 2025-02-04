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
        public IFormFileCollection Images { get; }
        public CreateWeeklyProgressDto CreateWeeklyProgressDto { get; }
        public string BaseStorageUrl { get; }
        public Guid? UserId { get; }

        public CreateWeeklyProgressCommandRequest(IFormFileCollection images, 
            CreateWeeklyProgressDto createWeeklyProgressDto, 
            string baseStorageUrl, 
            Guid? userId)
        {
            Images = images;
            CreateWeeklyProgressDto = createWeeklyProgressDto;
            BaseStorageUrl = baseStorageUrl;
            UserId = userId;
        }
    }
}
