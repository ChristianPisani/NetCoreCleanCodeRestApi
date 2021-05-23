using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCode.Application.Queries.TodoLists.GetTodoLists
{
    public class GetTodolistsQueryHandler : QueryHandler<GetTodoListsQuery, IEnumerable<TodoListModel>>
    {
        private readonly IDataRepository<GetTodoListsQuery, IEnumerable<TodoListModel>> _todoListService;

        public GetTodolistsQueryHandler(IDataRepository<GetTodoListsQuery, IEnumerable<TodoListModel>> todoListService)
        {
            _todoListService = todoListService;
        }

        public override async Task<IEnumerable<TodoListModel>> Handle(GetTodoListsQuery query)
        {
            var s = query is IQuery<IEnumerable<TodoListModel>> t;
            
            return await _todoListService.Get(query);
        }
    }
}