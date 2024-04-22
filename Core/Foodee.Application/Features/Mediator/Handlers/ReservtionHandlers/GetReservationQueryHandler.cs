using Foodee.Application.Features.Mediator.Queries.ReservationQueries;
using Foodee.Application.Features.Mediator.Results.ReservationResults;
using Foodee.Application.Interfaces;
using Foodee.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Handlers.ReservtionHandlers
{
    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, List<GetReservationQueryResult>>
    {
        private readonly IRepository<Reservation> _repository;

        public GetReservationQueryHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReservationQueryResult>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetReservationQueryResult
            {
                Email = x.Email,
                Name = x.Name,
                Message = x.Message,
                People = x.People,
                ReservationDate = x.ReservationDate,
                ReservationId = x.ReservationId
            }).ToList();
        }
    }
}
