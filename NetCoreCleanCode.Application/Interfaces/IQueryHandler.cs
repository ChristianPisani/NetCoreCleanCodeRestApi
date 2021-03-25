using System;
using System.Threading.Tasks;

namespace NetCoreCleanCode.Application.Interfaces
{
    public interface IQueryHandler<in TQuery, TOut>
    {
        Type QueryType { get; }

        Task<TOut> Handle(TQuery query);
    }

    public abstract class QueryHandler<TQuery, TOut> : IQueryHandler<TQuery, TOut>
    {
        public Type QueryType => typeof(TQuery);
        public virtual Task<TOut> Handle(TQuery query)
        {
            throw new NotImplementedException();
        }
    }
}