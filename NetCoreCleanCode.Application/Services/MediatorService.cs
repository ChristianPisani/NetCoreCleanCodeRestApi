using System;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.Extensions;

namespace NetCoreCleanCode.Application.Services
{
    public class MediatorService : IMediatorService
    {
        private readonly IQueryHandlerFactory _queryHandlerFactory;
        public MediatorService(IQueryHandlerFactory queryHandlerFactory)
        {
            _queryHandlerFactory = queryHandlerFactory;
        }

        public async Task<TOut> Send<TOut>(IQuery<TOut> query) where TOut : class
        {
            var queryHandler = _queryHandlerFactory.CreateQueryHandler(query);

            if (queryHandler == null)
            {
                throw new Exception("No queryhandler found");
                
                // Log error

                return default;
            }

            try
            {
                var handleMethod = queryHandler?.InvokeMethod<Task<TOut>>("Handle", query);

                var result = await handleMethod;

                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Query handler does not have Handle method", e);
            }
        }
    }
}