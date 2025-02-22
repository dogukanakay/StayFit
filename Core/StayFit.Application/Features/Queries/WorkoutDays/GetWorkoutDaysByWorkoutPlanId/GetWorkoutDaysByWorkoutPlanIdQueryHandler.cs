﻿using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.DTOs.WorkoutDays;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Queries.WorkoutDays.GetWorkoutDaysByWorkoutPlanId
{
    public class GetWorkoutDaysByWorkoutPlanIdQueryHandler : IRequestHandler<GetWorkoutDaysByWorkoutPlanIdQueryRequest, GetWorkoutDaysByWorkoutPlanIdQueryResponse>
    {
        private readonly IWorkoutDayRepository _workoutDayRepository;
        private readonly IMapper _mapper;

        public GetWorkoutDaysByWorkoutPlanIdQueryHandler(IWorkoutDayRepository workoutDayRepository, IMapper mapper)
        {
            _workoutDayRepository = workoutDayRepository;
            _mapper = mapper;
        }

        public async Task<GetWorkoutDaysByWorkoutPlanIdQueryResponse> Handle(GetWorkoutDaysByWorkoutPlanIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<WorkoutDay> workoutDays = await _workoutDayRepository.GetWhere(wd => wd.WorkoutPlanId == request.WorkoutPlanId, tracking: false);
            if (!workoutDays.Any())
                return new(Messages.WorkoutDayNotFound, false, null);
            List<GetWorkoutDaysByWorkoutPlanIdDto> getWorkoutDaysByWorkoutPlanIdDtos = _mapper.Map<List<GetWorkoutDaysByWorkoutPlanIdDto>>(workoutDays);

            return new(Messages.WorkoutDayListedSuccessful, true, getWorkoutDaysByWorkoutPlanIdDtos);
        }
    }
}
