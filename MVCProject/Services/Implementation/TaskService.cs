using Microsoft.EntityFrameworkCore;
using MVCProject.Models.DTO;

using MVCProject.Repository.Interfaces;
using MVCProject.Services.Interface;
using System.Linq.Expressions;
using static MVCProject.Repository.Implemenentaion.TaskRepository;

namespace MVCProject.Services.Implementation
{
    public class TaskService : ITaskService
    {
        public IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateTaskAsync(TaskDto viewModel)
        {
            try
            {
                _unitOfWork.CreateTransaction();

              
        if (viewModel != null)
        {
            var task = new Models.Domain.Task
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                DueDate = viewModel.DueDate,
                UserId = viewModel.UserId,
                CategoryId = viewModel.CategoryId
            };

            var pd_result = _unitOfWork.GenericRepository<Models.Domain.Task>();

            await pd_result.InsertAsync(task);

            await _unitOfWork.Save();


                    _unitOfWork.Commit();


                    return true;


                }
                return false;
            }
            catch (Exception)
            {


                _unitOfWork.Rollback();
                return false;
            }
        }

        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            try
            {
                _unitOfWork.CreateTransaction();

                if (taskId > 0)
                {
                    var taskDetails = _unitOfWork.GenericRepository<Models.Domain.Task>();
                    var task = await taskDetails.GetByIdAsync(taskId);


                    if (task != null)
                    {
                        taskDetails.DeleteAsync(taskId);
                        await _unitOfWork.Save();

                        _unitOfWork.Commit();

                        return true;

                    }
                }
                return false;
            }
            catch (Exception)
            {


                _unitOfWork.Rollback();
                return false;
            }
        }

        public async Task<IEnumerable<Models.Domain.Task>> GetAllTasksAsync()
        {
            try
            {

                var TaskList = _unitOfWork.GenericRepository<Models.Domain.Task>();

                return await TaskList.GetAllAsync();
            }
            catch
            {
                return Enumerable.Empty<Models.Domain.Task>();
            }
        }

        public async Task<IEnumerable<Models.Domain.Task>> GetAllTasksAsync(int pageNumber, int pageSize, string sortBy, string searchQuery)
        {
            try
            {
                var TaskList = _unitOfWork.GenericRepository<Models.Domain.Task>();

                // Apply sorting
                Func<IQueryable<Models.Domain.Task>, IOrderedQueryable<Models.Domain.Task>> orderBy = null;
                if (!string.IsNullOrEmpty(sortBy))
                {
                    // Example sorting by title
                    if (sortBy == "Title")
                    {
                        orderBy = query => query.OrderBy(task => task.Title);
                    }

                    if (sortBy == "UserId")
                    {
                        orderBy = query => query.OrderBy(task => task.UserId);
                    }
                    // Add more sorting options as needed
                }

                // Apply searching
                Expression<Func<Models.Domain.Task, bool>> filter = null;
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    // Example searching by title containing searchQuery
                    filter = task => task.Title.Contains(searchQuery);
                    // Add more complex search conditions as needed
                }

                // Retrieve paginated and sorted data
                return await TaskList.GetAllAsync(filter, orderBy, "", pageNumber, pageSize);
            }
            catch
            {
                return Enumerable.Empty<Models.Domain.Task>();
            }
        }


        public async Task<Models.Domain.Task> GetTaskByIdAsync(int taskId)
        {
            try
            {
                if (taskId > 0)
                {
                    var taskDetails = _unitOfWork.GenericRepository<Models.Domain.Task>();
                    var task = await taskDetails.GetByIdAsync(taskId);

                    if (task != null)
                    {
                        return task;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Models.Domain.Task> GetTaskByNameAsync(string taskName)
        {
            try
            {

                var taskRepository = _unitOfWork.GenericRepository<ITaskRepository, Models.Domain.Task>();
                var task = await taskRepository.GetTaskByNameAsync(taskName);

                if (task != null)
                {
                    return (Models.Domain.Task)task;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> UpdateTaskAsync(TaskDto task)
        {
            try
            {
                if (task != null)
                {
                    var taskDetail = _unitOfWork.GenericRepository<Models.Domain.Task>();
                    var taskresult = await taskDetail.GetByIdAsync(task.TaskID);

                    if (taskresult != null)
                    {
                        taskresult.Title = task.Title;
                        taskresult.Description = task.Description;
                        taskresult.DueDate = task.DueDate;
                        taskresult.IsCompleted = task.IsCompleted;
                        taskresult.UserId = task.UserId;
                        taskresult.CategoryId = task.CategoryId;

                        await taskDetail.UpdateAsync(taskresult);

                        await _unitOfWork.Save();

                        return true;

                    }
                }
                return false;
            }
            catch { return false; }

        }


        public async Task<MemoryStream> ExportTasksToExcelAsync()
        {
            try
            {
                // Get the task data from the database
                var tasks = await GetAllTasksAsync();

                // Create an instance of ExcelFileHandling
                var excelFileHandling = new ExcelFileHandling();

                // Call the CreateExcelFile method by passing the list of tasks
                var stream = excelFileHandling.CreateExcelFile(tasks);

                return stream;
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                throw ex;
            }
        }
    }


 
}
 