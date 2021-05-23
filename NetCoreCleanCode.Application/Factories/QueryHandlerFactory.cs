using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Queries.TodoLists.GetTodoList;
using NetCoreCleanCode.Application.Queries.WeatherForecast;
using NetCoreCleanCode.Domain.Extensions;
using NetCoreCleanCode.Domain.WeatherForecast.Models;

namespace NetCoreCleanCode.Application.Factories
{
    public class QueryHandlerFactory : IQueryHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object CreateQueryHandler(Type queryType)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var handler = scope.ServiceProvider.GetService(queryType);

                return handler;
            }
            
            /*var handlerType = typeof(IQueryHandler<,>).GetGenericTypeDefinition();
            
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assemblyTypes = assemblies.SelectMany(assembly => assembly.GetTypes());

            var implementationType = assemblyTypes.FirstOrDefault(assemblyType =>
                assemblyType.ImplementsGenericInterface(handlerType, queryType));

            if (implementationType == null)
            {
                throw new Exception("No query handler implementation found");
            }

            return Activator.CreateInstance(implementationType);*/
        }
    }
}