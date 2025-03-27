using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Repositories;

namespace StayFit.Application.Features.Commands.DietDays.ResetCompletedDietDays
{
    public class ResetCompletedDietDaysCommandHandler : IRequestHandler<ResetCompletedDietDaysCommandRequest, ResetCompletedDietDaysCommandResponse>
    {
        private readonly IDietDayRepository _dietDayRepository;

        public ResetCompletedDietDaysCommandHandler(IDietDayRepository dietDayRepository)
        {
            _dietDayRepository = dietDayRepository;
        }

        public async Task<ResetCompletedDietDaysCommandResponse> Handle(ResetCompletedDietDaysCommandRequest request, CancellationToken cancellationToken)
        {
            int countOfResetedDietDay = await _dietDayRepository.ResetCompletedDietDaysAsync();

            if (countOfResetedDietDay > 0)
                return new($"{countOfResetedDietDay} {Messages.DietDaysResetedSuccesfuly}", true);
            return new(Messages.DietDaysReseteFailed, false);
        }
    }
}
