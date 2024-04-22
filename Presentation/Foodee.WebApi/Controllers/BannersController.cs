using Foodee.Application.Features.Mediator.Commands.BannerCommands;
using Foodee.Application.Features.Mediator.Queries.BannerQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodee.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BannersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _mediator.Send(new GetBannerQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _mediator.Send(new GetBannerByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Banner successfully created");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _mediator.Send(new RemoveBannerCommand(id));
            return Ok("Banner successfully removed");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Banner successfully updated");
        }
    }
}
