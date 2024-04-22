using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Commands.EventCommands
{
    public class CreateEventCommand:IRequest
    {
        public string Title { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }
    }
}
