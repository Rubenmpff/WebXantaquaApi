using Krpc.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using WebKrpcApi.Infra.Data.Repositories.Implementations;
using WebKrpcApi.Infra.Data.Repositories.Interfaces;
using WebKrpcApi.Services.Mapping.AutoMapper;
using WebKrpcApi.Services.Services.Implementations;
using WebKrpcApi.Services.Services.Interfaces;
using WebKrpcApi.Services.Validator;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebKrpcApi.Infra.CrossCutting.DependecyContainer
{
    public static class DependecyContainer
    {
        public static void AddApiConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuração do AutoMapper
            services.AddAutoMapper(typeof(AutoMapperConfig));

            // Registro dos repositórios e serviços
            services.RegisterRepositories();
            services.RegisterServices();

            // Registro e configuração do Identity
            services.AddIdentity<Client, IdentityRole>()
                    .AddEntityFrameworkStores<WebKrpcApiDBContext>()
                    .AddDefaultTokenProviders();

            // Adiciona a configuração fortemente tipada usando IOptions
            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

            // Configuração da autenticação JWT
            RegisterAuthentication(services, configuration);
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IBudgetRepository, BudgetRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();

            // Configurar o UserManager com Client
            services.AddScoped<IUserStore<Client>, UserStore<Client, IdentityRole, WebKrpcApiDBContext>>();
            services.AddScoped<UserManager<Client>>();
        }

        private static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IBudgetService, BudgetService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }

        private static void RegisterAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            // Antes de configurar a autenticação, confirme que as chaves de configuração estão presentes.
            var jwtKey = configuration["Jwt:Key"];
            if (string.IsNullOrWhiteSpace(jwtKey))
            {
                throw new InvalidOperationException("Chave JWT não está configurada corretamente.");
            }

            // Configuração da autenticação JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });
        }
    }
}
