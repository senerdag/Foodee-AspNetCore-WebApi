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
    public class RemoveFoodCommandHandler : IRequestHandler<RemoveFoodCommand>
    {
        private readonly IRepository<Food> _repository;

        public RemoveFoodCommandHandler(IRepository<Food> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFoodCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
