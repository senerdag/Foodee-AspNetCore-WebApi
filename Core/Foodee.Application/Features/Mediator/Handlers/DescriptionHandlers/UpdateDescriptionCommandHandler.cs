using Foodee.Application.Features.Mediator.Commands.DescriptionCommands;
using Foodee.Application.Interfaces;
using Foodee.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Handlers.DescriptionHandlers
{
    public class UpdateDescriptionCommandHandler : IRequestHandler<UpdateDescriptionCommand>
    {
        private readonly IRepository<Description> _repository;

        public UpdateDescriptionCommandHandler(IRepository<Description> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateDescriptionCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.DescriptionId);
            values.MainDescription = request.MainDescription;
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
