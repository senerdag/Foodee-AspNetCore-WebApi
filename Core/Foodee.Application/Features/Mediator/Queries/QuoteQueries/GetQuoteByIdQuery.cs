using Foodee.Application.Features.Mediator.Results.QuoteResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Queries.QuoteQueries
{
    public class GetQuoteByIdQuery:IRequest<GetQuoteByIdQueryResult>
    {
        public int Id { get; set; }

        public GetQuoteByIdQuery(int id)
        {
            Id = id;
        }
    }
}
