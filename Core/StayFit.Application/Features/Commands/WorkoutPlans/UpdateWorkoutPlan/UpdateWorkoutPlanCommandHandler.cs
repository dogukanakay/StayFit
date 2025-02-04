using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
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
                return new(Messages.WorkoutPlanNotFoundById, false);
            _mapper.Map(request.UpdateWorkoutPlanDto, workoutPlan);

            int result = await _workoutPlanRepository.SaveAsync();

            return result > 0 ? new(Messages.WorkoutPlanUpdatedSuccessful, true) : new(Messages.WorkoutPlanUpdateFailed, false); 
        }
    }
}
