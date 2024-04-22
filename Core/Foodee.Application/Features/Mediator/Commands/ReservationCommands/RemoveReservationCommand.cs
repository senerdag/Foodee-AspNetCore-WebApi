using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Commands.ReservationCommands
{
    public class RemoveReservationCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveReservationCommand(int id)
        {
            Id = id;
        }
    }
}
