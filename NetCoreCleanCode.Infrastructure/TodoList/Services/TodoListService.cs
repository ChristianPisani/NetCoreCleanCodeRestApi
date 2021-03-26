using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;

namespace NetCoreCleanCode.Infrastructure.TodoList.Services
{
    public class TodoListService : IApiService<IEnumerable<Domain.TodoList.Models.TodoList>>
    {
        private readonly IDataRepository<IEnumerable<Domain.TodoList.Models.TodoList>> _todoListRepository;

        public TodoListService(IDataRepository<IEnumerable<Domain.TodoList.Models.TodoList>> todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }
        
        public async Task<IEnumerable<Domain.TodoList.Models.TodoList>> Get()
        {
            // Map to domain model
            
            return await _todoListRepository.Get();
        }
    }
}