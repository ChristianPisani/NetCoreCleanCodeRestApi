using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreCleanCode.Application.Interfaces.Repositories
{
    public interface IExternalApiService<T>
    {
        Task<IEnumerable<T>> Get();
    }
}