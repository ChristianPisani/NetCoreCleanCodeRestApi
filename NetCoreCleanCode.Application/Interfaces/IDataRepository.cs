using System.Threading.Tasks;

namespace NetCoreCleanCode.Application.Interfaces
{
    public interface IDataRepository<TOut> where TOut : class
    {
        Task<TOut> Get(IQuery<TOut> query);
    }
}