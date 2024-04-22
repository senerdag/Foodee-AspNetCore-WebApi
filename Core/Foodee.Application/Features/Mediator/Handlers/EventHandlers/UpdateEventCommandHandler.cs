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
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IRepository<Event> _repository;

        public UpdateEventCommandHandler(IRepository<Event> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.EventId);
            values.Description = request.Description;
            values.EventDate = request.EventDate;
            values.Title = request.Title;
            await _repository.UpdateAsync(values);
        }
    }
}
