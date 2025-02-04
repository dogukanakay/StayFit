using AutoMapper;
using MediatR;
using StayFit.Application.Constants.Messages;
using StayFit.Application.CustomAttributes.Caching;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.Diets.CreateDiet
{
    public class CreateDietCommandHandler : IRequestHandler<CreateDietCommandRequest, CreateDietCommandResponse>
    {
        private readonly IDietRepository _dietRepository;
        private readonly IMapper _mapper;

        public CreateDietCommandHandler(IDietRepository dietRepository, IMapper mapper)
        {
            _dietRepository = dietRepository;
            _mapper = mapper;
        }

        public async Task<CreateDietCommandResponse> Handle(CreateDietCommandRequest request, CancellationToken cancellationToken)
        {
            List<Diet> diet = _mapper.Map<List<Diet>>(request.CreateDietDtos);
            
            await _dietRepository.AddRangeAsync(diet);

            int result = await _dietRepository.SaveAsync();

            return result > 0 ? new(Messages.DietCreatedSuccessful, true): new(Messages.DietCreatedFailed, false);
        }
    }
}
