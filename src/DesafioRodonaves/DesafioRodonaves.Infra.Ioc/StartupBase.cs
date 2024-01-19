using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DesafioRodonaves.Infra.Ioc.DbContext;
using DesafioRodonaves.Infra.Ioc.FluentValidation;
using DesafioRodonaves.Infra.Ioc.UnitOfWorkDependecy;
using DesafioRodonaves.Infra.Ioc.Services;
using DesafioRodonaves.Infra.Ioc.Repository;
using DesafioRodonaves.Infra.Ioc.GlobalExecptions;
using Microsoft.AspNetCore.Builder;
using DesafioRodonaves.Infra.Ioc.JWT;
using DesafioRodonaves.Infra.Ioc.Swagger;

namespace DesafioRodonaves.Infra.Ioc
{
    public static class StartupBase
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddServiceDbContext(configuration);

            services.AddServiceRepository();
            services.AddServices();

            services.AddServiceFluentValidation();
            services.AddServiceGlobalExecptions();
            services.AddServiceUnitOfWork();
            services.AddServices();

            services.AddServiceJwtAuthenticationAndAutorization(configuration);

            services.AddServiceSwagger();

            return services;

        }
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config)
        {
            builder.UseGlobalExceptionMiddleware();
            return builder;
        }
    }
}
