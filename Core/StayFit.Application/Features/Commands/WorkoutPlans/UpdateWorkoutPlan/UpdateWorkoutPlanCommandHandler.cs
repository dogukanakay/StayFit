using AutoMapper;
using MediatR;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.WorkoutPlans.UpdateWorkoutPlan
{
    public class UpdateWorkoutPlanCommandHandler : IRequestHandler<UpdateWorkoutPlanCommandRequest, UpdateWorkoutPlanCommandResponse>
    {
        private readonly IWorkoutPlanRepository _workoutPlanRepository;
        private readonly IMapper _mapper;

        public UpdateWorkoutPlanCommandHandler(IWorkoutPlanRepository workoutPlanRepository, IMapper mapper)
        {
            _workoutPlanRepository = workoutPlanRepository;
            _mapper = mapper;
        }

        public async Task<UpdateWorkoutPlanCommandResponse> Handle(UpdateWorkoutPlanCommandRequest request, CancellationToken cancellationToken)
        {
            WorkoutPlan workoutPlan = await _workoutPlanRepository.GetByIdAsync(request.UpdateWorkoutPlanDto.Id);
            if (workoutPlan is null)
                return new() { Message = "Hatalı bir istek yolladınız. Bu Id için bir plan bulunmamakta.", Success = false };
            _mapper.Map(request.UpdateWorkoutPlanDto, workoutPlan);

            int result = await _workoutPlanRepository.SaveAsync();
            if (result > 0)
                return new() { Message = "Plan başarıyla güncellendi.", Success = true };
            return new() { Message = "Plan  güncellenemedi.", Success = false };
        }
    }
}
