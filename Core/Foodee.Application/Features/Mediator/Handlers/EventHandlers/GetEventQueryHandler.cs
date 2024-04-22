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
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, List<GetEventQueryResult>>
    {
        private readonly IRepository<Event> _repository;

        public GetEventQueryHandler(IRepository<Event> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetEventQueryResult>> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetEventQueryResult
            {
                EventId = x.EventId,
                EventDate = x.EventDate,
                Description = x.Description,
                Title = x.Title
            }).ToList();
        }
    }
}
