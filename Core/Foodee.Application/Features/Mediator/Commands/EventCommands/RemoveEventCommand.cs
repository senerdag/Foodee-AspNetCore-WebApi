using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Commands.EventCommands
{
    public class RemoveEventCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveEventCommand(int id)
        {
            Id = id;
        }
    }
}
