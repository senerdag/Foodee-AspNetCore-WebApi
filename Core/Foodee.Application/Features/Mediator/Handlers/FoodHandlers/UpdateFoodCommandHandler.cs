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
    public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand>
    {
        private readonly IRepository<Food> _repository;

        public UpdateFoodCommandHandler(IRepository<Food> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.FoodId);
            values.Description = request.Description;
            values.CoverImageUrl = request.CoverImageUrl;
            values.Price = request.Price;
            values.CategoryId = request.CategoryId;
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
