using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCode.Application.Queries.TodoLists.GetTodoLists
{
    public class GetTodolistsQueryHandler : IQueryHandler<GetTodoListsQuery, IEnumerable<TodoListModel>>
    {
        private readonly IDataRepository<IEnumerable<TodoListModel>> _todoListService;

        public GetTodolistsQueryHandler(IDataRepository<IEnumerable<TodoListModel>> todoListService)
        {
            _todoListService = todoListService;
        }

        public async Task<IEnumerable<TodoListModel>> Handle(GetTodoListsQuery query)
        {
            var s = query is IQuery<IEnumerable<TodoListModel>> t;
            
            return await _todoListService.Get(query);
        }
    }
}