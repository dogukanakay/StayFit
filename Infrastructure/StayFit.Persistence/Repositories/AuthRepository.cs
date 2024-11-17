﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StayFit.Application.DTOs;
using StayFit.Application.Exceptions;
using StayFit.Application.Repositories;
using StayFit.Domain.Entities;
using StayFit.Domain.Enums;
using StayFit.Persistence.Contexts;

namespace StayFit.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly StayFitDbContext _context;


        public AuthRepository(StayFitDbContext context)
        {
            _context = context;
         
        }

        public async Task<bool> CheckIfEmailAlreadyExist(string email)
            => await _context.Set<User>().AnyAsync(u => u.Email == email);


        public async Task<bool> CheckIfPhoneAlreadyExist(string phone)
            => await _context.Set<User>().AnyAsync(u => u.Phone == phone);

        public async Task<User> GetUserByEmail(string email)
            => await _context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);

       

        public async Task<int> MemberRegisterAsync(Member member)
        {
            await _context.Members.AddAsync(member);

            

            return await _context.SaveChangesAsync();
        }

        public async Task<string> TrainerRegisterAsync(TrainerRegisterDto trainerRegisterDto)
        {

//            if (await CheckIfEmailAlreadyExist(trainerRegisterDto.Email))
//                throw new EmailAlreadyExistException();
//            if (await CheckIfPhoneAlreadyExist(trainerRegisterDto.Phone))
//                throw new PhoneAlreadyExistException();

//            byte[] passwordHash, passwordSalt;
//     //       HashingHelper.CreatePasswordHash(trainerRegisterDto.Password, out passwordHash, out passwordSalt);
//            User user = new()
//            {
//                BirthDate = trainerRegisterDto.BirthDate,
//                FirstName = trainerRegisterDto.FirstName,
//                LastName = trainerRegisterDto.LastName,
//                Email = trainerRegisterDto.Email,
//                Gender = trainerRegisterDto.Gender,
//                Phone = trainerRegisterDto.Phone,
//                Status = UserStatus.Active,
//                PasswordHash = passwordHash,
//                PasswordSalt = passwordSalt,
//                IsEmailConfirmed = true,
//                CreatedDate = DateTime.UtcNow,
//                UserRole = UserRole.Trainer
//            };

////            await _context.AddAsync<User>(user);

//            Trainer trainer = new()
//            {
//                User = user,
//                Bio = trainerRegisterDto.Bio,
//                CreatedDate = user.CreatedDate,
//                MonthlyRate = trainerRegisterDto.MonthlyRate,
//                Rate = 3,
//                YearsOfExperience = trainerRegisterDto.YearsOfExperience,
//                Specializations = trainerRegisterDto.Specializations,
//            };

//            await _context.AddAsync<Trainer>(trainer);

//            await _context.SaveChangesAsync();
            return "Kayıt Başarılı";
        }



        
    }
}
