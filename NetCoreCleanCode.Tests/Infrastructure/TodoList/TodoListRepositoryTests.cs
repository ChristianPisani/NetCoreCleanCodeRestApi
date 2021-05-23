using System.Threading.Tasks;
using NetCoreCleanCode.Application.Queries.TodoLists.GetTodoList;
using NetCoreCleanCode.Infrastructure.TodoList.Repositories;
using NUnit.Framework;

namespace NetCoreCleanCode.Tests.Infrastructure.TodoList
{
    public class TodoListRepositoryTests
    {
        private TodoListRepository GetTarget()
        {
            return new TodoListRepository();
        }

        [Test]
        public async Task RepositoryReturnsValue()
        {
            var target = GetTarget();

            var result = await target.Get(new GetTodoListQuery("Todolist 1"));

            Assert.NotNull(result);
        }
    }
}