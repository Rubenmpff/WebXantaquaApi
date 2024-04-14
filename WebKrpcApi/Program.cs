using Azure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace WebKrpcApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

            .ConfigureAppConfiguration((context, config) =>
            {
                var builtConfig = config.Build();

                var azureCredential = new DefaultAzureCredential();

                config.AddAzureKeyVault(
                    new Uri($"https://{builtConfig["AzureKeyVault:Vault"]}.vault.azure.net/"),
                    azureCredential);
            })
                
            .ConfigureWebHostDefaults(webBuilder =>
            {
                    webBuilder.UseStartup<Startup>();
            });
    }
}
