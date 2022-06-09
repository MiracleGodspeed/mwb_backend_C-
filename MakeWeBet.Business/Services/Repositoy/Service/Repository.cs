using MakeWeBet.Business.Services.Repositoy.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Services.Repositoy
{
    public class Repository<T> : DbContext, IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        public Repository(DbContext context)
        {
            _dbSet = context.Set<T>();
            _dbContext = context;
        }

        public T Add(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public void Add(params T[] entities)
        {
            _dbSet.AddRange(entities);
        }


        public void Add(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }


        public void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }

        }

        public void Delete(params T[] entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Update(params T[] entities)
        {
            _dbSet.UpdateRange(entities);
        }


        public void Update(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }

}
