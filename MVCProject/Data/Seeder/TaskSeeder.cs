using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models.Domain;

namespace MVCProject.Data.Seeder
{
    public class TaskSeeder : IEntityTypeConfiguration<Models.Domain.Task>
    {
        public void Configure(EntityTypeBuilder<Models.Domain.Task> builder)
        {
            builder.ToTable("Task");
           
            builder.HasData
            (
                new Models.Domain.Task { TaskID = 1, Title = "Task 1", Description = "Description 1", DueDate = DateTime.Now.AddDays(7), IsCompleted = true, UserId = 1, CategoryId = 1 },
                new Models.Domain.Task { TaskID = 2, Title = "Task 2", Description = "Description 2", DueDate = DateTime.Now.AddDays(14), IsCompleted = false, UserId = 2, CategoryId = 1 },
                // Add more tasks as needed
                new Models.Domain.Task { TaskID = 3, Title = "Task 3", Description = "Description 3", DueDate = DateTime.Now.AddDays(21), IsCompleted = false, UserId = 1, CategoryId = 2 },
                new Models.Domain.Task { TaskID = 4, Title = "Task 4", Description = "Description 4", DueDate = DateTime.Now.AddDays(28), IsCompleted = false, UserId = 2, CategoryId = 2 },
                new Models.Domain.Task { TaskID = 5, Title = "Task 5", Description = "Description 5", DueDate = DateTime.Now.AddDays(35), IsCompleted = false, UserId = 1, CategoryId = 3 },
                new Models.Domain.Task { TaskID = 6, Title = "Task 6", Description = "Description 6", DueDate = DateTime.Now.AddDays(42), IsCompleted = false, UserId = 2, CategoryId = 3 },
                new Models.Domain.Task { TaskID = 7, Title = "Task 7", Description = "Description 7", DueDate = DateTime.Now.AddDays(49), IsCompleted = false, UserId = 1, CategoryId = 1 },
                new Models.Domain.Task { TaskID = 8, Title = "Task 8", Description = "Description 8", DueDate = DateTime.Now.AddDays(56), IsCompleted = false, UserId = 2, CategoryId = 1 },
                new Models.Domain.Task { TaskID = 9, Title = "Task 9", Description = "Description 9", DueDate = DateTime.Now.AddDays(63), IsCompleted = false, UserId = 1, CategoryId = 2 },
                new Models.Domain.Task { TaskID = 10, Title = "Task 10", Description = "Description 10", DueDate = DateTime.Now.AddDays(70), IsCompleted = false, UserId = 2, CategoryId = 2 },
                new Models.Domain.Task { TaskID = 11, Title = "Task 11", Description = "Description 11", DueDate = DateTime.Now.AddDays(77), IsCompleted = false, UserId = 1, CategoryId = 3 },
                new Models.Domain.Task { TaskID = 12, Title = "Task 12", Description = "Description 12", DueDate = DateTime.Now.AddDays(84), IsCompleted = false, UserId = 2, CategoryId = 3 }
          
            );
        }
    }
}
