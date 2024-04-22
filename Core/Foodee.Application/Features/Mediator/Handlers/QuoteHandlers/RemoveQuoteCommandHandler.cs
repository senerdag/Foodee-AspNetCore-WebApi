using Foodee.Application.Features.Mediator.Commands.QuoteCommands;
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
    public class RemoveQuoteCommandHandler : IRequestHandler<RemoveQuoteCommand>
    {
        private readonly IRepository<Quote> _repository;

        public RemoveQuoteCommandHandler(IRepository<Quote> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveQuoteCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
