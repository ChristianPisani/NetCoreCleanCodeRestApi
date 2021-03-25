using System.Collections.Generic;

namespace NetCoreCleanCode.Domain.TodoList.Models
{
    public class TodoList
    {
        public string Name { get; set; }
        public List<TodoItem> Items { get; set; } = new List<TodoItem>();
    }
}