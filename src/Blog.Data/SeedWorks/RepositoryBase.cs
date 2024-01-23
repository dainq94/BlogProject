using Blog.Core.SeedWorks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Data.SeedWorks
{
    public class RepositoryBase<T, Key> : IRepository<T, Key> where T : class
    {
        private readonly DbSet<T> dbSet;
        protected readonly BlogContext context;
        public RepositoryBase(BlogContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.AddAsync(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Key id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
