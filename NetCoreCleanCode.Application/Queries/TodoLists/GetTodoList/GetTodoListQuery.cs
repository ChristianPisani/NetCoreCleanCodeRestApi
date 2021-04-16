using System.Collections.Generic;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCode.Application.Queries.TodoLists.GetTodoList
{
    public class GetTodoListQuery : IQuery<TodoListModel>
    {
        public int Amount { get; private set; }

        public GetTodoListQuery()
        {
            Amount = 0;
        }

        public GetTodoListQuery(int amount)
        {
            Amount = amount;
        }
    }
}