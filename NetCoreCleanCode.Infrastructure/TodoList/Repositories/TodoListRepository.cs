using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Interfaces.Parameters;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCode.Infrastructure.TodoList.Repositories
{
    public class TodoListRepository 
        : IDataRepository<IEnumerable<TodoListModel>>, 
            IDataRepository<TodoListModel>
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

        public async Task<IEnumerable<TodoListModel>> Get(IQuery<IEnumerable<TodoListModel>> query)
        {
            return TodoLists;
        }
        
        public async Task<TodoListModel> Get(IQuery<TodoListModel> query)
        {
            if (query is IName namedQuery)
            {
                return TodoLists.FirstOrDefault(todoList => todoList.Name == namedQuery.Name);
            }

            throw new Exception("Query must implement IName interface to be used in TodoListRepository - Get");
        }
    }
}