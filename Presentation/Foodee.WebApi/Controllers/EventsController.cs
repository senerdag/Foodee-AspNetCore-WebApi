using Foodee.Application.Features.Mediator.Commands.EventCommands;
using Foodee.Application.Features.Mediator.Queries.EventQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodee.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> EventList()
        {
            var values = await _mediator.Send(new GetEventQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var value = await _mediator.Send(new GetEventByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventCommand command)
        {
            await _mediator.Send(command);
            return Ok("Event successfully created");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveEvent(int id)
        {
            await _mediator.Send(new RemoveEventCommand(id));
            return Ok("Event successfully removed");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEvent(UpdateEventCommand command)
        {
            await _mediator.Send(command);
            return Ok("Event successfully updated");
        }
    }
}
