using CleanArchitectureMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Data.Entity.ModelConfiguration;

public class Class1
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.HasData(
                new Category(1,"Material Escolar"),
                new Category(2,"Eletronicos"),
                new Category(3,"Acessórios")
            );
        }
    }

}
