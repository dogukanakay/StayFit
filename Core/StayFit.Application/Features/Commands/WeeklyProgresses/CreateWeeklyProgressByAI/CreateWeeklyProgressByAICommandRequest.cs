using MediatR;
using Microsoft.AspNetCore.Http;
using StayFit.Application.DTOs.WeeklyProgresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.WeeklyProgresses.CreateWeeklyProgressByAI
{
    public class CreateWeeklyProgressByAICommandRequest : IRequest<CreateWeeklyProgressByAICommandResponse>
    {
        public CreateWeeklyProgressByAIDto CreateWeeklyProgressByAIDto { get; }
        public IFormFileCollection Images { get; }
        public string BaseStorageUrl { get; }
        public Guid UserId { get; }

        public CreateWeeklyProgressByAICommandRequest(CreateWeeklyProgressByAIDto createWeeklyProgressByAIDto, IFormFileCollection images, string baseStorageUrl, Guid userId)
        {
            CreateWeeklyProgressByAIDto = createWeeklyProgressByAIDto;
            Images = images;
            BaseStorageUrl = baseStorageUrl;
            UserId = userId;
        }
    }
}
