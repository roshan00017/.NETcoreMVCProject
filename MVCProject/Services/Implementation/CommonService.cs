using MVCProject.Models.Domain;
using MVCProject.Services.Interface;

namespace MVCProject.Services.Implementation
{
    public class CommonService : ICommonService
    {
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;

        public CommonService(IUserService userService, ICategoryService categoryService)
        {
            _userService = userService;
            _categoryService = categoryService;
        }
            
        public async Task<IEnumerable<User>> UserListAsync()
        {
            return await _userService.GetAllUsersAsync();
        }

        public async Task<IEnumerable<Category>> CategoryListAsync()
        {
            return await _categoryService.GetAllCategorysAsync();
        }
    }
}