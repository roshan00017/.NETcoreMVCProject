

namespace MVCProject.Services.Interface
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(Models.Domain.User User);

        Task<IEnumerable<Models.Domain.User>> GetAllUsersAsync();

        Task<IEnumerable<Models.Domain.User>> GetAllUsersAsync(int pageNumber, int pageSize, string sortBy, string searchQuery);

        Task<Models.Domain.User> GetUserByIdAsync(int UserId);

 

        Task<bool> UpdateUserAsync(Models.Domain.User User);

        Task<bool> DeleteUserAsync(int UserId);
    }
}
