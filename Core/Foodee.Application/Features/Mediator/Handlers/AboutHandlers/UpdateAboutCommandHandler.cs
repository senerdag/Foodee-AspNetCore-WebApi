using Foodee.Application.Features.Mediator.Commands.AboutCommands;
using Foodee.Application.Interfaces;
using Foodee.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodee.Application.Features.Mediator.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.AboutId);
            values.Description = request.Description;
            values.CoverImageUrl = request.CoverImageUrl;
            values.Title = request.Title;
            await _repository.UpdateAsync(values);
        }
    }
}
