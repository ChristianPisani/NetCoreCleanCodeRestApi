using System.Collections.Generic;
using NetCoreCleanCode.Domain.Base;

namespace NetCoreCleanCode.Domain.TodoList.Models
{
    public class TodoListModel
    {
        public string Name { get; set; }
        public List<TodoItem> Items { get; set; } = new List<TodoItem>();
    }
}