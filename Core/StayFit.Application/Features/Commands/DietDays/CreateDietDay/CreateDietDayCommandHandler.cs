using AutoMapper;
using MediatR;
using StayFit.Application.Commons.Exceptions.Auths;
using StayFit.Application.Commons.Exceptions.Business;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.DietDays.CreateDietDay
{
    public class CreateDietDayCommandHandler : IRequestHandler<CreateDietDayCommandRequest, CreateDietDayCommandResponse>
    {
        private readonly IDietDayRepository _dietDayRepository;
        private readonly IDietPlanRepository _dietPlanRepository;
        private readonly IMapper _mapper;

        public CreateDietDayCommandHandler(IDietDayRepository dietDayRepository, IMapper mapper, IDietPlanRepository dietPlanRepository)
        {
            _dietDayRepository = dietDayRepository;
            _mapper = mapper;
            _dietPlanRepository = dietPlanRepository;
        }

        public async Task<CreateDietDayCommandResponse> Handle(CreateDietDayCommandRequest request, CancellationToken cancellationToken)
        {
            var dietPlan = await _dietPlanRepository.GetByIdAsync(request.CreateDietDayDto.DietPlanId, false);

            if (dietPlan is null)
                return new(Messages.DietPlanNotFoundById, false);

            if (dietPlan.TrainerId != request.TrainerId)
                throw new ForbiddenAccessException();

            if (await _dietDayRepository.CheckIfDietDayAlreadyExistAsync(request.CreateDietDayDto.DietPlanId, request.CreateDietDayDto.DayOfWeek))
                return new(Messages.DietDayAlreadyExist, false);

            DietDay dietDay = _mapper.Map<DietDay>(request.CreateDietDayDto);
            await _dietDayRepository.AddAsync(dietDay);

            int result = await _dietDayRepository.SaveAsync();


            return result > 0 ? new(Messages.DietDayCreatedSuccessful, true) : new(Messages.DietDayCreatedFailed, false);
        }
    }
}
