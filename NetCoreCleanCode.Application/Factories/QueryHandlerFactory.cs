using System;
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

        public IQueryHandler<TQuery, TOut> CreateQueryHandler<TQuery, TOut>()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                return scope.ServiceProvider.GetService(typeof(IQueryHandler<TQuery, TOut>)) as
                    IQueryHandler<TQuery, TOut>;
            }
        }
    }
}