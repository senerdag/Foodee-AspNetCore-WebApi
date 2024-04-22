using Foodee.Application.Features.Mediator.Commands.CategoryCommands;
using Foodee.Application.Features.Mediator.Queries.CategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodee.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _mediator.Send(new GetCategoryQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok("Category successfully created");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _mediator.Send(new RemoveCategoryCommand(id));
            return Ok("Category successfully removed");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok("Category successfully updated");
        }
		[HttpGet("GetLastFourCategoryList")]
		public async Task<IActionResult> GetLastFourCategoryList()
		{
			var values = await _mediator.Send(new GetLastFourCategoryQuery());
			return Ok(values);
		}
	}
}
