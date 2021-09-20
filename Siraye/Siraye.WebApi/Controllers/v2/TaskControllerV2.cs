using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siraye.Application.Features.Tasks.Commands.CreateTask;
using Siraye.Application.Features.Tasks.Commands.DeleteTaskById;
using Siraye.Application.Features.Tasks.Commands.UpdateTask;
using Siraye.Application.Features.Tasks.Queries.GetAllTasks;
using Siraye.Application.Features.Tasks.Queries.GetTaskById;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Siraye.WebApi.Controllers.v2
{
    [ApiVersion("2.0")]
    public class TaskControllerV2 : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllTasksParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllTasksQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTaskByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Post(CreateTaskCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> Put(int id, UpdateTaskCommand command)
        {
            if (id != command.id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTaskByIdCommand { Id = id }));
        }
    }
}
