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
    public class UpdateQuoteCommandHandler : IRequestHandler<UpdateQuoteCommand>
    {
        private readonly IRepository<Quote> _repository;

        public UpdateQuoteCommandHandler(IRepository<Quote> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateQuoteCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.QuoteId);
            values.Description = request.Description;
            values.PersonName = request.PersonName;
            await _repository.UpdateAsync(values);
        }
    }
}
