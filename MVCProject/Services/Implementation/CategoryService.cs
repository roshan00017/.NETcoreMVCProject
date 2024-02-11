using MVCProject.Models.Domain;
using MVCProject.Models.DTO;

using MVCProject.Repository.Interfaces;
using MVCProject.Services.Interface;
using System.Linq.Expressions;

namespace MVCProject.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        public IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateCategoryAsync(CategoryDto viewModel)
        {
            try
            {
                _unitOfWork.CreateTransaction();

                if (viewModel != null)
                {
                    var category = new Models.Domain.Category
                    {
                        Name = viewModel.Name,
                        CreatedBy = (int)viewModel.CreatedBy,
                        CreatedDate = DateTime.Now,

                    };

                    var repository = _unitOfWork.GenericRepository<Models.Domain.Category>();

                    await repository.InsertAsync(category);
                    await _unitOfWork.Save();

                    _unitOfWork.Commit();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                return false;
            }
        }


        public async Task<bool> DeleteCategoryAsync(int taskId)
        {
            try
            {
                _unitOfWork.CreateTransaction();

                if (taskId > 0)
                {
                    var taskDetails = _unitOfWork.GenericRepository<Models.Domain.Category>();
                    var task = await taskDetails.GetByIdAsync(taskId);


                    if (task != null)
                    {
                        await taskDetails.DeleteAsync(taskId);
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

        public async Task<IEnumerable<Models.Domain.Category>> GetAllCategorysAsync()
        {
            try
            {

                var TaskList = _unitOfWork.GenericRepository<Models.Domain.Category>();

                return await TaskList.GetAllAsync();
            }
            catch
            {
                return Enumerable.Empty<Models.Domain.Category>();
            }
        }

        public async Task<IEnumerable<Models.Domain.Category>> GetAllCategorysAsync(int pageNumber, int pageSize, string sortBy, string searchQuery)
        {
            try
            {
                var TaskList = _unitOfWork.GenericRepository<Models.Domain.Category>();

                // Apply sorting
                Func<IQueryable<Models.Domain.Category>, IOrderedQueryable<Models.Domain.Category>> orderBy = null;
                if (!string.IsNullOrEmpty(sortBy))
                {
                    // Example sorting by title
                    if (sortBy == "Name")
                    {
                        orderBy = query => query.OrderBy(task => task.Name);
                    }

                  
                    // Add more sorting options as needed
                }

                // Apply searching
                Expression<Func<Models.Domain.Category, bool>> filter = null;
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    // Example searching by title containing searchQuery
                    filter = task => task.Name.Contains(searchQuery);
                    // Add more complex search conditions as needed
                }

                // Retrieve paginated and sorted data
                return await TaskList.GetAllAsync(filter, orderBy, "", pageNumber, pageSize);
            }
            catch
            {
                return Enumerable.Empty<Models.Domain.Category>();
            }
        }


        public async Task<Models.Domain.Category> GetCategoryByIdAsync(int taskId)
        {
            try
            {
                if (taskId > 0)
                {
                    var taskDetails = _unitOfWork.GenericRepository<Models.Domain.Category>();
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

        public async Task<bool> UpdateCategoryAsync(CategoryDto category)
        {
            try
            {
                if (category != null)
                {
                    var categoryRepository = _unitOfWork.GenericRepository<Category>();
                    var existingCategory = await categoryRepository.GetByIdAsync(category.Id);

                    if (existingCategory != null)
                    {
                        existingCategory.Name = category.Name;
                        existingCategory.ModifiedBy = category.ModifiedBy;
                        existingCategory.ModifiedDate = DateTime.Now; // Update with current date

                        await categoryRepository.UpdateAsync(existingCategory);
                        await _unitOfWork.Save();

                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                // Handle exception if necessary
                return false;
            }
        }
    }
}
