using Foodee.Application.Features.Mediator.Queries.EventQueries;
using Foodee.Application.Features.Mediator.Results.EventResults;
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
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, GetEventByIdQueryResult>
    {
        private readonly IRepository<Event> _repository;

        public GetEventByIdQueryHandler(IRepository<Event> repository)
        {
            _repository = repository;
        }

        public async Task<GetEventByIdQueryResult> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetEventByIdQueryResult
            {
                EventId = values.EventId,
                EventDate = values.EventDate,
                Description = values.Description,
                Title = values.Title
            };
        }
    }
}
