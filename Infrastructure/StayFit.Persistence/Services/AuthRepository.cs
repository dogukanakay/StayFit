using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StayFit.Application.DTOs;
using StayFit.Application.Exceptions;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Domain.Enums;
using StayFit.Persistence.Contexts;
using StayFit.Persistence.Helpers;

namespace StayFit.Persistence.Services
{
    public class AuthRepository  : IAuthRepository
    {
        private readonly StayFitDbContext _context;
        private readonly JwtTokenGenerator _jwtGenerator;
        private readonly IMapper _mapper;

        public AuthRepository(StayFitDbContext context, JwtTokenGenerator jwtGenerator, IMapper mapper)
        {
            _context = context;
            _jwtGenerator = jwtGenerator;
            _mapper = mapper;
        }

        public async Task<bool> CheckIfEmailAlreadyExist(string email)
            => await _context.Set<User>().AnyAsync(u => u.Email == email);


        public async Task<bool> CheckIfPhoneAlreadyExist(string phone)
            => await _context.Set<User>().AnyAsync(u => u.Phone == phone); 

        public async Task<TokenDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(u=>u.Email == loginDto.Email);
            if (user == null)
                throw new UserNotFoundException();
            if(HashingHelper.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
            {

                return new()
                {
                    Message ="Giriş Başarılı",
                    Success = true,
                    Token = await _jwtGenerator.GenerateToken(user)
                };
            }
            throw new UserNotFoundException("Hatalı şifre veya kullanıcı adı.");

        }

        public async Task<string> MemberRegisterAsync(MemberRegisterDto memberRegisterDto)
        {
            if(await CheckIfEmailAlreadyExist(memberRegisterDto.Email))
                throw new EmailAlreadyExistException();
            if(await CheckIfPhoneAlreadyExist(memberRegisterDto.Phone))
                throw new PhoneAlreadyExistException();

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(memberRegisterDto.Password, out passwordHash, out passwordSalt);

            User user = _mapper.Map<User>(memberRegisterDto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Status = UserStatus.Active;
            user.IsEmailConfirmed = true;
            user.UserRole = UserRole.Member;
           

           

            await _context.Users.AddAsync(user);

            Member member = new()
            {
                CreatedDate = user.CreatedDate,
                Id = user.Id,
                Height = memberRegisterDto.Height,
                Weight = memberRegisterDto.Weight,
            };

            await _context.Members.AddAsync(member);

            await _context.SaveChangesAsync();

            return "Kayıt başarılı";
        }

        public async Task<string> TrainerRegisterAsync(TrainerRegisterDto trainerRegisterDto)
        {

            if (await CheckIfEmailAlreadyExist(trainerRegisterDto.Email))
                throw new EmailAlreadyExistException();
            if (await CheckIfPhoneAlreadyExist(trainerRegisterDto.Phone))
                throw new PhoneAlreadyExistException();

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(trainerRegisterDto.Password, out passwordHash, out passwordSalt);
            User user = new()
            {
                BirthDate = trainerRegisterDto.BirthDate,
                FirstName = trainerRegisterDto.FirstName,
                LastName = trainerRegisterDto.LastName,
                Email = trainerRegisterDto.Email,
                Gender = trainerRegisterDto.Gender,
                Phone = trainerRegisterDto.Phone,
                Status = UserStatus.Active,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsEmailConfirmed = true,
                CreatedDate = DateTime.UtcNow,
                UserRole = UserRole.Trainer
            };

//            await _context.AddAsync<User>(user);

            Trainer trainer = new()
            {
                User = user,
                Bio = trainerRegisterDto.Bio,
                CreatedDate = user.CreatedDate,
                MonthlyRate = trainerRegisterDto.MonthlyRate,
                Rate = 3,
                YearsOfExperience = trainerRegisterDto.YearsOfExperience,
                Specializations = trainerRegisterDto.Specializations,
            };

            await _context.AddAsync<Trainer>(trainer);

            await _context.SaveChangesAsync();
            return "Kayıt Başarılı";
        }



        
    }
}
