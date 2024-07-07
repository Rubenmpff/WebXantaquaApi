using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Krpc.Data.Context;
using Microsoft.Extensions.Configuration;
using WebKrpcApi.Infra.CrossCutting.DependecyContainer;
using Serilog;
using System;

namespace WebKrpcApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configura o Serilog para logging
            builder.Host.UseSerilog((context, configuration) => {
                configuration.ReadFrom.Configuration(context.Configuration)
                             .Enrich.FromLogContext()
                             .WriteTo.Console();
            });

            // Adiciona o contexto do banco de dados com Entity Framework
            builder.Services.AddDbContext<WebXantaquaApiDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Configura��o espec�fica da API registrada em outro arquivo
            builder.Services.AddApiConfigurations(builder.Configuration);

            // Configura CORS para permitir requisi��es de origens espec�ficas
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("DefaultCorsPolicy", builder =>
                    builder.WithOrigins("http://localhost:4200") // Substitua pela(s) origem(ns) que voc� deseja permitir
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials()); // Adicione AllowCredentials se necess�rio
            });

            // Configura controllers
            builder.Services.AddControllers();

            // Configura o Swagger para documenta��o da API
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Krpc API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            var app = builder.Build();

            // Configura��o do middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Krpc API V1");
                    c.RoutePrefix = string.Empty; // Faz com que o Swagger UI seja a p�gina inicial
                });
            }
            else
            {
                app.UseExceptionHandler("/Error"); // Certifique-se de implementar a rota '/Error'
                app.UseHsts(); // Usa HSTS, que adiciona um cabe�alho de seguran�a que diz aos navegadores para sempre usar HTTPS
            }

            app.UseHttpsRedirection();
            app.UseCors("DefaultCorsPolicy"); // Aplica a pol�tica de CORS configurada

            app.UseAuthentication(); // Adiciona o middleware de autentica��o
            app.UseAuthorization();  // Adiciona o middleware de autoriza��o

            app.MapControllers(); // Mapeia os controllers para as rotas

            app.Run(); // Inicia a aplica��o
        }
    }
}
