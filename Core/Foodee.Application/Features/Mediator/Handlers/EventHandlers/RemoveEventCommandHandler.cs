using Foodee.Application.Features.Mediator.Commands.EventCommands;
using Foodee.Application.Interfaces;
using Foodee.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Handlers.EventHandlers
{
    public class RemoveEventCommandHandler : IRequestHandler<RemoveEventCommand>
    {
        private readonly IRepository<Event> _repository;

        public RemoveEventCommandHandler(IRepository<Event> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveEventCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
