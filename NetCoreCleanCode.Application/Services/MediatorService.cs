using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;

namespace NetCoreCleanCode.Application.Services
{
    public class MediatorService : IMediatorService
    {
        private readonly IEnumerable<IQueryHandler<IQuery<IEnumerable<object>>>> _queryHandlers;

        public MediatorService(IEnumerable<IQueryHandler<IQuery<IEnumerable<object>>>> queryHandlers)
        {
            _queryHandlers = queryHandlers;
        }
        
        public async Task<IEnumerable<T>> Send<T>(IQuery<IEnumerable<T>> query)
        {
            return await _queryHandlers.First().Handle(query);
        }
    }

    public interface IMediatorService
    {
        Task<IEnumerable<T>> Send<T>(IQuery<IEnumerable<T>> query);
    }
}