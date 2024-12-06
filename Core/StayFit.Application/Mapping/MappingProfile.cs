using AutoMapper;
using StayFit.Application.DTOs;
using StayFit.Application.DTOs.DietDays;
using StayFit.Application.DTOs.DietPlans;
using StayFit.Application.DTOs.Diets;
using StayFit.Application.DTOs.Exercises;
using StayFit.Application.DTOs.Members;
using StayFit.Application.DTOs.Trainers;
using StayFit.Application.DTOs.WeeklyProgresses;
using StayFit.Application.DTOs.WorkoutDays;
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
            CreateMap<UpdateWorkoutPlanDto, WorkoutPlan>().ReverseMap();



            //Exercise maps
            CreateMap<Exercise, CreateExerciseDto>().ReverseMap();
            CreateMap<Exercise, GetExercisesByWorkoutDayIdDto>().ReverseMap();

            //WorkoutDay maps
            CreateMap<WorkoutDay, CreateExerciseDto>().ReverseMap();
            CreateMap<WorkoutDay, CreateWorkoutDayDto>().ReverseMap();
            CreateMap<WorkoutDay, GetWorkoutDaysByWorkoutPlanIdDto>().ReverseMap();
            CreateMap<WorkoutDay, UpdateWorkoutDayDto>().ReverseMap();

            //WeeklyProgress maps
            CreateMap<WeeklyProgress, CreateWeeklyProgressDto>().ReverseMap();
            CreateMap<WeeklyProgress, GetWeeklyProgressesBySubsIdDto>().ReverseMap();


            //DietPlans maps
            CreateMap<DietPlan, CreateDietPlanDto>().ReverseMap();
            CreateMap<DietPlan, GetDietPlansByMemberIdDto>();
            CreateMap<DietPlan, GetDietPlansBySubscriptionIdDto>();


            //DietDays maps
            CreateMap<DietDay, CreateDietDayDto>().ReverseMap();
            CreateMap<DietDay, GetDietDaysByDietPlanIdDto>().ReverseMap();

            //Diets maps
            CreateMap<Diet, CreateDietDto>().ReverseMap();
            CreateMap<Diet, GetDietsByDietDayIdDto>().ReverseMap();
            CreateMap<Diet, GetNewDietByAIRequestDto>().ReverseMap();


        }
    }
}
