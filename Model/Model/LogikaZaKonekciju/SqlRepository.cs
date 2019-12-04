using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Model
{
    public class SqlRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        DbSet<TEntity> _set;
        public SqlRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public void AddMultiple(IEnumerable<TEntity> entities)
        {
            _set.AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate)
        {
            return _set.Where(predicate);
        }

        public TEntity Get(int id)
        {
            return _set.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _set.ToList();
        }

        public void Remove(TEntity entity)
        {
            _set.Remove(entity);
        }

        public void RemoveMultiple(IEnumerable<TEntity> entities)
        {
            _set.RemoveRange(entities);
        }
    }
}
