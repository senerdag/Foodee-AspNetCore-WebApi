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
    public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommand>
    {
        private readonly IRepository<Quote> _repository;

        public CreateQuoteCommandHandler(IRepository<Quote> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Quote
            {
                Description = request.Description,
                PersonName = request.PersonName

            });
        }
    }
}
