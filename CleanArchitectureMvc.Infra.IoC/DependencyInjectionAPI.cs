using CleanArchitectureMvc.Application.Interfaces;
using CleanArchitectureMvc.Application.Mappings;
using CleanArchitectureMvc.Application.Services;
using CleanArchitectureMvc.Domain.Account;
using CleanArchitectureMvc.Domain.Interfaces;
using CleanArchitectureMvc.Infra.Data.Context;
using CleanArchitectureMvc.Infra.Data.Identity;
using CleanArchitectureMvc.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureMvc.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
                ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));


            //var myhandlers = AppDomain.CurrentDomain.Load("CleanArchitectureMvc.Application");
            //services.AddMediatR(myhandlers);
            return services;

        }
    }
}
