using Foodee.Application.Features.Mediator.Queries.CategoryQueries;
using Foodee.Application.Features.Mediator.Results.CategoryResults;
using Foodee.Application.Interfaces.CategoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Handlers.CategoryHandlers
{
	public class GetLastFourCategoryQueryHandler : IRequestHandler<GetLastFourCategoryQuery, List<GetLastFourCategoryQueryResult>>
	{
		private readonly ICategoryRepository _repository;

		public GetLastFourCategoryQueryHandler(ICategoryRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetLastFourCategoryQueryResult>> Handle(GetLastFourCategoryQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetLastFourCategory();
			return values.Select(x=> new GetLastFourCategoryQueryResult 
			{
				CategoryId = x.CategoryId,
				Description = x.Description,
				Icon=x.Icon,
				Name=x.Name
			}).ToList();
		}
	}
}
