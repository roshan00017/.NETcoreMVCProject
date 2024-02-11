using MVCProject.Models.DTO;

namespace MVCProject.Repository.Interfaces
{
    public interface ITaskRepository : IGenericRepository<Models.Domain.Task>
    {
        Task<IEnumerable<Models.Domain.Task>> GetTaskByNameAsync(string taskName);
    }
}

