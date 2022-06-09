using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeWeBet.Business.Services.Shared.Interface
{
    public interface IServiceFactory
    {
        object GetService(Type type);
        T GetService<T>() where T : class;
    }
}
