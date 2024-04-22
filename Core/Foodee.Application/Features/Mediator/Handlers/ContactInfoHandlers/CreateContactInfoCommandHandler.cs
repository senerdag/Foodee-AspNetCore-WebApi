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
    internal class CreateContactInfoCommandHandler : IRequestHandler<CreateContactInfoCommand>
    {
        private readonly IRepository<ContactInfo> _repository;

        public CreateContactInfoCommandHandler(IRepository<ContactInfo> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new ContactInfo
            {
                Name = request.Name,
                Description = request.Description,
                Icon= request.Icon

            });
        }
    }
}
