using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StayFit.Application.Repositories;
using StayFit.Persistence.Contexts;
using StayFit.Persistence.Repositories;

namespace StayFit.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StayFitDbContext>(options=> options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITrainerRepository, TrainerRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IWorkoutPlanRepository, WorkoutPlanRepository>();
            services.AddScoped<IWorkoutDayRepository, WorkoutDayRepository>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IWeeklyProgressRepository, WeeklyProgressRepository>();
            services.AddScoped<IProgressImageRepository, ProgressImageRepository>();
            services.AddScoped<IDietPlanRepository, DietPlanRepository>();
            services.AddScoped<IDietDayRepository, DietDayRepository>();
            services.AddScoped<IDietRepository, DietRepository>();

           

        }
    }
}
