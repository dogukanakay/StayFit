using AutoMapper;
using MediatR;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Domain.Enums;

namespace StayFit.Application.Features.Commands.WorkoutPlans.CreateWorkoutPlan
{
    public class CreateWorkoutPlanCommandHandler : IRequestHandler<CreateWorkoutPlanCommandRequest, CreateWorkoutPlanCommandResponse>
    {
        private readonly IWorkoutPlanRepository _workoutPlanRepository;
        private readonly IMapper _mapper;

        public CreateWorkoutPlanCommandHandler(IWorkoutPlanRepository workoutPlanRepository, IMapper mapper)
        {
            _workoutPlanRepository = workoutPlanRepository;
            _mapper = mapper;
        }

        public async Task<CreateWorkoutPlanCommandResponse> Handle(CreateWorkoutPlanCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _workoutPlanRepository.CheckIfAlreadyExistPlanOnTimeRange
                (Guid.Parse(request.CreateWorkoutPlanDto.MemberId),request.CreateWorkoutPlanDto.StartDate, request.CreateWorkoutPlanDto.EndDate))
                return new() { Message = "Bu aralıklarda zaten bir çalışma planı var.", Success = false };
            WorkoutPlan workoutPlan = _mapper.Map<WorkoutPlan>(request.CreateWorkoutPlanDto);
            workoutPlan.Status = PlanStatus.Active;
            await _workoutPlanRepository.AddAsync(workoutPlan);
            int response = await _workoutPlanRepository.SaveAsync();
            if (response > 0)
            {
                return new() { Message = "Çalışma planı başarıyla oluşturuldu.", Success = true };
            }
            return new() { Message = "Çalışma planı oluşturulamadı", Success = false };
        }
    }
}
