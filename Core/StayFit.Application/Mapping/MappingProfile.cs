using AutoMapper;
using StayFit.Application.DTOs;
using StayFit.Application.DTOs.Members;
using StayFit.Application.DTOs.Trainers;
using StayFit.Application.DTOs.WorkoutPlans;
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
            //Auth register maps
            CreateMap<User, MemberRegisterDto>().ReverseMap();
            CreateMap<User, MemberResponseDto>().ReverseMap();
            CreateMap<Member, MemberResponseDto>().IncludeMembers(src => src.User).ReverseMap();


            CreateMap<User, TrainerRegisterDto>().ReverseMap();
            CreateMap<User, TrainerResponseDto>().ReverseMap();
            CreateMap<Trainer, TrainerResponseDto>().IncludeMembers(src => src.User).ReverseMap();


            //Auth update maps
            CreateMap<User, UpdateMemberDto>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); 
            CreateMap<Member, UpdateMemberDto>().IncludeMembers(src => src.User).ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<User, UpdateTrainerDto>().ReverseMap()
               .ForAllMembers(opts => opts.Condition((src, dest, srcTrainer) => srcTrainer != null));
            CreateMap<Trainer, UpdateTrainerDto>().IncludeMembers(src => src.User).ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcTrainer) => srcTrainer != null));


            //Subscription maps
            CreateMap<Subscription, CreateSubscriptionDto>().ReverseMap();

            //WorkoutPlan maps
            CreateMap<WorkoutPlan, CreateWorkoutPlanDto>().ReverseMap();
            CreateMap<WorkoutPlan, GetWorkoutPlansByMemberIdDto>().ReverseMap();
            CreateMap<WorkoutPlan, GetWorkoutPlansBySubscriptionIdDto>().ReverseMap();
            
                
                
                
                
        }
    }
}
