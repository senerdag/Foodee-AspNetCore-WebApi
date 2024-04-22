using Foodee.Application.Features.Mediator.Queries.FoodQueries;
using Foodee.Application.Features.Mediator.Results.CategoryResults;
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
	public class GetCategoryWithFoodsQueryHandler : IRequestHandler<GetCategoryWithFoodsQuery, List<GetCategoryWithFoodsQueryResult>>
	{
		private readonly IFoodRepository _repository;

		public GetCategoryWithFoodsQueryHandler(IFoodRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCategoryWithFoodsQueryResult>> Handle(GetCategoryWithFoodsQuery request, CancellationToken cancellationToken)
		{
			var values =  _repository.GetCategoryWithFoods();
			return values.Select(x => new GetCategoryWithFoodsQueryResult
			{
				CategoryId = x.Category.CategoryId,
				FoodCategoryId=x.CategoryId,
				CategoryName=x.Category.Name,
				Name = x.Name,
				CoverImageUrl = x.CoverImageUrl,
				Description = x.Description,
				FoodId = x.FoodId,
				Icon=x.Category.Icon,
				Price = x.Price
			}).ToList();
		}
	}
}
