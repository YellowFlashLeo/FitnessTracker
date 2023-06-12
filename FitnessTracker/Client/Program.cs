using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.Toast;
using FitnessTracker.Client.Authentication;
using FitnessTracker.Client.ClientServices.AuthenticationService;
using FitnessTracker.Client.ClientServices.BodyPartService;
using FitnessTracker.Client.ClientServices.MonthlyStatisticsService;
using FitnessTracker.Client.ClientServices.NutritionService;
using FitnessTracker.Client.ClientServices.SaveToServerService;
using FitnessTracker.Client.ClientServices.ToastService;
using Microsoft.AspNetCore.Components.Authorization;

namespace FitnessTracker.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<IBodyPartService, BodyPartService>();
            builder.Services.AddScoped<IMonthlyStatisticsService, MonthlyStatisticsService>();
            builder.Services.AddScoped<INutritionService, NutritionService>();
           // builder.Services.AddScoped<ISaveToServerService, SaveToServerService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            builder.Services.AddScoped<ToastService>();
            builder.Services.AddScoped<TrainingDayState>();

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredToast();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            await builder.Build().RunAsync();
        }
    }
}
