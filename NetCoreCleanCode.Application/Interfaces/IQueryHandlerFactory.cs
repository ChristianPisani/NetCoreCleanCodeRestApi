using System;

namespace NetCoreCleanCode.Application.Interfaces
{
    public interface IQueryHandlerFactory
    {
        object CreateQueryHandler(Type t);
    }
}