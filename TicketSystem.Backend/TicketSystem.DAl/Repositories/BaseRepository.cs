using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketSystem.Core.Repositories;
using TicketSystem.DAl.Data;

namespace TicketSystem.DAl.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected TicketDbContext _context;
        internal DbSet<TEntity> _dbSet;

        public BaseRepository(TicketDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        // Sync Methods
        public bool Add(TEntity entity) => _dbSet.Add(entity) != null;
        public bool Delete(TEntity entity) { _dbSet.Remove(entity); return true; }
        public bool DeleteRange(IEnumerable<TEntity> entities) { _dbSet.RemoveRange(entities); return true; }
        public TEntity? Find(Expression<Func<TEntity, bool>> criteria) => _dbSet.SingleOrDefault(criteria);
        public TEntity? Find(Expression<Func<TEntity, bool>> criteria, string[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            return query.FirstOrDefault(criteria);
        }
        public IEnumerable<TEntity?> FindAll(Expression<Func<TEntity, bool>> criteria) => _dbSet.Where(criteria).ToList();
        public IEnumerable<TEntity?> FindAll(Expression<Func<TEntity, bool>> criteria, string[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            return query.Where(criteria).ToList();
        }
        public IEnumerable<TEntity?> GetAll() => _dbSet.ToList();
        public TEntity? GetById(int id) => _dbSet.Find(id);
        public bool Update(TEntity entity) { _context.Update(entity); return true; }
        public bool UpdateRange(IEnumerable<TEntity> entities) { _context.UpdateRange(entities); return true; }

        public int Count() => _dbSet.Count();
        public int Count(Expression<Func<TEntity, bool>> criteria) => _dbSet.Count(criteria);

        // Async Methods
        public async Task<bool> AddAsync(TEntity entity) { await _dbSet.AddAsync(entity); return true; }
        public async Task<int> CountAsync() => await _dbSet.CountAsync();
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria) => await _dbSet.CountAsync(criteria);
        public async Task<bool> DeleteRangeAsync(IEnumerable<TEntity> entities) { _dbSet.RemoveRange(entities); return await Task.FromResult(true); }
        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria) => await _dbSet.SingleOrDefaultAsync(criteria);
        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria, string[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            return await query.SingleOrDefaultAsync(criteria);
        }
        public async Task<IEnumerable<TEntity?>> FindAllAsync(Expression<Func<TEntity, bool>> criteria) => await _dbSet.Where(criteria).ToListAsync();
        public async Task<IEnumerable<TEntity?>> FindAllAsync(Expression<Func<TEntity, bool>> criteria, string[] includes)
        {
            IQueryable<TEntity> query = _dbSet;
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            return await query.Where(criteria).ToListAsync();
        }
        public async Task<IEnumerable<TEntity?>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<TEntity?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
    }
}
