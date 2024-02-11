

using MVCProject.Models.DTO;

namespace MVCProject.Services.Interface
{
    public interface ICategoryService
    {
        Task<bool> CreateCategoryAsync(CategoryDto Category);

        Task<IEnumerable<Models.Domain.Category>> GetAllCategorysAsync();

        Task<IEnumerable<Models.Domain.Category>> GetAllCategorysAsync(int pageNumber, int pageSize, string sortBy, string searchQuery);

        Task<Models.Domain.Category> GetCategoryByIdAsync(int CategoryId);

  

        Task<bool> UpdateCategoryAsync(CategoryDto Category);

        Task<bool> DeleteCategoryAsync(int CategoryId);
    }
}
