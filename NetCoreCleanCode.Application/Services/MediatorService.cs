using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;

namespace NetCoreCleanCode.Application.Services
{
    public class MediatorService : IMediatorService
    {
        private readonly IQueryHandlerFactory _queryHandlerFactory;

        public MediatorService(IQueryHandlerFactory queryHandlerFactory)
        {
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