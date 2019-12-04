using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Model
{
    public class SqlRepository<TEntity> : IRepository<TEntity>,IDisposable where TEntity : class
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
            if (entity != null)
            {
                _set.Add(entity);
                
            }
            else throw new NullReferenceException("Object is null");
        }

        public void AddMultiple(IEnumerable<TEntity> entities)
        {
            if (entities != null)
                _set.AddRange(entities);
            else throw new NullReferenceException("Object is null");
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        // Mozda moze IQueryable umesto IEnumerable:
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
            if(_set.Count()>0)
            _set.Remove(entity);
        }

        public void RemoveMultiple(IEnumerable<TEntity> entities)
        {
            if(_set.Count()>1)
            _set.RemoveRange(entities);
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            if(entity!=null)
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
