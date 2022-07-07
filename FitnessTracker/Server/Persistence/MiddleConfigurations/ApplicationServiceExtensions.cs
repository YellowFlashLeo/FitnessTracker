using FitnessTracker.Server.Persistence.Services.NutritionService;
using FitnessTracker.Server.Persistence.DataBase;
using FitnessTracker.Server.Persistence.Services.BodyPartService.cs;
using FitnessTracker.Server.Persistence.Services.EmailService;
using FitnessTracker.Server.Persistence.Services.IdentityService;
using FitnessTracker.Server.Persistence.Services.MonthlyStatistics;
using FitnessTracker.Server.Persistence.Services.TrainingDayService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace FitnessTracker.Server.Persistence.MiddleConfigurations
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" }); });
            services.AddDbContext<FitnessStoreContext>(options =>
                options.UseSqlServer("Server=LAPTOP-MDC8ECNL\\LEOSERVER;Database=Fitness;Trusted_Connection=True;"));

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IBodyPartService, BodyPartService>();
            services.AddScoped<ITrainingDayService, TrainingDayService>();
            services.AddScoped<INutritionService, NutritionService>();
            services.AddScoped<IMonthlyStatistics, MonthlyStatistics>();
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
