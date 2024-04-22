using Foodee.Application.Features.Mediator.Commands.QuoteCommands;
using Foodee.Application.Features.Mediator.Queries.QuoteQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodee.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuotesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> QuoteList()
        {
            var values = await _mediator.Send(new GetQuoteQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuote(int id)
        {
            var value = await _mediator.Send(new GetQuoteByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuote(CreateQuoteCommand command)
        {
            await _mediator.Send(command);
            return Ok("Quote successfully created");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveQuote(int id)
        {
            await _mediator.Send(new RemoveQuoteCommand(id));
            return Ok("Quote successfully removed");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateQuote(UpdateQuoteCommand command)
        {
            await _mediator.Send(command);
            return Ok("Quote successfully updated");
        }
    }
}
