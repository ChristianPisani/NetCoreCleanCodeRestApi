using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.Base;

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
            var queryHandler = _queryHandlerFactory.CreateQueryHandler<IQuery<TOut>>();

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