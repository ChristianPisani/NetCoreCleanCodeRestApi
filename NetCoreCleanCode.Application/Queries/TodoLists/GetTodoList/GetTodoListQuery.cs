using System.Collections.Generic;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Interfaces.Parameters;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCode.Application.Queries.TodoLists.GetTodoList
{
    public class GetTodoListQuery : IQuery<TodoListModel>, IName
    {
        public string Name { get; set; }

        public GetTodoListQuery()
        {
            Name = "Default";
        }

        public GetTodoListQuery(string name)
        {
            Name = name;
        }
    }
}