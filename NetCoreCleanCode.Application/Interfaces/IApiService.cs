using System.Threading.Tasks;

namespace NetCoreCleanCode.Application.Interfaces
{
    public interface IApiService<T>
    {
        Task<T> Get();
    }
}