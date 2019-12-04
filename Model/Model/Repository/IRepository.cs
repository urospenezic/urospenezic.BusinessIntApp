using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IRepository<TEntity>:IDisposable where TEntity:class
    {
        void Add(TEntity entity);
        void AddMultiple(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveMultiple(IEnumerable<TEntity> entities);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity,bool>> predicate);
        void Commit();
        void Update(TEntity zamena);
    }
}
