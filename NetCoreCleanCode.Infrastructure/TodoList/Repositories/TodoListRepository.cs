using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCode.Infrastructure.TodoList.Repositories
{
    public class TodoListRepository : IDataRepository<IEnumerable<Domain.TodoList.Models.TodoList>>
    {
        private readonly List<Domain.TodoList.Models.TodoList> TodoLists = new List<Domain.TodoList.Models.TodoList>()
        {
            new Domain.TodoList.Models.TodoList()
            {
                Name = "Todolist 1",
                Items = new List<TodoItem>()
                {
                    new TodoItem() { Description = "Do stuff" },
                    new TodoItem() { Description = "Do more stuff" }
                }
            },
            new Domain.TodoList.Models.TodoList()
            {
                Name = "Todolist 2",
                Items = new List<TodoItem>()
                {
                    new TodoItem() { Description = "Do fun stuff" },
                    new TodoItem() { Description = "Do boring stuff" }
                }
            }
        };
        
        public async Task<IEnumerable<Domain.TodoList.Models.TodoList>> Get()
        {
            return TodoLists;
        }
    }
}