using System;
using Microsoft.Extensions.DependencyInjection;
using NetCoreCleanCode.Application.Interfaces;

namespace NetCoreCleanCode.Application.Services
{
    public class QueryHandlerFactoryService : IQueryHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryHandlerFactoryService(IServiceProvider serviceProvider)
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