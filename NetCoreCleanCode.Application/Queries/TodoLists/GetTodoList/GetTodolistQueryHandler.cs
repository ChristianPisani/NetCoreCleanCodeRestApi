using System;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCode.Application.Queries.TodoLists.GetTodoList
{
    public class GetTodolistQueryHandler : IQueryHandler<GetTodoListQuery, TodoListModel>
    {
        private readonly IDataRepository<TodoListModel> _todoListService;

        public GetTodolistQueryHandler(IDataRepository<TodoListModel> todoListService)
        {
            _todoListService = todoListService;
        }

        public async Task<TodoListModel> Handle(GetTodoListQuery query)
        {
            return await _todoListService.Get(query) ?? throw new Exception("No todoitem found");
        }
    }
}