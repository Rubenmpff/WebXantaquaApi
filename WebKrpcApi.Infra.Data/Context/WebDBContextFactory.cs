using Krpc.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


public class WebDBContextFactory : IDesignTimeDbContextFactory<WebKrpcApiDBContext>
{
    public WebKrpcApiDBContext CreateDbContext(string[] args)
    {
        // Ajuste o caminho para apontar para o diretório do projeto "WebKrpcApi"
        var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../WebKrpcApi"));
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<WebKrpcApiDBContext>();
        builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        return new WebKrpcApiDBContext(builder.Options);
    }
}