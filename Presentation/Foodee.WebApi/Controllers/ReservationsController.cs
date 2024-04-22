using Foodee.Application.Features.Mediator.Commands.ReservationCommands;
using Foodee.Application.Features.Mediator.Queries.ReservationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodee.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ReservationList()
        {
            var values = await _mediator.Send(new GetReservationQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(int id)
        {
            var value = await _mediator.Send(new GetReservationByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Reservation successfully created");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveReservation(int id)
        {
            await _mediator.Send(new RemoveReservationCommand(id));
            return Ok("Reservation successfully removed");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateReservation(UpdateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Reservation successfully updated");
        }
    }
}
