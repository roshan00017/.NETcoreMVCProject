using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProject.Models.Domain;
using System;

namespace MVCProject.Data.Seeder
{
    public class CategorySeeder : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasData(
                new Category { Id = 1, Name = "Category 1", CreatedBy = 1, CreatedDate = DateTime.Now, ModifiedBy = 1, ModifiedDate = DateTime.Now },
                new Category { Id = 2, Name = "Category 2", CreatedBy = 2, CreatedDate = DateTime.Now, ModifiedBy = 2, ModifiedDate = DateTime.Now },
                // Add more categories as needed
                new Category { Id = 3, Name = "Category 3", CreatedBy = 1, CreatedDate = DateTime.Now, ModifiedBy = 1, ModifiedDate = DateTime.Now }
            );
        }
    }
}
