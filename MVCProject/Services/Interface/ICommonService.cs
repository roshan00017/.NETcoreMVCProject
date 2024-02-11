using MVCProject.Models.Domain;

namespace MVCProject.Services.Interface
{
    public interface ICommonService
    {
        Task<IEnumerable<User>> UserListAsync();
        Task<IEnumerable<Category>> CategoryListAsync();
    }
}
