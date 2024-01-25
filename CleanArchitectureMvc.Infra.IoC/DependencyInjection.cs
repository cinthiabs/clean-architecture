using CleanArchitectureMvc.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureMvc.Domain.Interfaces;
using CleanArchitectureMvc.Infra.Data.Repositories;
using CleanArchitectureMvc.Application.Interfaces;
using CleanArchitectureMvc.Application.Services;
using CleanArchitectureMvc.Application.Mappings;
using System;
using MediatR;

namespace CleanArchitectureMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
                ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //var myhandlers = AppDomain.CurrentDomain.Load("CleanArchitectureMvc.Application");
            //services.AddMediatR(myhandlers);
            return services;

        }
    }
}
