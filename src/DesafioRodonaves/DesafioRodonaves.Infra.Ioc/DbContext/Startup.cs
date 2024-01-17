﻿
using DesafioRodonaves.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DesafioRodonaves.Infra.Ioc.DbContext
{
    internal static class Startup
    {
        internal static IServiceCollection AddServiceDbContext(this IServiceCollection services, IConfiguration configuration )
        {
            // Configurações banco de dados PostgreSql
            //services.AddDbContext<ApplicationDbContext>(option => 
            //    option.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
            //        build => build.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

                services.AddDbContext<ApplicationDbContext>(options =>
              options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;

        }
    }
}
