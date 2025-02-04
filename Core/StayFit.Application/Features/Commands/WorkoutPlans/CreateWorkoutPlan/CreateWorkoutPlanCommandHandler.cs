using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
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
                (Guid.Parse(request.CreateWorkoutPlanDto.MemberId), request.CreateWorkoutPlanDto.StartDate, request.CreateWorkoutPlanDto.EndDate))
                return new(Messages.WorkoutPlanAlreadyExist, false);

            WorkoutPlan workoutPlan = _mapper.Map<WorkoutPlan>(request.CreateWorkoutPlanDto);
            workoutPlan.Status = PlanStatus.Active;
            await _workoutPlanRepository.AddAsync(workoutPlan);
            int result = await _workoutPlanRepository.SaveAsync();
            
            return result > 0 ? new(Messages.WorkoutPlanCreatedSuccessful, true) : new(Messages.WorkoutPlanCreateFailed, false);
        }
    }
}
