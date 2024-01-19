using DesafioRodonaves.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DesafioRodonaves.Infra.Ioc.JWT
{
    internal static class Startup
    {
        internal static IServiceCollection AddServiceJwtAuthenticationAndAutorization(this IServiceCollection services, IConfiguration configuration)
        {
            // Configura o serviço de geração de token
            services.AddTransient<TokenService>();

            // Configura o serviço de autenticação de usuário utilizando token JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;

                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateLifetime = true
                   };
               });

            // Configura os perfis de acesso aceitos pela aplicação
            services.AddAuthorization(option =>
            {
                option.AddPolicy("commonCollaborator", p => p.RequireRole("commonCollaborator"));
                option.AddPolicy("collaboratorAdministrator", p => p.RequireRole("collaboratorAdministrator"));
            });

            return services;
        }
    }
}