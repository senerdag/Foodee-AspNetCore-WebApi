using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Commands.QuoteCommands
{
    public class RemoveQuoteCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveQuoteCommand(int id)
        {
            Id = id;
        }
    }
}
