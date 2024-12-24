using AutoMapper;
using MediatR;
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

        public async Task<CreateDietPlanCommandResponse> Handle(CreateDietPlanCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _dietPlanRepository.CheckIfAlreadyExistPlanOnTimeRange(request.CreateDietPlanDto.StartDate, request.CreateDietPlanDto.EndDate))
                return new() { Message = "Bu aralıklarda zaten bir çalışma planı var.", Success = false };
            DietPlan dietPlan = _mapper.Map<DietPlan>(request.CreateDietPlanDto);
            dietPlan.Status = PlanStatus.Active;
            await _dietPlanRepository.AddAsync(dietPlan);
            int result = await _dietPlanRepository.SaveAsync();
            if (result > 0)
                return new() { Message = "Diyet planı başarıyla oluşturuldu.", Success = true };
            return new() { Message = "Diyet planı oluşturulurken bir hatayla karşılaşıldı.", Success = false };

        }
    }
}
