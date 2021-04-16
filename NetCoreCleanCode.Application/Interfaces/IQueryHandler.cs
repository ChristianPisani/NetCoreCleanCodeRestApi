using System.Threading.Tasks;
using NetCoreCleanCode.Domain.Base;

namespace NetCoreCleanCode.Application.Interfaces
{
    public interface IQueryHandler<in TQuery>
    {
        Task<TOut> Handle<TOut>(IQuery<TOut> query) where TOut : class;
    }
}