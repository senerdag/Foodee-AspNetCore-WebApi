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
    public class GetFoodByIdQueryHandler : IRequestHandler<GetFoodByIdQuery, GetFoodByIdQueryResult>
    {
        private readonly IRepository<Food> _repository;

        public GetFoodByIdQueryHandler(IRepository<Food> repository)
        {
            _repository = repository;
        }

        public async Task<GetFoodByIdQueryResult> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetFoodByIdQueryResult
            {
                FoodId = values.FoodId,
                CoverImageUrl = values.CoverImageUrl,
                Description = values.Description,
                Price = values.Price,
                CategoryId = values.CategoryId,
                Name = values.Name
            };
        }
    }
}
