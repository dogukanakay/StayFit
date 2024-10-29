using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StayFit.Application.Repositories;
using StayFit.Persistence.Contexts;
using StayFit.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StayFitDbContext>(options=> options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
            services.AddScoped<IAuthRepository, AuthService>();
            services.AddSingleton<JwtTokenGenerator>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
        }
    }
}
