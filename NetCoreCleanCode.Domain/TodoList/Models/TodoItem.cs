using NetCoreCleanCode.Domain.Base;

namespace NetCoreCleanCode.Domain.TodoList.Models
{
    public class TodoItem
    {
        public string Description { get; set; } = "";
        public bool Done { get; set; } = false;
    }
}