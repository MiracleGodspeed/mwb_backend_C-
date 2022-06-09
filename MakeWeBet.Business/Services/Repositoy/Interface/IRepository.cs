using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Services.Repositoy.Interface
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void Add(params T[] entities);
        void Add(IEnumerable<T> entities);
        void Delete(object id);
        void Delete(params T[] entities);
        void Delete(IEnumerable<T> entities);
        void Update(T entity);
        void Update(params T[] entities);
        void Update(IEnumerable<T> entities);
    }
}
