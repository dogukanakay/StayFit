using AutoMapper;
using StayFit.Application.DTOs;
using StayFit.Application.DTOs.Members;
using StayFit.Application.DTOs.Trainers;
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
            CreateMap<User, MemberResponseDto>().ReverseMap();
            CreateMap<Member, MemberResponseDto>().IncludeMembers(src => src.User).ReverseMap();


            CreateMap<User, TrainerRegisterDto>().ReverseMap();
            CreateMap<User, TrainerResponseDto>().ReverseMap();
            CreateMap<Trainer, TrainerResponseDto>().IncludeMembers(src => src.User).ReverseMap();

            CreateMap<User, UpdateMemberDto>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); 
            CreateMap<Member, UpdateMemberDto>().IncludeMembers(src => src.User).ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<User, UpdateTrainerDto>().ReverseMap()
               .ForAllMembers(opts => opts.Condition((src, dest, srcTrainer) => srcTrainer != null));
            CreateMap<Trainer, UpdateTrainerDto>().IncludeMembers(src => src.User).ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcTrainer) => srcTrainer != null));

            CreateMap<Subscription, CreateSubscriptionDto>().ReverseMap();
            CreateMap<Subscription, GetTrainerSubscribersDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Member.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Member.User.LastName))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.Member.User.BirthDate))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Member.User.Gender))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Member.Height))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Member.Weight))
                .ForMember(dest => dest.PhotoPath, opt => opt.MapFrom(src => src.Member.User.PhotoPath))
                .ReverseMap();


            CreateMap<Subscription, GetMemberSubscribedTrainerDto>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Trainer.User.LastName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Trainer.User.FirstName))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.PhotoPath, opt => opt.MapFrom(src => src.Trainer.User.PhotoPath))
                .ForMember(dest => dest.TrainerId, opt => opt.MapFrom(src => src.Trainer.Id))
                .ForMember(dest => dest.SubscriptionId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
                
                
                
                
        }
    }
}
