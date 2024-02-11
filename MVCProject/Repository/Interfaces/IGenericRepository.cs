using Microsoft.EntityFrameworkCore;
using MVCProject.Data;
using System.Linq.Expressions;

namespace MVCProject.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int Id);
        Task InsertAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task DeleteAsync(int Id);

        //for sorting pagination search
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
                                         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                         string includeProperties = "",
                                          int pageNumber = 1,
                                          int pageSize = 10);

        void SetDbContext(TaskDbContext dbContext);
        Task SaveAsync();
    }
}
