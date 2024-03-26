using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebKrpcApi.Infra.Data.Repositories.Implementations;
using WebKrpcApi.Infra.Data.Repositories.Interfaces;

namespace WebKrpcApi.Infra.CrossCutting.DependecyContainer
{
    public static class DependecyContainer
    {
        public static void AddApiConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepositories();
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IBudgetRepository, BudgetRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
        }
    }
}
