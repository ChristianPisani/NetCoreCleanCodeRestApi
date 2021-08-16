using System;
using System.Threading.Tasks.Sources;
using Microsoft.Extensions.DependencyInjection;
using NetCoreCleanCode.Application.Interfaces;

namespace NetCoreCleanCode.Application.Factories
{
    public class QueryHandlerFactory : IQueryHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object CreateQueryHandler<TOut>(IQuery<TOut> query)
        {
            // Cache reflected type
            // Null checks
            // Throw errors
            // Logging
            
            var reflectedType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TOut));

            using (var scope = _serviceProvider.CreateScope())
            {
                var handler = scope.ServiceProvider.GetService(reflectedType);
                
                return handler;
            }
        }
    }
}