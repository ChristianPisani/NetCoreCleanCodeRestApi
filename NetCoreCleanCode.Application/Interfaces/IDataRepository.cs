using System.Threading.Tasks;

namespace NetCoreCleanCode.Application.Interfaces
{
    public interface IDataRepository<T>
    {
        Task<T> Get();
    }
}