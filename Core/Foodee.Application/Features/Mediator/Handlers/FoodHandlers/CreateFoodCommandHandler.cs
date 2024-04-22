using Foodee.Application.Features.Mediator.Commands.FoodCommands;
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
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand>
    {
        private readonly IRepository<Food> _repository;

        public CreateFoodCommandHandler(IRepository<Food> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Food
            {
                CoverImageUrl = request.CoverImageUrl,
                Description = request.Description,
                Name = request.Name,
                CategoryId = request.CategoryId,
                Price = request.Price,

            });
        }
    }
}
