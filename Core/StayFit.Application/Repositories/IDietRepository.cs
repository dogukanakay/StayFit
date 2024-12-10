using StayFit.Domain.Entities;

namespace StayFit.Application.Repositories
{
    public interface IDietRepository : IGenericRepository<Diet>
    {
        Task AddRangeAsync(List<Diet> dietList);
        Task<List<Diet>> GetTodaysDietsAsync(Guid memberId);

    }
}
