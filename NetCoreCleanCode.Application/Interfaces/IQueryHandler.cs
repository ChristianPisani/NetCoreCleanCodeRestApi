using System;
using System.Threading.Tasks;

namespace NetCoreCleanCode.Application.Interfaces
{
    
    public interface IQueryHandler<in TQuery, TOut> where TQuery : class, IQuery<TOut>
    {
        Task<TOut> Handle(TQuery query);

        static Type QueryType
        {
            get => typeof(TQuery);
        }
        static Type OutputType
        {
            get => typeof(TOut);
        }
    }
}