using Foodee.Application.Features.Mediator.Queries.FoodQueries;
using Foodee.Application.Features.Mediator.Results.FoodResults;
using Foodee.Application.Interfaces;
using Foodee.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Handlers.FoodHandlers
{
    public class GetFoodQueryHandler : IRequestHandler<GetFoodQuery, List<GetFoodQueryResult>>
    {
        private readonly IRepository<Food> _repository;

        public GetFoodQueryHandler(IRepository<Food> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFoodQueryResult>> Handle(GetFoodQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFoodQueryResult
            {
                FoodId = x.FoodId,
                CoverImageUrl = x.CoverImageUrl,
                Description = x.Description,
                Name = x.Name,
                CategoryId = x.CategoryId,
                Price = x.Price
            }).ToList();
        }
    }
}
