using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCode.Infrastructure.TodoList.Services
{
    public class TodoListService : IApiService<IEnumerable<TodoListModel>>
    {
        private readonly IDataRepository<IEnumerable<TodoListModel>> _todoListRepository;

        public TodoListService(IDataRepository<IEnumerable<TodoListModel>> todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        public async Task<IEnumerable<TodoListModel>> Get(IQuery<IEnumerable<TodoListModel>> query)
        {
            return await _todoListRepository.Get(query);
        }
    }
}