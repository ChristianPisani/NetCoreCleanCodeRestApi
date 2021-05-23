using System.Collections.Generic;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Interfaces.Parameters;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCode.Application.Queries.TodoLists.GetTodoList
{
    public class GetTodoListQuery : IQuery<TodoListModel>, IAmount
    {
        public int Amount { get; }

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