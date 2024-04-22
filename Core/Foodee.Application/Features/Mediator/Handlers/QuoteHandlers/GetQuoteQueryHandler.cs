using Foodee.Application.Features.Mediator.Queries.QuoteQueries;
using Foodee.Application.Features.Mediator.Results.QuoteResults;
using Foodee.Application.Interfaces;
using Foodee.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Handlers.QuoteHandlers
{
    public class GetQuoteQueryHandler : IRequestHandler<GetQuoteQuery, List<GetQuoteQueryResult>>
    {
        private readonly IRepository<Quote> _repository;

        public GetQuoteQueryHandler(IRepository<Quote> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetQuoteQueryResult>> Handle(GetQuoteQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetQuoteQueryResult
            {
                QuoteId = x.QuoteId,
                PersonName= x.PersonName,
                Description = x.Description
            }).ToList();
        }
    }
}
