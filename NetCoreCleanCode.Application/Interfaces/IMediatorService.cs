using System.Threading.Tasks;

namespace NetCoreCleanCode.Application.Interfaces
{
    public interface IMediatorService
    {
        Task<TOut> Send<TOut>(IQuery<TOut> query) where TOut : class;
    }
}