using CleanArchitecture.Application.Features.Commands.CategoryCommands;
using CleanArchitecture.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            // Add MediatR
            services.AddMediatR(op =>
            {
                op.RegisterServicesFromAssemblies(
                    typeof(CategoryAddCommand).Assembly,
                    Assembly.GetExecutingAssembly()
                    );
            });
         
            // Add AutoMapper
            services.AddAutoMapper(op =>
            {
                op.AddProfile(new MappingProfile());
            });

            return services;
        }
    }
}
