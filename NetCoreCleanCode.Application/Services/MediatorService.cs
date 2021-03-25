using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;

namespace NetCoreCleanCode.Application.Services
{
    public class MediatorService : IMediatorService
    {
        private readonly IEnumerable<IQueryHandler<Type, Type>> _queryHandlers;
        private readonly IQueryHandlerFactory _queryHandlerFactory;

        public MediatorService(IEnumerable<IQueryHandler<Type, Type>> queryHandlers,
            IQueryHandlerFactory queryHandlerFactory)
        {
            _queryHandlers = queryHandlers;
            _queryHandlerFactory = queryHandlerFactory;
        }

        public async Task<TOut> Send<TQuery, TOut>(TQuery query) where TQuery : IQuery
        {
            var queryHandler = _queryHandlerFactory.CreateQueryHandler<TQuery, TOut>();

            if (queryHandler == null)
            {
                // Log error

                return default;
            }

            var result = await queryHandler.Handle(query);

            return result;
        }
    }
}