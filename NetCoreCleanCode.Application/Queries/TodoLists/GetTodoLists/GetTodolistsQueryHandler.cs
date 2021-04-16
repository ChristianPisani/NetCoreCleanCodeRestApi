using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCode.Application.Queries.TodoLists.GetTodoLists
{
    public class GetTodolistsQueryHandler : IQueryHandler<IQuery<IEnumerable<TodoListModel>>>
    {
        private readonly IDataRepository<GetTodoListsQuery, IEnumerable<TodoListModel>> _todoListService;

        public GetTodolistsQueryHandler(IDataRepository<GetTodoListsQuery, IEnumerable<TodoListModel>> todoListService)
        {
            _todoListService = todoListService;
        }

        public async Task<TOut> Handle<TOut>(IQuery<TOut> query) where TOut : class
        {
            return await _todoListService.Get(query);
        }
    }
}