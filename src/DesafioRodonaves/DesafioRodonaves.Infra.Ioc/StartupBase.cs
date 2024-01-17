using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DesafioRodonaves.Infra.Ioc.DbContext;
using DesafioRodonaves.Infra.Ioc.FluentValidation;
using DesafioRodonaves.Infra.Ioc.UnitOfWorkDependecy;

namespace DesafioRodonaves.Infra.Ioc
{
    public static class StartupBase
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddServiceDbContext(configuration);

            services.AddServiceFluentValidation();

            services.AddServiceUnitOfWork();
        

            return services;

        }
    }
}
