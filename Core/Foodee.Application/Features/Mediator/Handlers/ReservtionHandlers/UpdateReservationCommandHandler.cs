using Foodee.Application.Features.Mediator.Commands.ReservationCommands;
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
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public UpdateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ReservationId);
            values.ReservationDate = request.ReservationDate;
            values.People = request.People;
            values.Message = request.Message;
            values.Name = request.Name;
            values.Email = request.Email;
            await _repository.UpdateAsync(values);
        }
    }
}
