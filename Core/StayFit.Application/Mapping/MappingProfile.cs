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
            CreateMap<User, MemberRegisterDto>().ReverseMap();
            CreateMap<User, TrainerRegisterDto>().ReverseMap();


            CreateMap<User, TrainerResponseDto>().ReverseMap();
            CreateMap<User, MemberResponseDto>().ReverseMap();


            CreateMap<Trainer, TrainerResponseDto>().IncludeMembers(src => src.User).ReverseMap();
            CreateMap<Member, MemberResponseDto>().IncludeMembers(src => src.User).ReverseMap();

            CreateMap<Subscription, CreateSubscriptionDto>().ReverseMap();
            CreateMap<Subscription, GetTrainerSubscribersDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Member.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Member.User.LastName))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Member.User.BirthDate))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Member.User.Gender))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Member.Height))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Member.Weight))
                .ReverseMap();
        }
    }
}
