using MediatR;
using StayFit.Application.DTOs.DietPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Features.Commands.DietPlans.CreateDietPlan
{
    public class CreateDietPlanCommandRequest : IRequest<CreateDietPlanCommandResponse>
    {
        public CreateDietPlanDto CreateDietPlanDto { get; }
        public Guid MemberId { get; }
        public Guid TrainerId { get; }
        public CreateDietPlanCommandRequest(CreateDietPlanDto createDietPlanDto, Guid trainerId)
        {
            CreateDietPlanDto = createDietPlanDto;
            MemberId = Guid.Parse(createDietPlanDto.MemberId);
            TrainerId = trainerId;
        }
    }
}
