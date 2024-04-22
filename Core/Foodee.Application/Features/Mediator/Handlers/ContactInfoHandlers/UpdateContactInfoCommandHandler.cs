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
    public class UpdateContactInfoCommandHandler : IRequestHandler<UpdateContactInfoCommand>
    {
        private readonly IRepository<ContactInfo> _repository;

        public UpdateContactInfoCommandHandler(IRepository<ContactInfo> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ContactInfoId);
            values.Description = request.Description;
            values.Icon = request.Icon;
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
