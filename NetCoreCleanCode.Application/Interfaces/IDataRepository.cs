using System.Threading.Tasks;

namespace NetCoreCleanCode.Application.Interfaces
{
    public interface IDataRepository<in TQuery, TOut> 
        where TQuery : IQuery<TOut>
    {
        Task<TOutModel> Get<TOutModel>(IQuery<TOutModel> query) where TOutModel : class;
    }
}