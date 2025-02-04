using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.DietDays.UpdateDietDayCompleted
{
    public class UpdateDietDayCompletedCommandHandler : IRequestHandler<UpdateDietDayCompletedCommandRequest, UpdateDietDayCompletedCommandResponse>
    {
        private readonly IDietDayRepository _dietDayRepository;

        public UpdateDietDayCompletedCommandHandler(IDietDayRepository dietDayRepository)
        {
            _dietDayRepository = dietDayRepository;
        }

        public async Task<UpdateDietDayCompletedCommandResponse> Handle(UpdateDietDayCompletedCommandRequest request, CancellationToken cancellationToken)
        {
            DietDay dietDay = await _dietDayRepository
                .GetSingleAsync(dd => dd.Id == request.DietDayId && dd.DietPlan.MemberId == request.MemberId && dd.DayOfWeek == DateTime.Today.DayOfWeek);

            if (dietDay is null)
                return new(Messages.DietDayCannotCompleted , false);

            dietDay.IsCompleted = true;

            int result = await _dietDayRepository.SaveAsync();
            
            return result>0 ? new(Messages.DietDayComletedSuccessful,  true) : new(Messages.DietDayComletedFailed, false);
        }
    }
}
