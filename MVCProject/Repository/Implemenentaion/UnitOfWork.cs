using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using MVCProject.Repository.Interfaces;
using MVCProject.Data;

namespace MVCProject.Repository.Implemenentaion
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {



        private readonly TaskDbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;
        private IDbContextTransaction? _objTran = null;


        public UnitOfWork(TaskDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
        }

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_dbContext);
        }


        TRepository IUnitOfWork.GenericRepository<TRepository, TEntity>()
        {
            var repository = _serviceProvider.GetService<TRepository>();

            if (repository == null)
            {
                throw new InvalidOperationException($"Failed to get repository of type {typeof(TRepository)}");
            }

            // Set the DbContext
            if (repository is IGenericRepository<TEntity> genericRepository)
            {
                genericRepository.SetDbContext(_dbContext);
            }
            else
            {
                throw new InvalidOperationException($"Repository of type {typeof(TRepository)} does not implement IRepository<TEntity>.");
            }

            return repository;
        }
        public void CreateTransaction()
        {
            //It will Begin the transaction on the underlying connection
            _objTran = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            //Commits the underlying store transaction
            _objTran?.Commit();
        }

        public void Rollback()
        {
            //Rolls back the underlying store transaction
            _objTran?.Rollback();
            //The Dispose Method will clean up this transaction object and ensures Entity Framework
            //is no longer using that transaction.
            _objTran?.Dispose();
        }

        public async Task Save()
        {
            try
            {
                //Calling DbContext Class SaveChanges method 
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Handle the exception, possibly logging the details
                // The InnerException often contains more specific details
                throw new Exception(ex.Message, ex);
            }
        }


        public void Dispose()
        {
            _dbContext.Dispose();
        }



    }
}


