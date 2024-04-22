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
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
    {
        private readonly IRepository<Event> _repository;

        public CreateEventCommandHandler(IRepository<Event> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Event
            {
                EventDate = request.EventDate,
                Description = request.Description,
                Title = request.Title
                

            });
        }
    }
}
