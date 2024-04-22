using Foodee.Application.Features.Mediator.Commands.ContactInfoCommands;
using Foodee.Application.Features.Mediator.Queries.ContactInfoQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodee.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactInfosController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ContactInfoList()
        {
            var values = await _mediator.Send(new GetContactInfoQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactInfo(int id)
        {
            var value = await _mediator.Send(new GetContactInfoByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContactInfo(CreateContactInfoCommand command)
        {
            await _mediator.Send(command);
            return Ok("ContactInfo successfully created");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveContactInfo(int id)
        {
            await _mediator.Send(new RemoveContactInfoCommand(id));
            return Ok("ContactInfo successfully removed");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContactInfo(UpdateContactInfoCommand command)
        {
            await _mediator.Send(command);
            return Ok("ContactInfo successfully updated");
        }
    }
}
