using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Queries.WeatherForecast;
using NetCoreCleanCode.Domain.Base;
using NetCoreCleanCode.Domain.WeatherForecast.Models;

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
            var type = 
                typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TOut));

            // type.GetMethod("Handle").MakeGenericMethod(query.GetType()).Invoke( type);
            
            var queryHandler = _queryHandlerFactory.CreateQueryHandler(type);

            if (queryHandler == null)
            {
                throw new Exception("No queryhandler found");
                
                // Log error

                return default;
            }

            if (!(queryHandler?.GetType()?.GetMethods()?.FirstOrDefault(m => m.Name == "Handle") is MethodInfo handleMethod))
            {
                throw new Exception("Query handler not convertible");
            }

            var result = await (Task<TOut>)handleMethod.Invoke(queryHandler, new object?[] { query });

            return result;
        }
    }
}