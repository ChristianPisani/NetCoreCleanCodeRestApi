using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCode.Application.Queries.TodoLists.GetTodoList
{
    public class GetTodolistQueryHandler : IQueryHandler<IQuery<TodoListModel>>
    {
        private readonly IDataRepository<GetTodoListQuery, TodoListModel> _todoListService;

        public GetTodolistQueryHandler(IDataRepository<GetTodoListQuery, TodoListModel> todoListService)
        {
            _todoListService = todoListService;
        }

        public async Task<TOut> Handle<TOut>(IQuery<TOut> query) where TOut : class
        {
            return await _todoListService.Get(query);
        }
    }
}