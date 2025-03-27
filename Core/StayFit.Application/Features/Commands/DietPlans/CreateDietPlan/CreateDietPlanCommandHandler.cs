using AutoMapper;
using MediatR;
using StayFit.Application.Commons.CustomAttributes.Caching;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Domain.Enums;

namespace StayFit.Application.Features.Commands.DietPlans.CreateDietPlan
{
    public class CreateDietPlanCommandHandler : IRequestHandler<CreateDietPlanCommandRequest, CreateDietPlanCommandResponse>
    {
        private readonly IDietPlanRepository _dietPlanRepository;
        private readonly IMapper _mapper;

        public CreateDietPlanCommandHandler(IDietPlanRepository dietPlanRepository, IMapper mapper)
        {
            _dietPlanRepository = dietPlanRepository;
            _mapper = mapper;
        }

        //[CacheRemove("dietPlans_{MemberId}")]
        public async Task<CreateDietPlanCommandResponse> Handle(CreateDietPlanCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _dietPlanRepository.CheckIfAlreadyExistPlanOnTimeRangeAsync
                        (Guid.Parse(request.CreateDietPlanDto.MemberId), request.CreateDietPlanDto.StartDate, request.CreateDietPlanDto.EndDate))
                return new(Messages.DietPlanAlreadyExist, false);
            

            DietPlan dietPlan = _mapper.Map<DietPlan>(request.CreateDietPlanDto);
            dietPlan.Status = PlanStatus.Active;
            dietPlan.TrainerId = request.TrainerId;
            await _dietPlanRepository.AddAsync(dietPlan);
            int result = await _dietPlanRepository.SaveAsync();
            
            return result > 0  ? new(Messages.DietPlanCreatedSuccessful, true) : new(Messages.DietPlanCreatedFailed, false);

        }
    }
}
