using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.Features.Commands.DietDays.CreateDietDay;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.DietDays.DeleteDietDay
{
    public class DeleteDietDayCommandHandler : IRequestHandler<DeleteDietDayCommandRequest, DeleteDietDayCommandResponse>
    {
        private readonly IDietDayRepository _dietDayRepository;

        public DeleteDietDayCommandHandler(IDietDayRepository dietDayRepository)
        {
            _dietDayRepository = dietDayRepository;
        }

        public async Task<DeleteDietDayCommandResponse> Handle(DeleteDietDayCommandRequest request, CancellationToken cancellationToken)
        {
            DietDay dietDay = await _dietDayRepository.GetByIdAsync(request.DietDayId);
            if (dietDay == null)
                return new(Messages.DietDayNotFound, false);

            await _dietDayRepository.Remove(dietDay);

            int result = await _dietDayRepository.SaveAsync();

            return result > 0 ? new(Messages.DietDayDeletedSuccessful, true) : new(Messages.DietDayDeletedFailed, false);
        }
    }
}
