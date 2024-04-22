using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Results.QuoteResults
{
    public class GetQuoteQueryResult
    {
        public int QuoteId { get; set; }
        public string PersonName { get; set; }
        public string Description { get; set; }
    }
}
