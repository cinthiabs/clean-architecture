using Microsoft.EntityFrameworkCore;
using CleanArchitectureMvc.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CleanArchitectureMvc.Infra.Data.Identity;

namespace CleanArchitectureMvc.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
