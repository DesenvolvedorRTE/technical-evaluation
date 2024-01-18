
using DesafioRodonaves.Application.Interfaces;
using DesafioRodonaves.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioRodonaves.Infra.Ioc.Services
{
    internal static class Startup
    {
        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPasswordManager, PasswordManager>();

            return services;
        }
    }
}
