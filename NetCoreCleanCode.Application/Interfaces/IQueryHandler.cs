using System;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Queries.TodoLists.GetTodoList;
using NetCoreCleanCode.Domain.Base;

namespace NetCoreCleanCode.Application.Interfaces
{
    
    public interface IQueryHandler<out TQuery, TOut> where TQuery : class, IQuery<TOut>
    {
        Task<TOut> Handle(IQuery<TOut> query);

        static Type QueryType
        {
            get => typeof(TQuery);
        }
        static Type OutputType
        {
            get => typeof(TOut);
        }
    }
    
    public abstract class QueryHandler<TQuery, TOut> : IQueryHandler<TQuery, TOut> where TQuery : class, IQuery<TOut>
    {
        public Task<TOut> Handle(IQuery<TOut> query)
        {
            if (!(query is TQuery typeQuery))
            {
                throw new Exception("Handler does not support this type of query");
            }
            
            return Handle(typeQuery);
        }
        
        public static implicit operator QueryHandler<IQuery<TOut>, TOut>(QueryHandler<TQuery, TOut> queryHandler)
        {
            return queryHandler;
        }

        public abstract Task<TOut> Handle(TQuery query);
    }
}