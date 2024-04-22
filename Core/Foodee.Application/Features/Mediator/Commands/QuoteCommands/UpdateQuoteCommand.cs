using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Commands.QuoteCommands
{
    public class UpdateQuoteCommand:IRequest
    {
        public int QuoteId { get; set; }
        public string PersonName { get; set; }
        public string Description { get; set; }
    }
}
