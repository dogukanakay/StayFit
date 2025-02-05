using Microsoft.EntityFrameworkCore;
using StayFit.Application.Abstracts.Security;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Persistence.Contexts;

namespace StayFit.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly StayFitDbContext _context;
        private readonly IHashingHelper _hashingHelper;

        public AuthRepository(StayFitDbContext context, IHashingHelper hashingHelper)
        {
            _context = context;
            _hashingHelper = hashingHelper;
        }

        public async Task<bool> CheckIfEmailAlreadyExist(string email)
            => await _context.Set<User>().AnyAsync(u => u.Email == email);


        public async Task<bool> CheckIfPhoneAlreadyExist(string phone)
            => await _context.Set<User>().AnyAsync(u => u.Phone == phone);

        public async Task<User> GetUserByEmail(string email)
            => await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<int> MemberRegisterAsync(Member member)
        {
            await _context.Members.AddAsync(member);


            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
             => await _context.SaveChangesAsync();

        public async Task<int> TrainerRegisterAsync(Trainer trainer)
        {

            await _context.Trainers.AddAsync(trainer);


            return await _context.SaveChangesAsync();
        }




    }
}
