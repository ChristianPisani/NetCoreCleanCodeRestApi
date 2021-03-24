using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace NetCoreCleanCode.Application.Interfaces
{
    public interface IQueryHandler<out TQuery>
    {
        Type QueryType { get; }
        
        Task<IEnumerable<T>> Handle<T>(IQuery<IEnumerable<T>> query);
    }
}