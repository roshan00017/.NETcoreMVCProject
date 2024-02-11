using Microsoft.EntityFrameworkCore;
using MVCProject.Data;
using MVCProject.Repository.Interfaces;
using System.Linq.Expressions;

namespace MVCProject.Repository.Implemenentaion
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private TaskDbContext _dbContext;

        protected readonly DbSet<T> _dbSet;

        public GenericRepository(TaskDbContext context)
        {
            _dbContext = context;

            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(int Id)
        {
            //First, fetch the record from the table
            var entity = await _dbSet.FindAsync(Id);
            if (entity != null)
            {
                //This will mark the Entity State as Deleted
                _dbSet.Remove(entity);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }


        // pg,sort,search

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
                                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                    string includeProperties = "", int pageNumber = 1,
                                                 int pageSize = 10)
        {
            try
            {
                IQueryable<T> query = _dbSet;

                // Apply filtering
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                // Include related entities if specified
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                // Apply ordering
                if (orderBy != null)
                {
                    query = orderBy(query);
                }

                query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

                return await query.ToListAsync();
            }catch (Exception ex) {
                return null;
            }   
          
        }


        public void SetDbContext(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

