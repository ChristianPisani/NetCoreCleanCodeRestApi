using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Queries.TodoLists.GetTodoLists;
using NetCoreCleanCode.Domain.TodoList.Models;
using NUnit.Framework;

namespace NetCoreCleanCode.Tests.Application.Queries.GetTodoLists
{
    public class GetTodoListsQueryHandlerTests
    {
        private readonly Mock<IDataRepository<IEnumerable<TodoList>>> _todoListServiceMock;
        private readonly Mock<GetTodoListsQuery> _todoListQueryMock;

        public GetTodoListsQueryHandlerTests()
        {
            _todoListServiceMock = new Mock<IDataRepository<IEnumerable<TodoList>>>();
            _todoListQueryMock = new Mock<GetTodoListsQuery>();
        }

        private GetTodolistsQueryHandler GetTarget()
        {
            return new GetTodolistsQueryHandler(_todoListServiceMock.Object);
        }

        [Test]
        public async Task HandleReturnsExpectedAmount()
        {
            var target = GetTarget();

            _todoListServiceMock.Setup(x => x.Get()).Returns(Task.FromResult(FakeTodoList));

            var result = await target.Handle(_todoListQueryMock.Object);

            Assert.AreEqual(FakeTodoList.Count(), result.Count());
        }

        private IEnumerable<TodoList> FakeTodoList => new List<TodoList>()
        {
            new TodoList()
            {
                Name = "Todolist",
                Items = new List<TodoItem>()
                {
                    new TodoItem()
                    {
                        Description = "Test",
                        Done = false
                    }
                }
            }
        };
    }
}