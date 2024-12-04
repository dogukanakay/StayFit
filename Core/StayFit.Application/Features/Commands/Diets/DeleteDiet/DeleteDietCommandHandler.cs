using MediatR;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;

namespace StayFit.Application.Features.Commands.Diets.DeleteDiet
{
    public class DeleteDietCommandHandler : IRequestHandler<DeleteDietCommandRequest, DeleteDietCommandResponse>
    {
        private readonly IDietRepository _dietRepository;

        public DeleteDietCommandHandler(IDietRepository dietRepository)
        {
            _dietRepository = dietRepository;
        }

        public async Task<DeleteDietCommandResponse> Handle(DeleteDietCommandRequest request, CancellationToken cancellationToken)
        {
            Diet diet = await _dietRepository.GetByIdAsync(request.DietId);
            if (diet == null)
                return new("Bu id'ye ait bir diyet bulunamadı", false);

            await _dietRepository.Remove(diet);
            int result = await _dietRepository.SaveAsync();

            return result > 0 ? new("Diyet başarıyla silindi.", true) : new("Diyet silinirken bir hata oluştu.", false);

        }
    }
}
