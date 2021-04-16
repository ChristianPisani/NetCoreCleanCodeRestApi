using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Queries.TodoLists.GetTodoLists;
using NetCoreCleanCode.Domain.Base;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCode.Infrastructure.TodoList.Services
{
    public class TodoListService : IApiService<GetTodoListsQuery, IEnumerable<TodoListModel>>
    {
        private readonly IDataRepository<GetTodoListsQuery, IEnumerable<TodoListModel>> _todoListRepository;

        public TodoListService(IDataRepository<GetTodoListsQuery, IEnumerable<TodoListModel>> todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        public async Task<T> Get<T>(IQuery<T> query) where T : class
        {
            return await _todoListRepository.Get(query);
        }
    }
}