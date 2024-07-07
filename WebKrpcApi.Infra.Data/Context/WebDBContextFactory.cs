using Krpc.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


public class WebDBContextFactory : IDesignTimeDbContextFactory<WebXantaquaApiDBContext>
{
    public WebXantaquaApiDBContext CreateDbContext(string[] args)
    {
        // Ajuste o caminho para apontar para o diretório do projeto "WebKrpcApi"
        var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../WebKrpcApi"));
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<WebXantaquaApiDBContext>();
        builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        return new WebXantaquaApiDBContext(builder.Options);
    }
}