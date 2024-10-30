using AutoMapper;
using StayFit.Application.DTOs;
using StayFit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User,MemberRegisterDto>().ReverseMap();
            CreateMap<User,TrainerRegisterDto>().ReverseMap();


            CreateMap<User,TrainerResponseDto>().ReverseMap();
            CreateMap<User,MemberResponseDto>().ReverseMap();


            CreateMap<Trainer, TrainerResponseDto>().IncludeMembers(src=>src.User).ReverseMap();
            CreateMap<Member, MemberResponseDto>().IncludeMembers(src=>src.User).ReverseMap();
        }
    }
}
