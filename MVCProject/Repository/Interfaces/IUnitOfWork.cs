namespace MVCProject.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;

        TRepository GenericRepository<TRepository, TEntity>() where TRepository : class,
          IGenericRepository<TEntity> where TEntity : class;

        void CreateTransaction();
        void Commit();
        void Rollback();


        Task Save();
    }
}
