using System.Linq;
using System.Threading.Tasks;
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

            var result = await target.Get();

            Assert.NotNull(result);
        }
        
        [Test]
        public async Task RepositoryReturnsTwoItems()
        {
            var target = GetTarget();

            var result = await target.Get();

            Assert.AreEqual(2, result.Count());
        }
    }
}