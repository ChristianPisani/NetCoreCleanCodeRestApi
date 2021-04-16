
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Queries.TodoLists.GetTodoList;
using NetCoreCleanCode.Application.Queries.TodoLists.GetTodoLists;
using NetCoreCleanCode.Domain.Base;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCode.Infrastructure.TodoList.Repositories
{
    public class TodoListRepository 
        : IDataRepository<GetTodoListsQuery, IEnumerable<TodoListModel>>, 
            IDataRepository<GetTodoListQuery, TodoListModel>
    {
        private readonly IEnumerable<TodoListModel> TodoLists = new List<TodoListModel>
        {
            new TodoListModel
            {
                Name = "Todolist 1",
                Items = new List<TodoItem>
                {
                    new TodoItem { Description = "Do stuff" },
                    new TodoItem { Description = "Do more stuff" }
                }
            },
            new TodoListModel
            {
                Name = "Todolist 2",
                Items = new List<TodoItem>
                {
                    new TodoItem { Description = "Do fun stuff" },
                    new TodoItem { Description = "Do boring stuff" }
                }
            }
        };

        public async Task<TOutModel> Get<TOutModel>(IQuery<TOutModel> query) where TOutModel : class
        {
            return TodoLists as TOutModel;
        }
    }
}