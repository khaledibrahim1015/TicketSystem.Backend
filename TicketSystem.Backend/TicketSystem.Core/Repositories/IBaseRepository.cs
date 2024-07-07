using System.Linq.Expressions;

namespace TicketSystem.Core.Repositories
{
    /// <summary>
    /// Interface for base repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity?> GetAll();
        TEntity? GetById(int id);
        bool Add(TEntity entity);
        bool Update(TEntity entity);
        bool UpdateRange(IEnumerable<TEntity> entities);
        bool Delete(TEntity entity);
        bool DeleteRange(IEnumerable<TEntity> entities);

        TEntity? Find(Expression<Func<TEntity, bool>> criteria);
        TEntity? Find(Expression<Func<TEntity, bool>> criteria, string[] includes);
        IEnumerable<TEntity?> FindAll(Expression<Func<TEntity, bool>> criteria);
        IEnumerable<TEntity?> FindAll(Expression<Func<TEntity, bool>> criteria, string[] includes);

        int Count();
        int Count(Expression<Func<TEntity, bool>> criteria);

        Task<IEnumerable<TEntity?>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> DeleteRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria);
        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria, string[] includes);
        Task<IEnumerable<TEntity?>> FindAllAsync(Expression<Func<TEntity, bool>> criteria);
        Task<IEnumerable<TEntity?>> FindAllAsync(Expression<Func<TEntity, bool>> criteria, string[] includes);

        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria);
    }
}
