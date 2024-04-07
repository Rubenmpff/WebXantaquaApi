using Krpc.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebKrpcApi.Infra.Data.Repositories.Implementations;
using WebKrpcApi.Infra.Data.Repositories.Interfaces;
using WebKrpcApi.Services.Mapping.AutoMapper;
using WebKrpcApi.Services.Services.Implementations;
using WebKrpcApi.Services.Services.Interfaces;

namespace WebKrpcApi.Infra.CrossCutting.DependecyContainer
{
    public static class DependecyContainer
    {
        public static void AddApiConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<WebKrpcApiDBContext>();
            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.RegisterRepositories();
            services.RegisterServices();
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IBudgetRepository, BudgetRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
        }

        private static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IBudgetService, BudgetService>();
            services.AddScoped<IProjectService, ProjectService>();
        }
    }
}
