using MakeWeBet.Business.Services.Repositoy;
using MakeWeBet.Business.Services.Repositoy.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Services.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        public TContext _dbContext { get; }
        private Dictionary<Type, object> _repositories = null;

        public UnitOfWork(TContext context)
        {
            _dbContext = context;
        }

        public IRepositoryExtension<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var entityType = typeof(TEntity);
            if (!_repositories.ContainsKey(entityType)) _repositories[entityType] = new RepositoryExtension<TEntity>(_dbContext);
            return (IRepositoryExtension<TEntity>)_repositories[entityType];
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }

}
