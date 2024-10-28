using Microsoft.EntityFrameworkCore;
using StayFit.Application.Models;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Persistence.Contexts;
using StayFit.Persistence.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Persistence.Services
{
    public class AuthService // : IAuthRepository
    {
        private readonly StayFitDbContext _context;
        private readonly JwtTokenGenerator _jwtGenerator;

        public AuthService(StayFitDbContext context, JwtTokenGenerator jwtGenerator)
        {
            _context = context;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<TokenModel> Login(LoginModel loginModel)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(u=>u.Email == loginModel.Email);
            if (user == null)
                throw new Exception("Böyle bir kullanıcı yok");
            if(HashingHelper.VerifyPasswordHash(loginModel.Password, user.PasswordHash, user.PasswordSalt))
            {

                return new()
                {
                    Message ="Giriş Başarılı",
                    Success = true,
                    Token = await _jwtGenerator.GenerateToken(user)
                };
            }
            throw new Exception("Hatalı şifre");

        }

        //public async Task<string> StudentRegister(StudentRegisterModel studentRegisterModel)
        //{
        //    byte[] passwordHash, passwordSalt;
        //    HashingHelper.CreatePasswordHash(studentRegisterModel.Password, out passwordHash, out passwordSalt);
        //    User user = new()
        //    {
        //        BirthDate = studentRegisterModel.BirthDate,
        //        FirstName = studentRegisterModel.FirstName,
        //        LastName = studentRegisterModel.LastName,
        //        Email = studentRegisterModel.Email,
        //        Gender = studentRegisterModel.Gender,
        //        Phone = studentRegisterModel.Phone,
        //        Status = true,
        //        PasswordHash = passwordHash,
        //        PasswordSalt = passwordSalt,
        //        IsEmailConfirmed = true,
        //        CreatedDate = DateTime.UtcNow
        //    };

        //    await _context.AddAsync<User>(user);

        //    Member student = new()
        //    {
        //        CreatedDate = user.CreatedDate,
        //        Id = user.Id,
        //        Height = studentRegisterModel.Height,
        //        Weight = studentRegisterModel.Weight,
        //    };

        //    await _context.AddAsync<Member>(student);

        //    await _context.SaveChangesAsync();

        //    return "Kayıt başarılı";
        //}

        //public async Task<string> TrainerRegister(TrainerRegisterModel trainerRegisterModel)
        //{
        //    byte[] passwordHash, passwordSalt;
        //    HashingHelper.CreatePasswordHash(trainerRegisterModel.Password, out passwordHash, out passwordSalt);
        //    User user = new()
        //    {
        //        BirthDate = trainerRegisterModel.BirthDate,
        //        FirstName = trainerRegisterModel.FirstName,
        //        LastName = trainerRegisterModel.LastName,
        //        Email = trainerRegisterModel.Email,
        //        Gender = trainerRegisterModel.Gender,
        //        Phone = trainerRegisterModel.Phone,
        //        Status = true,
        //        PasswordHash = passwordHash,
        //        PasswordSalt = passwordSalt,
        //        IsEmailConfirmed = true,
        //        CreatedDate = DateTime.UtcNow
        //    };

        //    await _context.AddAsync<User>(user);

        //    Trainer trainer = new()
        //    {
        //        Id = user.Id,
        //        Bio = trainerRegisterModel.Bio,
        //        CreatedDate = user.CreatedDate,
        //        MonthlyRate = trainerRegisterModel.MonthlyRate,
        //        Rate = 3,
        //        YearsOfExperience = trainerRegisterModel.YearsOfExperience,
        //    };

        //    await _context.AddAsync<Trainer>(trainer);

        //    await _context.SaveChangesAsync();
        //    return "Kayıt Başarılı";
        //}
    }
}
