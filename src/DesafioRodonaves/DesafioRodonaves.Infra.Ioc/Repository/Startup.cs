using DesafioRodonaves.Domain.Interfaces;
using DesafioRodonaves.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioRodonaves.Infra.Ioc.Repository
{
    internal static class Startup
    {
        internal static IServiceCollection AddServiceRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();

            return services;
        }
    }
}