using MVCProject.Models.DTO;

namespace MVCProject.Services.Interface
{
    public interface ITaskService
    {
        Task<bool> CreateTaskAsync(TaskDto Task);

        Task<IEnumerable<Models.Domain.Task>> GetAllTasksAsync();

        Task<IEnumerable<Models.Domain.Task>> GetAllTasksAsync(int pageNumber, int pageSize, string sortBy, string searchQuery);

        Task<Models.Domain.Task> GetTaskByIdAsync(int taskId);

        Task<Models.Domain.Task> GetTaskByNameAsync(string taskName);

        Task<bool> UpdateTaskAsync(TaskDto task);

        Task<bool> DeleteTaskAsync(int taskId);
        Task<MemoryStream> ExportTasksToExcelAsync();

    }
}
