using System.Collections.Generic;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCode.Application.Queries.TodoLists.GetTodoLists
{
    public class GetTodoListsQuery : IQuery<IEnumerable<TodoListModel>>
    {
        public int Amount { get; private set; }

        public GetTodoListsQuery()
        {
            Amount = 0;
        }

        public GetTodoListsQuery(int amount)
        {
            Amount = amount;
        }
    }
}