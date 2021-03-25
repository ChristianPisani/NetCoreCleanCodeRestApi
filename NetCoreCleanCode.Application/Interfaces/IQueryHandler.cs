using System.Threading.Tasks;

namespace NetCoreCleanCode.Application.Interfaces
{
    public interface IQueryHandler<in TQuery, TOut>
    {
        Task<TOut> Handle(TQuery query);
    }
}