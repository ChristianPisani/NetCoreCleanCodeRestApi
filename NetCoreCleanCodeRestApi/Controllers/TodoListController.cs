using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreCleanCode.Application.Interfaces;
using NetCoreCleanCode.Application.Queries.TodoLists.GetTodoList;
using NetCoreCleanCode.Application.Queries.TodoLists.GetTodoLists;
using NetCoreCleanCode.Domain.TodoList.Models;

namespace NetCoreCleanCodeRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly IMediatorService _mediatorService; 

        private readonly ILogger<TodoListController> _logger;

        public TodoListController(ILogger<TodoListController> logger,
            IMediatorService mediatorService)
        {
            _logger = logger;
            _mediatorService = mediatorService;
        }

        [HttpGet]
        [Route("TodoLists")]
        public async Task<IEnumerable<TodoListModel>> GetLists([FromQuery] GetTodoListsQuery query)
        {
            return await _mediatorService.Send(query);
        }
        
        [HttpGet]
        [Route("TodoList")]
        public async Task<TodoListModel> GetList([FromQuery] GetTodoListQuery query)
        {
            return await _mediatorService.Send(query);
        }
    }
}