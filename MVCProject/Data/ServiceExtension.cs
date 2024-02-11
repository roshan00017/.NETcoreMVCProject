using Microsoft.EntityFrameworkCore;
using MVCProject.Repository.Implemenentaion;
using MVCProject.Repository.Interfaces;

namespace MVCProject.Data
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            return services;
        }
    }
}
