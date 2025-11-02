
using CleanArchitecture.Application.DI;
using CleanArchitecture.Application.Features.Commands.CategoryCommands;
using CleanArchitecture.Application.Mapping;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Database;
using CleanArchitecture.Infrastructure.DI;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Reflection;

namespace CleanArchitecture.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddEndpointsApiExplorer();
            object value = builder.Services.AddSwaggerGen();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                    )
                );

            builder.Services
                .ApplicationServices()
                .InfrastructureServices();

            //builder.Services.InfrastructureServices();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "DEPI RealEstate API v1");
                    options.DocumentTitle = "DEPI RealEstate API Documentation";
                });

                app.MapOpenApi();

                app.MapScalarApiReference(options =>
                {
                    options.Title = "The DEPI-REALESTATE Api";
                    options.Layout = ScalarLayout.Classic;
                    options.HideClientButton = true;
                    options.Theme = ScalarTheme.Saturn;
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
