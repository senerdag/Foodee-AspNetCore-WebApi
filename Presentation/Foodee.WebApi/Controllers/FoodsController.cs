using Foodee.Application.Features.Mediator.Commands.FoodCommands;
using Foodee.Application.Features.Mediator.Queries.CategoryQueries;
using Foodee.Application.Features.Mediator.Queries.FoodQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodee.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FoodsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> FoodList()
        {
            var values = await _mediator.Send(new GetFoodQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFood(int id)
        {
            var value = await _mediator.Send(new GetFoodByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFood(CreateFoodCommand command)
        {
            await _mediator.Send(command);
            return Ok("Food successfully created");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFood(int id)
        {
            await _mediator.Send(new RemoveFoodCommand(id));
            return Ok("Food successfully removed");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFood(UpdateFoodCommand command)
        {
            await _mediator.Send(command);
            return Ok("Food successfully updated");
        }
		[HttpGet("GetCategoryWithFoodsList")] 
		public async Task<IActionResult> GetCategoryWithFoodsList()
		{
			var values = await _mediator.Send(new GetCategoryWithFoodsQuery());
			return Ok(values);
		}
		[HttpGet("GetLast6FoodList")] 
		public async Task<IActionResult> GetLast6FoodList()
		{
			var values = await _mediator.Send(new GetLast6FoodQuery());
			return Ok(values);
		}
	}
}
