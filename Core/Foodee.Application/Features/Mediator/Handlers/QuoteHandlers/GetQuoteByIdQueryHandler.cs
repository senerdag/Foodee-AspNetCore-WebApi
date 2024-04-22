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
    public class GetQuoteByIdQueryHandler : IRequestHandler<GetQuoteByIdQuery, GetQuoteByIdQueryResult>
    {
        private readonly IRepository<Quote> _repository;

        public GetQuoteByIdQueryHandler(IRepository<Quote> repository)
        {
            _repository = repository;
        }

        public async Task<GetQuoteByIdQueryResult> Handle(GetQuoteByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetQuoteByIdQueryResult
            {
                QuoteId = values.QuoteId,
                PersonName= values.PersonName,
                Description = values.Description
            };
        }
    }
}
