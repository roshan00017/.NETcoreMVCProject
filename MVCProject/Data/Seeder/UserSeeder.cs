using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProject.Models.Domain;

namespace MVCProject.Data.Seeder
{
    public class UserSeeder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasData(
                new User { UserId = 1, Email = "john@example.com", UserName = "john_doe", Password = "password" },
                new User { UserId = 2, Email = "jane@example.com", UserName = "jane_doe", Password = "password" },
                // Add more users as needed
                new User { UserId = 3, Email = "mike@example.com", UserName = "mike_miles", Password = "password" }
            );
        }
    }
}
