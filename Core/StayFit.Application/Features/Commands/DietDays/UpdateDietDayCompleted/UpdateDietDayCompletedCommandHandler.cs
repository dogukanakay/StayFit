using MediatR;
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
                .GetSingleAsync(dd => dd.Id == request.DietDayId && dd.DietPlan.MemberId == request.MemberId);

            if (dietDay is null)
                return new("Gün bulunamadı.", false);

            dietDay.IsCompleted = true;

            int result = await _dietDayRepository.SaveAsync();
            
            return result>0 ? new("Gün tamamlandı olarak güncellendi.",  true) : new("İşlem başarısız.", false);
        }
    }
}
