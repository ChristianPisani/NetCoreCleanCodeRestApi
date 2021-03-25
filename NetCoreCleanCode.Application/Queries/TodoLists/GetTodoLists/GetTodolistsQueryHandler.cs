using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCode.Application.Queries.TodoLists.GetTodoLists
{
    public class GetTodolistsQueryHandler : QueryHandler<GetTodoListsQuery, IEnumerable<TodoList>>
    {
        private readonly IDataRepository<IEnumerable<TodoList>> _todoListService;

        public GetTodolistsQueryHandler(IDataRepository<IEnumerable<TodoList>> todoListService)
        {
            _todoListService = todoListService;
        }
        
        public override async Task<IEnumerable<TodoList>> Handle(GetTodoListsQuery query)
        {
            return await _todoListService.Get();
        }
    }
}