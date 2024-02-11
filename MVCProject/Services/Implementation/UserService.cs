using MVCProject.Models.Domain;
using MVCProject.Repository.Interfaces;
using MVCProject.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MVCProject.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                if (user != null)
                {
                    var userRepository = _unitOfWork.GenericRepository<User>();
                    await userRepository.InsertAsync(user);
                    await _unitOfWork.Save();
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

        public async Task<bool> DeleteUserAsync(int userId)
        {
            try
            {
                if (userId > 0)
                {
                    var userRepository = _unitOfWork.GenericRepository<User>();
                    var user = await userRepository.GetByIdAsync(userId);
                    if (user != null)
                    {
                        userRepository.DeleteAsync(userId);
                        await _unitOfWork.Save();
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

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            try
            {
                var userRepository = _unitOfWork.GenericRepository<User>();
                return await userRepository.GetAllAsync();
            }
            catch (Exception)
            {
                return Enumerable.Empty<User>();
            }
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            try
            {
                if (userId > 0)
                {
                    var userRepository = _unitOfWork.GenericRepository<User>();
                    return await userRepository.GetByIdAsync(userId);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            try
            {
                if (user != null)
                {
                    var userRepository = _unitOfWork.GenericRepository<User>();
                    var existingUser = await userRepository.GetByIdAsync(user.UserId);
                    if (existingUser != null)
                    {
                        existingUser.Email = user.Email;
                        existingUser.UserName = user.UserName;
                        existingUser.Password = user.Password;
                        await userRepository.UpdateAsync(existingUser);
                        await _unitOfWork.Save();
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

        public async Task<IEnumerable<Models.Domain.User>> GetAllUsersAsync(int pageNumber, int pageSize, string sortBy, string searchQuery)
        {
            try
            {
                var TaskList = _unitOfWork.GenericRepository<Models.Domain.User>();

                // Apply sorting
                Func<IQueryable<Models.Domain.User>, IOrderedQueryable<Models.Domain.User>> orderBy = null;
                if (!string.IsNullOrEmpty(sortBy))
                {
                    // Example sorting by title
                    if (sortBy == "UserName")
                    {
                        orderBy = query => query.OrderBy(task => task.UserName);
                    }

                    if (sortBy == "Email")
                    {
                        orderBy = query => query.OrderBy(task => task.Email);
                    }
                    // Add more sorting options as needed
                }

                // Apply searching
                Expression<Func<Models.Domain.User, bool>> filter = null;
                if (!string.IsNullOrEmpty(searchQuery))
                {
                    // Example searching by title containing searchQuery
                    filter = task => task.UserName.Contains(searchQuery) || task.Email.Contains(searchQuery);
                    // Add more complex search conditions as needed
                }

                // Retrieve paginated and sorted data
                return await TaskList.GetAllAsync(filter, orderBy, "", pageNumber, pageSize);
            }
            catch
            {
                return Enumerable.Empty<Models.Domain.User>();
            }
        }

    }
}
