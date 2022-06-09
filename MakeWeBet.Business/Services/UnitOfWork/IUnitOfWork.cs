using MakeWeBet.Business.Services.Repositoy.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Services.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryExtension<TEntity> GetRepository<TEntity>() where TEntity : class;

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext _dbContext { get; }
    }
}
