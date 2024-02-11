using Microsoft.EntityFrameworkCore;
using MVCProject.Data.Seeder;
using MVCProject.Models.Domain;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MVCProject.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<Models.Domain.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserSeeder());
            modelBuilder.ApplyConfiguration(new CategorySeeder());
            modelBuilder.ApplyConfiguration(new TaskSeeder());
            modelBuilder.Entity<Models.Domain.Task>()
               .HasOne(t => t.User)
               .WithMany()
               .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Models.Domain.Task>()
                .HasOne(t => t.Category)
                .WithMany()
                .HasForeignKey(t => t.CategoryId);

            modelBuilder.Entity<Category>()
                 .HasOne(c => c.CreatedByUser)
                 .WithMany()
                 .HasForeignKey(c => new { c.CreatedBy })
                 .OnDelete(DeleteBehavior.Restrict); ;

            modelBuilder.Entity<Category>()
                .HasOne(c => c.ModifiedByUser)
                .WithMany()
                .HasForeignKey(c => new { c.ModifiedBy })
                .OnDelete(DeleteBehavior.Restrict); ;



        }
    }
}
