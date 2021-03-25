using System.Threading.Tasks;

namespace NetCoreCleanCode.Application.Interfaces
{
    public interface IMediatorService
    {
        Task<TOut> Send<TQuery, TOut>(TQuery query)
            where TQuery : IQuery;
    }
}