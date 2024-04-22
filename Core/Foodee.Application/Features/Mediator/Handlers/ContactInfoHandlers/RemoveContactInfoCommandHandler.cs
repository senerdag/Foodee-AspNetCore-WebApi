using Foodee.Application.Features.Mediator.Commands.ContactInfoCommands;
using Foodee.Application.Interfaces;
using Foodee.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Handlers.ContactInfoHandlers
{
    public class RemoveContactInfoCommandHandler : IRequestHandler<RemoveContactInfoCommand>
    {
        private readonly IRepository<ContactInfo> _repository;

        public RemoveContactInfoCommandHandler(IRepository<ContactInfo> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveContactInfoCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
