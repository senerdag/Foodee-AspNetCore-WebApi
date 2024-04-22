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
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, GetReservationByIdQueryResult>
    {
        private readonly IRepository<Reservation> _repository;

        public GetReservationByIdQueryHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<GetReservationByIdQueryResult> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetReservationByIdQueryResult
            {
                ReservationDate= values.ReservationDate,    
                ReservationId= request.Id,
                People= values.People,
                Message= values.Message,
                Name= values.Name,
                Email = values.Email
            };
        }
    }
}
