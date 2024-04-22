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
    public class CreateDescriptionCommandHandler : IRequestHandler<CreateDescriptionCommand>
    {
        private readonly IRepository<Description> _repository;

        public CreateDescriptionCommandHandler(IRepository<Description> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateDescriptionCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Description
            {
                Name = request.Name,
                MainDescription = request.MainDescription

            });
        }
    }
}
