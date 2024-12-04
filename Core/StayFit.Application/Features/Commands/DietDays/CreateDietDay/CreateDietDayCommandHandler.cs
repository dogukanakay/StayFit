using AutoMapper;
using MediatR;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.DietDays.CreateDietDay
{
    public class CreateDietDayCommandHandler : IRequestHandler<CreateDietDayCommandRequest, CreateDietDayCommandResponse>
    {
        private readonly IDietDayRepository _dietDayRepository;
        private readonly IMapper _mapper;

        public CreateDietDayCommandHandler(IDietDayRepository dietDayRepository, IMapper mapper)
        {
            _dietDayRepository = dietDayRepository;
            _mapper = mapper;
        }

        public async Task<CreateDietDayCommandResponse> Handle(CreateDietDayCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _dietDayRepository.CheckIfDietDayAlreadyExistAsync(request.CreateDietDayDto.DietPlanId, request.CreateDietDayDto.DayOfWeek))
                return new() { Message = " Diyet Günü oluşturulurken bir hata ile karşılaşıldı. Bu gün zaten var. Aynı gün tekrardan oluşturulamaz", Success = false };

            DietDay dietDay = _mapper.Map<DietDay>(request.CreateDietDayDto);
            await _dietDayRepository.AddAsync(dietDay);

            int result = await _dietDayRepository.SaveAsync();

            if (result > 0)
                return new() { Message = $"{dietDay.Title} başlıklı diyet günü başarıyla oluşturuldu", Success = true };
            return new() { Message = " Diyet Günü oluşturulurken bir hata ile karşılaşıldı.", Success = false };
        }
    }
}
