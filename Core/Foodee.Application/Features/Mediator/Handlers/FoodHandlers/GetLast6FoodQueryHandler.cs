using Foodee.Application.Features.Mediator.Queries.FoodQueries;
using Foodee.Application.Features.Mediator.Results.FoodResults;
using Foodee.Application.Interfaces.FoodInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Handlers.FoodHandlers
{
	public class GetLast6FoodQueryHandler : IRequestHandler<GetLast6FoodQuery, List<GetLast6FoodQueryResult>>
	{
		private readonly IFoodRepository _repository;

		public GetLast6FoodQueryHandler(IFoodRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetLast6FoodQueryResult>> Handle(GetLast6FoodQuery request, CancellationToken cancellationToken)
		{
			var values =  _repository.GetLast6Food();
			return values.Select(x=> new GetLast6FoodQueryResult
			{
				CoverImageUrl=x.CoverImageUrl,
				Description=x.Description,
				FoodId=x.FoodId,
				Name=x.Name,
				Price=x.Price
			}).ToList();
		}
	}
}
