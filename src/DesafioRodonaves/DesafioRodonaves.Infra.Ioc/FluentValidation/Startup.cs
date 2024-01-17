
using DesafioRodonaves.Domain.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioRodonaves.Infra.Ioc.FluentValidation
{
    internal static class Startup
    {

        internal static IServiceCollection AddServiceFluentValidation(this IServiceCollection services)
        {
            services.AddScoped<UnitValidation>();
            services.AddScoped<CollaboratorValidation>();
            services.AddScoped<UserValidation>();

            return services;
        }
    }
}
